using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;

namespace TestSpreadsheet
{
    public partial class RecentFilesListUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler? ItemDoubleClick;
        public event EventHandler? ItemOpenFolderClick;
        public RecentFile? SelectedItem => gridView.GetFocusedRow() as RecentFile;
        public RecentFilesListUserControl()
        {
            InitializeComponent();           
            gridView.OptionsView.GroupDrawMode = GroupDrawMode.Office;
            gridView.OptionsView.ShowGroupedColumns = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowVerticalLines = DefaultBoolean.False;
            gridView.OptionsBehavior.AutoExpandAllGroups = true;        
            gridView.DoubleClick += (s, e) => ItemDoubleClick?.Invoke(this, EventArgs.Empty);
            simpleButtonRegisterExtensions.Click += (s, e) =>
            {
                Cursor = Cursors.WaitCursor;
                RegisterService.RegisterExcelAssociationToApp();
                RefreshFileAssociationPrograms();
                RefreshFileAssociationIcons();
                Cursor = Cursors.Default;
            };
            simpleButtonRemoveAssociations.Click += (s, e) =>
            {
                Cursor = Cursors.WaitCursor;
                RemoveFileAssociations();
                RefreshFileAssociationPrograms();
                RefreshFileAssociationIcons();
                Cursor = Cursors.Default;
            };
            repositoryItemButtonEditActions.ButtonClick += (s, e) =>
            {
                if (e.Button.ToolTip == "Open folder") ItemOpenFolderClick?.Invoke(this, EventArgs.Empty);
            };
        }

        public void Initialize()
        {
            simpleButtonRegisterExtensions.ImageOptions.Image = (FindForm() as MainForm)?.IconOptions.Icon.ToBitmap();
            RefreshFileAssociationPrograms();
            RefreshFileAssociationIcons();
        }

        private void RefreshFileAssociationPrograms()
        {
            labelControlAssociatedAppXLS.Text = 
                $"{ExcelFileExtensions.XLS} -> {Win32RegistryHelper.GetAssociatedProgram(ExcelFileExtensions.XLS)}";
            labelControlAssociatedAppXLSX.Text = 
                $"{ExcelFileExtensions.XLSX} -> {Win32RegistryHelper.GetAssociatedProgram(ExcelFileExtensions.XLSX)}";
        }

        private void RefreshFileAssociationIcons()
        {
            var temppathxls = Path.GetTempFileName();
            var tempxls = temppathxls.Replace("tmp", ExcelFileExtensions.XLS);
            File.Create(tempxls);
            var iconxls = RecentFile.GetIconFromFile(tempxls);
            labelControlAssociatedAppXLS.ImageOptions.Image = iconxls;

            var temppathxlsx = Path.GetTempFileName();
            var tempxlsx = temppathxlsx.Replace("tmp", ExcelFileExtensions.XLSX);
            File.Create(tempxlsx);
            var iconxlsx = RecentFile.GetIconFromFile(tempxlsx);
            labelControlAssociatedAppXLSX.ImageOptions.Image = iconxlsx;
        }

        private static void RemoveFileAssociations()
        {
            Win32RegistryHelper.RemoveAllAssociations(ExcelFileExtensions.XLS);
            Win32RegistryHelper.RemoveAllAssociations(ExcelFileExtensions.XLSX);
        }

        public void SetData(IList<RecentFile> recentFiles) => gridControl.DataSource = recentFiles;
    }
}
