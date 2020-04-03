namespace PublicManager.Modules.Lines.ProjectNodes
{
    partial class ModuleController
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.rcTopBar = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSetSourceDir = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetDestDir = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportWithSelected = new DevExpress.XtraBars.BarButtonItem();
            this.btnDownloadExcelA = new DevExpress.XtraBars.BarButtonItem();
            this.rpMaster = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgImportA = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtWillTime = new System.Windows.Forms.DateTimePicker();
            this.cbWillTime = new System.Windows.Forms.CheckBox();
            this.txtNodeWillTime = new System.Windows.Forms.DateTimePicker();
            this.cbNodeWillTime = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.cbDisplayReporter = new System.Windows.Forms.CheckBox();
            this.cbDisplayContract = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKey = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcGrid
            // 
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGrid.Location = new System.Drawing.Point(3, 59);
            this.gcGrid.MainView = this.gvDetail;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gcGrid.Size = new System.Drawing.Size(1067, 372);
            this.gcGrid.TabIndex = 4;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn11,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn12});
            this.gvDetail.GridControl = this.gcGrid;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvDetail_RowCellClick);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "项目名称";
            this.gridColumn7.FieldName = "row7";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "节点序号";
            this.gridColumn1.FieldName = "row1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "拨付条件";
            this.gridColumn2.FieldName = "row2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "合同书预计评估时间";
            this.gridColumn3.FieldName = "row3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "节点评估时间";
            this.gridColumn11.FieldName = "row8";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "评估意见";
            this.gridColumn10.FieldName = "row9";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "评估等级";
            this.gridColumn9.FieldName = "row10";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "评估专家";
            this.gridColumn8.FieldName = "row11";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "经费金额(万元)";
            this.gridColumn4.FieldName = "row4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "备注";
            this.gridColumn5.FieldName = "row5";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "row6";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "...";
            this.gridColumn12.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn12.FieldName = "row12";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "从Excel导入数据", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // rcTopBar
            // 
            this.rcTopBar.ExpandCollapseItem.Id = 0;
            this.rcTopBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcTopBar.ExpandCollapseItem,
            this.btnSetSourceDir,
            this.btnSetDestDir,
            this.btnImportAll,
            this.btnImportWithSelected,
            this.btnDownloadExcelA});
            this.rcTopBar.Location = new System.Drawing.Point(0, 0);
            this.rcTopBar.MaxItemId = 9;
            this.rcTopBar.Name = "rcTopBar";
            this.rcTopBar.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpMaster});
            this.rcTopBar.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowCategoryInCaption = false;
            this.rcTopBar.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.rcTopBar.ShowQatLocationSelector = false;
            this.rcTopBar.ShowToolbarCustomizeItem = false;
            this.rcTopBar.Size = new System.Drawing.Size(1073, 123);
            this.rcTopBar.Toolbar.ShowCustomizeItem = false;
            this.rcTopBar.Visible = false;
            // 
            // btnSetSourceDir
            // 
            this.btnSetSourceDir.Caption = "设置主目录";
            this.btnSetSourceDir.Id = 1;
            this.btnSetSourceDir.LargeGlyph = global::PublicManager.Properties.Resources.folderA;
            this.btnSetSourceDir.Name = "btnSetSourceDir";
            // 
            // btnSetDestDir
            // 
            this.btnSetDestDir.Caption = "设置解压目录";
            this.btnSetDestDir.Id = 2;
            this.btnSetDestDir.LargeGlyph = global::PublicManager.Properties.Resources.folderB;
            this.btnSetDestDir.Name = "btnSetDestDir";
            // 
            // btnImportAll
            // 
            this.btnImportAll.Caption = "导入所有";
            this.btnImportAll.Id = 3;
            this.btnImportAll.LargeGlyph = global::PublicManager.Properties.Resources.importA;
            this.btnImportAll.Name = "btnImportAll";
            // 
            // btnImportWithSelected
            // 
            this.btnImportWithSelected.Caption = "选择性导入";
            this.btnImportWithSelected.Id = 4;
            this.btnImportWithSelected.LargeGlyph = global::PublicManager.Properties.Resources.importB;
            this.btnImportWithSelected.Name = "btnImportWithSelected";
            // 
            // btnDownloadExcelA
            // 
            this.btnDownloadExcelA.Caption = "下载项目与课题经费模板";
            this.btnDownloadExcelA.Id = 5;
            this.btnDownloadExcelA.LargeGlyph = global::PublicManager.Properties.Resources.printtoexcel;
            this.btnDownloadExcelA.Name = "btnDownloadExcelA";
            this.btnDownloadExcelA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDownloadExcelA_ItemClick);
            // 
            // rpMaster
            // 
            this.rpMaster.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgImportA});
            this.rpMaster.Name = "rpMaster";
            this.rpMaster.Text = "合同书";
            // 
            // rpgImportA
            // 
            this.rpgImportA.ItemLinks.Add(this.btnDownloadExcelA);
            this.rpgImportA.Name = "rpgImportA";
            this.rpgImportA.Text = "导入A";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcGrid);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1073, 434);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.txtNodeWillTime);
            this.panel3.Controls.Add(this.cbNodeWillTime);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 38);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(125, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(1067, 21);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtWillTime);
            this.panel2.Controls.Add(this.cbWillTime);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(344, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(262, 21);
            this.panel2.TabIndex = 5;
            // 
            // txtWillTime
            // 
            this.txtWillTime.CustomFormat = "yyyy年MM月dd日";
            this.txtWillTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtWillTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtWillTime.Location = new System.Drawing.Point(149, 0);
            this.txtWillTime.Name = "txtWillTime";
            this.txtWillTime.Size = new System.Drawing.Size(110, 21);
            this.txtWillTime.TabIndex = 2;
            // 
            // cbWillTime
            // 
            this.cbWillTime.AutoSize = true;
            this.cbWillTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbWillTime.Location = new System.Drawing.Point(5, 0);
            this.cbWillTime.Name = "cbWillTime";
            this.cbWillTime.Size = new System.Drawing.Size(144, 21);
            this.cbWillTime.TabIndex = 3;
            this.cbWillTime.Text = "合同书预计评估时间：";
            this.cbWillTime.UseVisualStyleBackColor = true;
            // 
            // txtNodeWillTime
            // 
            this.txtNodeWillTime.CustomFormat = "yyyy年MM月dd日";
            this.txtNodeWillTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNodeWillTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNodeWillTime.Location = new System.Drawing.Point(233, 0);
            this.txtNodeWillTime.Name = "txtNodeWillTime";
            this.txtNodeWillTime.Size = new System.Drawing.Size(111, 21);
            this.txtNodeWillTime.TabIndex = 3;
            // 
            // cbNodeWillTime
            // 
            this.cbNodeWillTime.AutoSize = true;
            this.cbNodeWillTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbNodeWillTime.Location = new System.Drawing.Point(125, 0);
            this.cbNodeWillTime.Name = "cbNodeWillTime";
            this.cbNodeWillTime.Size = new System.Drawing.Size(108, 21);
            this.cbNodeWillTime.TabIndex = 3;
            this.cbNodeWillTime.Text = "节点评估时间：";
            this.cbNodeWillTime.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportToExcel);
            this.panel1.Controls.Add(this.cbDisplayReporter);
            this.panel1.Controls.Add(this.cbDisplayContract);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 21);
            this.panel1.TabIndex = 2;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExportToExcel.Location = new System.Drawing.Point(931, 0);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(87, 21);
            this.btnExportToExcel.TabIndex = 8;
            this.btnExportToExcel.Text = "导出到Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // cbDisplayReporter
            // 
            this.cbDisplayReporter.AutoSize = true;
            this.cbDisplayReporter.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDisplayReporter.Enabled = false;
            this.cbDisplayReporter.Location = new System.Drawing.Point(823, 0);
            this.cbDisplayReporter.Name = "cbDisplayReporter";
            this.cbDisplayReporter.Size = new System.Drawing.Size(108, 21);
            this.cbDisplayReporter.TabIndex = 4;
            this.cbDisplayReporter.Text = "显示建议书内容";
            this.cbDisplayReporter.UseVisualStyleBackColor = true;
            this.cbDisplayReporter.CheckedChanged += new System.EventHandler(this.cbDisplayReporter_CheckedChanged);
            // 
            // cbDisplayContract
            // 
            this.cbDisplayContract.AutoSize = true;
            this.cbDisplayContract.Checked = true;
            this.cbDisplayContract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisplayContract.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDisplayContract.Enabled = false;
            this.cbDisplayContract.Location = new System.Drawing.Point(705, 0);
            this.cbDisplayContract.Name = "cbDisplayContract";
            this.cbDisplayContract.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.cbDisplayContract.Size = new System.Drawing.Size(118, 21);
            this.cbDisplayContract.TabIndex = 3;
            this.cbDisplayContract.Text = "显示合同书内容";
            this.cbDisplayContract.UseVisualStyleBackColor = true;
            this.cbDisplayContract.CheckedChanged += new System.EventHandler(this.cbDisplayReporter_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Location = new System.Drawing.Point(636, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 21);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKey
            // 
            this.txtKey.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtKey.Location = new System.Drawing.Point(124, 0);
            this.txtKey.Name = "txtKey";
            this.txtKey.Properties.NullValuePrompt = "请输入项目名称！";
            this.txtKey.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtKey.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtKey.Size = new System.Drawing.Size(512, 20);
            this.txtKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "搜索关键字：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rcTopBar);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1073, 557);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraBars.Ribbon.RibbonControl rcTopBar;
        private DevExpress.XtraBars.BarButtonItem btnSetSourceDir;
        private DevExpress.XtraBars.BarButtonItem btnSetDestDir;
        private DevExpress.XtraBars.BarButtonItem btnImportAll;
        private DevExpress.XtraBars.BarButtonItem btnImportWithSelected;
        private DevExpress.XtraBars.BarButtonItem btnDownloadExcelA;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMaster;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgImportA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.CheckBox cbDisplayReporter;
        private System.Windows.Forms.CheckBox cbDisplayContract;
        private System.Windows.Forms.Button btnSearch;
        private DevExpress.XtraEditors.TextEdit txtKey;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker txtNodeWillTime;
        private System.Windows.Forms.DateTimePicker txtWillTime;
        private System.Windows.Forms.CheckBox cbNodeWillTime;
        private System.Windows.Forms.CheckBox cbWillTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;

    }
}
