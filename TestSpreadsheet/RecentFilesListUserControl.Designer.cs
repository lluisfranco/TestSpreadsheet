namespace TestSpreadsheet
{
    partial class RecentFilesListUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            colExists = new DevExpress.XtraGrid.Columns.GridColumn();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            gridControl = new DevExpress.XtraGrid.GridControl();
            recentFileBindingSource = new BindingSource(components);
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastModified = new DevExpress.XtraGrid.Columns.GridColumn();
            colFileSize = new DevExpress.XtraGrid.Columns.GridColumn();
            colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recentFileBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            SuspendLayout();
            // 
            // colExists
            // 
            colExists.FieldName = "Exists";
            colExists.Name = "colExists";
            colExists.OptionsColumn.AllowSize = false;
            colExists.OptionsColumn.FixedWidth = true;
            colExists.OptionsColumn.ReadOnly = true;
            colExists.Width = 60;
            // 
            // layoutControl1
            // 
            layoutControl1.AllowCustomization = false;
            layoutControl1.Controls.Add(gridControl);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1002, 623);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // gridControl
            // 
            gridControl.DataSource = recentFileBindingSource;
            gridControl.Location = new Point(178, 47);
            gridControl.MainView = gridView;
            gridControl.Name = "gridControl";
            gridControl.Size = new Size(812, 564);
            gridControl.TabIndex = 0;
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
            // 
            // recentFileBindingSource
            // 
            recentFileBindingSource.DataSource = typeof(RecentFile);
            // 
            // gridView
            // 
            gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFilePath, colExists, colFileName, colLastModified, colFileSize, colImage });
            gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = colExists;
            gridFormatRule2.Name = "FormatMarkFileNotExist";
            formatConditionRuleValue2.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Strikeout);
            formatConditionRuleValue2.Appearance.Options.UseFont = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = false;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridView.FormatRules.Add(gridFormatRule2);
            gridView.GridControl = gridControl;
            gridView.GroupCount = 1;
            gridView.Name = "gridView";
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] { new DevExpress.XtraGrid.Columns.GridColumnSortInfo(colLastModified, DevExpress.Data.ColumnSortOrder.Descending) });
            // 
            // colFilePath
            // 
            colFilePath.FieldName = "FilePath";
            colFilePath.Name = "colFilePath";
            colFilePath.Visible = true;
            colFilePath.VisibleIndex = 2;
            colFilePath.Width = 420;
            // 
            // colFileName
            // 
            colFileName.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            colFileName.AppearanceCell.Options.UseFont = true;
            colFileName.FieldName = "FileName";
            colFileName.Name = "colFileName";
            colFileName.OptionsColumn.ReadOnly = true;
            colFileName.Visible = true;
            colFileName.VisibleIndex = 1;
            colFileName.Width = 217;
            // 
            // colLastModified
            // 
            colLastModified.DisplayFormat.FormatString = "g";
            colLastModified.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colLastModified.FieldName = "LastModified";
            colLastModified.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            colLastModified.Name = "colLastModified";
            colLastModified.OptionsColumn.ReadOnly = true;
            colLastModified.Visible = true;
            colLastModified.VisibleIndex = 3;
            // 
            // colFileSize
            // 
            colFileSize.Caption = "Size (Kb)";
            colFileSize.FieldName = "FileSize";
            colFileSize.Name = "colFileSize";
            colFileSize.OptionsColumn.AllowSize = false;
            colFileSize.OptionsColumn.FixedWidth = true;
            colFileSize.OptionsColumn.ReadOnly = true;
            colFileSize.Visible = true;
            colFileSize.VisibleIndex = 3;
            colFileSize.Width = 60;
            // 
            // colImage
            // 
            colImage.FieldName = "Image";
            colImage.Name = "colImage";
            colImage.OptionsColumn.AllowSize = false;
            colImage.OptionsColumn.FixedWidth = true;
            colImage.Visible = true;
            colImage.VisibleIndex = 0;
            colImage.Width = 60;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { emptySpaceItem1, layoutControlItem1, emptySpaceItem2 });
            Root.Name = "Root";
            Root.Size = new Size(1002, 623);
            Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 0);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(166, 603);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl;
            layoutControlItem1.Location = new Point(166, 35);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(816, 568);
            layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AppearanceItemCaption.Font = new Font("Tahoma", 14F);
            emptySpaceItem2.AppearanceItemCaption.Options.UseFont = true;
            emptySpaceItem2.Location = new Point(166, 0);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(816, 35);
            emptySpaceItem2.Text = "Recent Files";
            emptySpaceItem2.TextVisible = true;
            // 
            // RecentFilesListUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "RecentFilesListUserControl";
            Size = new Size(1002, 623);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)recentFileBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private BindingSource recentFileBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFilePath;
        private DevExpress.XtraGrid.Columns.GridColumn colExists;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastModified;
        private DevExpress.XtraGrid.Columns.GridColumn colFileSize;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
    }
}
