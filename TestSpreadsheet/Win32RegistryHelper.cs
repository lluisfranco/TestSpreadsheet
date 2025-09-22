using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace TestSpreadsheet
{
    public class Win32RegistryHelper
    {
        public static bool IsExtensionRegistered(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension)) return false;
            if (!extension.StartsWith('.')) extension = $".{extension}";
            using RegistryKey? key = Registry.ClassesRoot.OpenSubKey(extension);
            return key != null;
        }

        public static string? GetAssociatedProgram(string extension)
        {
            if (!extension.StartsWith('.')) extension = $".{extension}";
            using RegistryKey? key = Registry.ClassesRoot.OpenSubKey(extension);
            if (key == null) return null;
            return key.GetValue("") as string;
        }

        public static void RegisterFileAssociation(
            string extension, string progId, string description, string applicationPath)
        {
            // 1) Normalize inputs
            if (string.IsNullOrWhiteSpace(extension)) throw new ArgumentNullException(nameof(extension));
            if (!extension.StartsWith(".")) extension = "." + extension.Trim();
            extension = extension.ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(progId)) throw new ArgumentNullException(nameof(progId));
            if (string.IsNullOrWhiteSpace(applicationPath)) throw new ArgumentNullException(nameof(applicationPath));

            applicationPath = Path.GetFullPath(applicationPath);
            string exeName = Path.GetFileName(applicationPath);

            using var root = Registry.CurrentUser.CreateSubKey(@"Software\Classes");

            // 2) .ext -> ProgID
            using (var extKey = root.CreateSubKey(extension))
            {
                // Default value is the ProgID
                extKey.SetValue("", progId, RegistryValueKind.String);

                // Make the app appear in "Open with"
                using var ow = extKey.CreateSubKey("OpenWithProgids");
                // Empty value is fine; REG_SZ is OK for this purpose
                ow.SetValue(progId, "", RegistryValueKind.String);
            }

            // 3) ProgID definition
            using (var progIdKey = root.CreateSubKey(progId))
            {
                progIdKey.SetValue("", description, RegistryValueKind.String);

                using (var iconKey = progIdKey.CreateSubKey("DefaultIcon"))
                    iconKey.SetValue("", $"\"{applicationPath}\",0", RegistryValueKind.String);

                using var cmdKey = progIdKey.CreateSubKey(@"shell\open\command");
                cmdKey.SetValue("", $"\"{applicationPath}\" \"%1\"", RegistryValueKind.String);

                // Optional: friendly verb text
                using var verbKey = progIdKey.CreateSubKey(@"shell\open");
                verbKey.SetValue("FriendlyAppName", "FalconMatrix 2025", RegistryValueKind.String);
            }

            // 4) Applications\YourExe.exe (helps "Open with" UI)
            using (var appCmd = root.CreateSubKey($@"Applications\{exeName}\shell\open\command"))
                appCmd.SetValue("", $"\"{applicationPath}\" \"%1\"", RegistryValueKind.String);

            // 5) Tell Explorer that associations changed
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero); // SHCNE_ASSOCCHANGED
        }

        public static void RemoveAllAssociations(string extension)
            {
                if (string.IsNullOrWhiteSpace(extension))
                    throw new ArgumentException("Extension is required (e.g., \".txt\").");
                if (!extension.StartsWith("."))
                    extension = "." + extension;

                // Delete per-user first
                DeleteExtensionAndRelated(RegistryHive.CurrentUser, extension);

                // Clear Explorer MRU / per-user choices
                DeleteKeyTree(RegistryHive.CurrentUser,
                    $@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\{extension}");
                            
                // Nudge the shell so changes take effect
                BroadcastAssocChange();
            }

        private static void DeleteExtensionAndRelated(RegistryHive hive, string extension)
        {
            // Read ProgID (default value of .ext), so we can remove it as well
            string progId = null;
            using (var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64))
            using (var extKey = baseKey.OpenSubKey(@"Software\Classes\" + extension))
            {
                progId = extKey?.GetValue(null) as string;
            }

            // Delete .ext under both 64-bit and 32-bit views (just in case)
            DeleteKeyTree(hive, $@"Software\Classes\{extension}", RegistryView.Registry64);
            DeleteKeyTree(hive, $@"Software\Classes\{extension}", RegistryView.Registry32);

            // Delete ProgID trees if we found one (they might not exist, that’s fine)
            if (!string.IsNullOrWhiteSpace(progId))
            {
                DeleteKeyTree(hive, $@"Software\Classes\{progId}", RegistryView.Registry64);
                DeleteKeyTree(hive, $@"Software\Classes\{progId}", RegistryView.Registry32);
            }
        }

        private static void DeleteKeyTree(RegistryHive hive, string subKey, RegistryView view = RegistryView.Default)
        {
            try
            {
                using var baseKey = RegistryKey.OpenBaseKey(hive, view);
                baseKey.DeleteSubKeyTree(subKey, throwOnMissingSubKey: false);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException(
                    $"Access denied deleting '{hive}\\{subKey}' (try running as Administrator).", ex);
            }
            catch (Exception ex) when (ex is System.Security.SecurityException || ex is Win32Exception)
            {
                throw;
            }
        }

        // ---- Shell notifications ----
        private const int HWND_BROADCAST = 0xffff;
        private const int WM_SETTINGCHANGE = 0x001A;
        private const int SMTO_ABORTIFHUNG = 0x0002;

        [Flags]
        private enum Shcn : uint { AssocChanged = 0x08000000 }

        [DllImport("shell32.dll")]
        private static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr SendMessageTimeout(
            IntPtr hWnd, int Msg, IntPtr wParam, string lParam,
            int fuFlags, int uTimeout, out IntPtr lpdwResult);

        private static void BroadcastAssocChange()
        {
            // Let Explorer and apps know associations changed
            SHChangeNotify((uint)Shcn.AssocChanged, 0, IntPtr.Zero, IntPtr.Zero);
            SendMessageTimeout((IntPtr)HWND_BROADCAST, WM_SETTINGCHANGE, IntPtr.Zero,
                "Software\\Classes", SMTO_ABORTIFHUNG, 5000, out _);
        }

        public static int? GetIntValue(string keyname, string valueName, int? defaultvalue = null) =>
            GetValue(keyname, valueName, defaultvalue) as int?;

        public static void SaveValue(string keyname, string valueName, object value)
        {
            using var softwarekey = Registry.CurrentUser.OpenSubKey("Software", true);
            using var key = softwarekey?.CreateSubKey(keyname);
            key?.SetValue(valueName, value);
        }

        public static object? GetValue(string keyname, string valueName, object? defaultvalue = null)
        {
            using var softwarekey = Registry.CurrentUser.OpenSubKey("Software", true);
            using var key = softwarekey?.OpenSubKey(keyname);
            return key?.GetValue(valueName, defaultvalue);
        }

        public static void SaveValueToRegistry(string app, string keyname, string value)
        {
            using RegistryKey key = Registry.CurrentUser.CreateSubKey($@"Software\{app}");
            key?.SetValue(keyname, value, RegistryValueKind.String);
        }

        public static string? ReadValueFromRegistry(string app, string keyname)
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey($@"Software\{app}");
            return key?.GetValue(keyname) as string;
        }

        public static void SaveListToRegistry(string app, string listname, string[] values)
        {
            using RegistryKey key = Registry.CurrentUser.CreateSubKey($@"Software\{app}");
            key?.SetValue(listname, values, RegistryValueKind.MultiString);
        }

        public static string[]? ReadListFromRegistry(string app, string listname)
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey($@"Software\{app}");
            if (key != null)
                return (string[])key.GetValue(listname, Array.Empty<string>());
            return default;
        }

        public static void OpenFolderAndSelectFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return;
            if (!File.Exists(filePath)) return;
            string argument = $"/select, \"{filePath}\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }
    }
}