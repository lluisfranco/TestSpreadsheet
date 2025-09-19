using System.IO;

namespace TestSpreadsheet
{
    public class RecentFilesService(string appName)
    {
        const string RECENT_FILES_KEY = "RecentFiles";
        const int FILE_COUNT_LIMIT = 25;
        public string AppName { get; set; } = appName;
        public IList<string> RecentFiles { get; private set; } = [];

        public void SaveRecentFileFile(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath)) return;
            RecentFiles.Remove(filepath);
            RecentFiles.Insert(0, filepath);
            if (RecentFiles.Count > FILE_COUNT_LIMIT) RecentFiles = [.. RecentFiles.Take(FILE_COUNT_LIMIT)];
            SaveRecentFiles();
        }
        
        public void LoadRecentFiles()
        {
            var files = Win32RegistryHelper.ReadListFromRegistry(AppName, RECENT_FILES_KEY);
            if (files != null) RecentFiles = [.. files];
        }

        public void SaveRecentFiles()
        {
            Win32RegistryHelper.SaveListToRegistry(AppName, RECENT_FILES_KEY, [.. RecentFiles]);
        }

    }

    public class RecentFile
    {
        public string FilePath { get; set; }
        public bool Exists => _FileInfo.Exists;
        public string? FileName => Exists ? _FileInfo.Name : null;
        public DateTime? LastModified => Exists ? _FileInfo.LastWriteTime : null;
        public long? FileSize => Exists ? _FileInfo.Length / 1024 : null;
        public Bitmap? Image => Exists ? GetIconFromFile(FilePath) : new(16,16);

        private FileInfo _FileInfo { get; set; }
        public RecentFile(string filePath)
        {
            FilePath = filePath;
            _FileInfo = new FileInfo(filePath);
        }

        public static Bitmap? GetIconFromFile(string filePath)
        {
            var icon = Icon.ExtractAssociatedIcon(filePath);
            return icon?.ToBitmap();
        }
    }
}