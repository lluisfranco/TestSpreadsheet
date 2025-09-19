using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace TestSpreadsheet
{
    public partial class RecentFilesListUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler? ItemDoubleClick;
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
                RegisterService.RegisterExcelAssociationToApp();
                labelControlAssociatedApp.Text = Win32RegistryHelper.GetAssociatedProgram("xls");
            };
        }

        public void Initialize()
        {
            simpleButtonRegisterExtensions.ImageOptions.Image = (FindForm() as MainForm)?.IconOptions.Icon.ToBitmap();
            labelControlAssociatedApp.Text = Win32RegistryHelper.GetAssociatedProgram("xls");

        }

        public void SetData(IList<RecentFile> recentFiles) => gridControl.DataSource = recentFiles;
    }
}
