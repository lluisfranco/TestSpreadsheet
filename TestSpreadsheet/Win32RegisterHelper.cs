using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace TestSpreadsheet
{
    public class Win32RegisterHelper
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
            using (var root = Registry.CurrentUser.CreateSubKey(@"Software\Classes"))
            {
                using (var extKey = root.CreateSubKey(extension))
                {
                    extKey.SetValue("", progId);
                }
                using var progIdKey = root.CreateSubKey(progId);
                progIdKey.SetValue("", description);
                using (var iconKey = progIdKey.CreateSubKey("DefaultIcon"))
                {
                    iconKey.SetValue("", $"\"{applicationPath}\",0");
                }
                using var shellKey = progIdKey.CreateSubKey(@"shell\open\command");
                shellKey.SetValue("", $"\"{applicationPath}\" \"%1\"");
            }
            NativeMethods.SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        private static class NativeMethods
        {
            [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern void SHChangeNotify(
                uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        }

        public static void SaveToListRegistry(string app, string listname, string[] values)
        {
            using RegistryKey key = Registry.CurrentUser.CreateSubKey($@"Software\{app}");
            key?.SetValue(listname, values, RegistryValueKind.MultiString);
        }

        public static string[]? ReadListFromRegistry(string app, string listname)
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey($@"Software\{app}");
            if (key != null)
                return (string[])key.GetValue("MyListMulti", Array.Empty<string>());
            return default;
        }
    }
}