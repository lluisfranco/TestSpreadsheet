using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System.IO;

namespace TestSpreadsheet
{
    public partial class MainForm : RibbonForm
    {
        const string APP_TITLE = "Falcon Matrix";
        private readonly RecentFilesService recentFilesService = new(APP_TITLE);
        public string? OpenFileOnStart { get; set; }
        public MainForm()
        {
            InitializeComponent();
            Text = APP_TITLE;
            barStaticItemVersion.Caption = $"{Application.ProductVersion}";
            MinimumSize = new Size(800, 600);
            this.AddFormBoundsRegistryStorage();
            ribbon.SelectedPage = homeRibbonPage1;
            ribbon.Toolbar.ItemLinks.Add(spreadsheetCommandBarButtonItem2);
            ribbon.Toolbar.ItemLinks.Add(spreadsheetCommandBarButtonItem3);
            ribbon.Toolbar.ItemLinks.Add(spreadsheetCommandBarButtonItem6);
            recentFilesService.LoadRecentFiles();
            var recentFilesUserControl = new RecentFilesListUserControl();
            ribbon.ApplicationButtonDropDownControl = recentFilesUserControl;
            ribbon.ApplicationButtonClick += (s, e) =>
            {
                var recentFilesList = recentFilesService.RecentFiles.Select(f => new RecentFile(f)).ToList();
                recentFilesUserControl.SetData(recentFilesList);
                recentFilesUserControl.Initialize();
            };
            recentFilesUserControl.ItemDoubleClick += (s, e) =>
            {
                var item = recentFilesUserControl.SelectedItem;
                if (item == null || !item.Exists) return;
                LoadDocument(item.FilePath);
            };
            Load += (s, e) => ThemeHelper.RestoreSavedTheme(APP_TITLE);
            Shown += (s, e) =>
            {
                if (!RegisterService.CheckIfExcelIsInstalled())
                {
                    if (XtraMessageBox.Show(
                        $"""
                        Microsoft Excel is not installed or Excel files are not registered.
                        Would you like to register *.xls and *.xlsx files with {APP_TITLE}?
                        """,
                        APP_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
                    RegisterService.RegisterExcelAssociationToApp();
                }
                if (OpenFileOnStart is not null) LoadDocument(OpenFileOnStart);
            };
            FormClosed += (s, e) => ThemeHelper.SaveCurrentTheme(APP_TITLE);
            spreadsheetControl.DocumentLoaded += (s, e) =>
            {
                spreadsheetControl.Document.CalculateFull();
                var file = new FileInfo(spreadsheetControl.Document.Path);
                Text = $"{APP_TITLE} - {file.Name}";
                recentFilesService.SaveRecentFileFile(spreadsheetControl.Document.Path);
                ribbon.HideApplicationButtonContentControl();
            };
            spreadsheetControl.DocumentSaved += (s, e) =>
            {
                recentFilesService.SaveRecentFileFile(spreadsheetControl.Document.Path);
                ribbon.HideApplicationButtonContentControl();
            };
        }

        private void LoadDocument(string filepath)
        {
            try
            {
                var r = spreadsheetControl.LoadDocument(filepath);
                ribbon.HideApplicationButtonContentControl();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading file: {ex.Message}",
                    APP_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}