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
        }

        public void SetData(IList<RecentFile> recentFiles) => gridControl.DataSource = recentFiles;
    }
}
