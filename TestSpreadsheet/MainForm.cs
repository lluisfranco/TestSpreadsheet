using DevExpress.XtraEditors;
using System.IO;

namespace TestSpreadsheet
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        const string APP_TITLE = "Falcon Matrix";
        private readonly RecentFilesService recentFilesService = new(APP_TITLE);
        public MainForm()
        {
            InitializeComponent();
            Text = APP_TITLE;
            ribbon.SelectedPage = homeRibbonPage1;
            ribbon.Toolbar.ItemLinks.Add(spreadsheetCommandBarButtonItem2);
            ribbon.Toolbar.ItemLinks.Add(spreadsheetCommandBarButtonItem3);
            ribbon.Toolbar.ItemLinks.Add(spreadsheetCommandBarButtonItem6);
            recentFilesService.LoadRecentFiles();

            Load += (s, e) => ThemeHelper.RestoreSavedTheme(APP_TITLE);
            Shown += (s, e) =>
            {
                if (!RegisterService.CheckIfExcelIsInstalled())
                {
                    if (XtraMessageBox.Show(
                        $"""
                        Microsoft Excel is not installed.
                        Would you like to register *.xls and *.xlsx files with {APP_TITLE}?
                        """,
                        APP_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
                    RegisterService.RegisterExcelAssociationToApp();
                }
            };
            FormClosed += (s, e) => ThemeHelper.SaveCurrentTheme(APP_TITLE);
            spreadsheetControl.DocumentLoaded += (s, e) =>
            {
                spreadsheetControl.Document.CalculateFull();
                var file = new FileInfo(spreadsheetControl.Document.Path);
                Text = $"{APP_TITLE} - {file.Name}";
                recentFilesService.SaveRecentFileFile(spreadsheetControl.Document.Path);
            };
            spreadsheetControl.DocumentSaved += (s, e) =>
            {
                recentFilesService.SaveRecentFileFile(spreadsheetControl.Document.Path);
            };
        }
    }
}