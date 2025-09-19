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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecentFilesListUserControl));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            colExists = new DevExpress.XtraGrid.Columns.GridColumn();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            simpleButtonRemoveAssociations = new DevExpress.XtraEditors.SimpleButton();
            simpleButtonRegisterExtensions = new DevExpress.XtraEditors.SimpleButton();
            labelControlAssociatedApp = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recentFileBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
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
            layoutControl1.Controls.Add(simpleButtonRemoveAssociations);
            layoutControl1.Controls.Add(simpleButtonRegisterExtensions);
            layoutControl1.Controls.Add(labelControlAssociatedApp);
            layoutControl1.Controls.Add(labelControl1);
            layoutControl1.Controls.Add(gridControl);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(1002, 623);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // simpleButtonRemoveAssociations
            // 
            simpleButtonRemoveAssociations.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            simpleButtonRemoveAssociations.ImageOptions.ImageToTextIndent = 10;
            simpleButtonRemoveAssociations.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButtonRemoveAssociations.ImageOptions.SvgImage");
            simpleButtonRemoveAssociations.Location = new Point(20, 191);
            simpleButtonRemoveAssociations.Name = "simpleButtonRemoveAssociations";
            simpleButtonRemoveAssociations.Padding = new Padding(8);
            simpleButtonRemoveAssociations.Size = new Size(173, 89);
            simpleButtonRemoveAssociations.StyleController = layoutControl1;
            simpleButtonRemoveAssociations.TabIndex = 7;
            simpleButtonRemoveAssociations.Text = "Remove XLS and XLSX \r\nextensions asociations";
            // 
            // simpleButtonRegisterExtensions
            // 
            simpleButtonRegisterExtensions.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            simpleButtonRegisterExtensions.ImageOptions.ImageToTextIndent = 10;
            simpleButtonRegisterExtensions.Location = new Point(20, 124);
            simpleButtonRegisterExtensions.Name = "simpleButtonRegisterExtensions";
            simpleButtonRegisterExtensions.Padding = new Padding(8);
            simpleButtonRegisterExtensions.Size = new Size(173, 47);
            simpleButtonRegisterExtensions.StyleController = layoutControl1;
            simpleButtonRegisterExtensions.TabIndex = 6;
            simpleButtonRegisterExtensions.Text = "Associate XLS and XLSX \r\nextensions with Falcon Matrix";
            // 
            // labelControlAssociatedApp
            // 
            labelControlAssociatedApp.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            labelControlAssociatedApp.Appearance.Options.UseFont = true;
            labelControlAssociatedApp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControlAssociatedApp.Location = new Point(12, 79);
            labelControlAssociatedApp.Name = "labelControlAssociatedApp";
            labelControlAssociatedApp.Padding = new Padding(10);
            labelControlAssociatedApp.Size = new Size(189, 33);
            labelControlAssociatedApp.StyleController = layoutControl1;
            labelControlAssociatedApp.TabIndex = 5;
            labelControlAssociatedApp.Text = "-";
            // 
            // labelControl1
            // 
            labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl1.Location = new Point(12, 42);
            labelControl1.Name = "labelControl1";
            labelControl1.Padding = new Padding(10);
            labelControl1.Size = new Size(189, 33);
            labelControl1.StyleController = layoutControl1;
            labelControl1.TabIndex = 4;
            labelControl1.Text = "Excel files are associated to";
            // 
            // gridControl
            // 
            gridControl.DataSource = recentFileBindingSource;
            gridControl.Location = new Point(205, 42);
            gridControl.MainView = gridView;
            gridControl.Name = "gridControl";
            gridControl.Size = new Size(785, 569);
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
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = colExists;
            gridFormatRule1.Name = "FormatMarkFileNotExist";
            formatConditionRuleValue1.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Strikeout);
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = false;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridView.FormatRules.Add(gridFormatRule1);
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
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { emptySpaceItem1, layoutControlItem1, emptySpaceItem2, emptySpaceItem3, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5 });
            Root.Name = "Root";
            Root.Size = new Size(1002, 623);
            Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AppearanceItemCaption.Font = new Font("Tahoma", 14F);
            emptySpaceItem1.AppearanceItemCaption.Options.UseFont = true;
            emptySpaceItem1.Location = new Point(0, 0);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(193, 30);
            emptySpaceItem1.Text = "Excel Files";
            emptySpaceItem1.TextVisible = true;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl;
            layoutControlItem1.Location = new Point(193, 30);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(789, 573);
            layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.AppearanceItemCaption.Font = new Font("Tahoma", 14F);
            emptySpaceItem2.AppearanceItemCaption.Options.UseFont = true;
            emptySpaceItem2.Location = new Point(193, 0);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new Size(789, 30);
            emptySpaceItem2.Text = "Recent Files";
            emptySpaceItem2.TextVisible = true;
            // 
            // emptySpaceItem3
            // 
            emptySpaceItem3.Location = new Point(0, 280);
            emptySpaceItem3.Name = "emptySpaceItem3";
            emptySpaceItem3.Size = new Size(193, 323);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = labelControl1;
            layoutControlItem2.Location = new Point(0, 30);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(193, 37);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = labelControlAssociatedApp;
            layoutControlItem3.Location = new Point(0, 67);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(193, 37);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = simpleButtonRegisterExtensions;
            layoutControlItem4.Location = new Point(0, 104);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            layoutControlItem4.Size = new Size(193, 67);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = simpleButtonRemoveAssociations;
            layoutControlItem5.Location = new Point(0, 171);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            layoutControlItem5.Size = new Size(193, 109);
            layoutControlItem5.TextVisible = false;
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
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
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
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.LabelControl labelControlAssociatedApp;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRegisterExtensions;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRemoveAssociations;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
