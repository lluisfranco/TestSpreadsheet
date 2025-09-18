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
            var files = Win32RegisterHelper.ReadListFromRegistry(AppName, RECENT_FILES_KEY);
            if (files != null) RecentFiles = [.. files];
        }

        public void SaveRecentFiles()
        {
            Win32RegisterHelper.SaveListToRegistry(AppName, RECENT_FILES_KEY, [.. RecentFiles]);
        }
    }
}