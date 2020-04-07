namespace PublicManager.Modules.CustomReporter
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.dgvSub = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportTo = new System.Windows.Forms.Button();
            this.cbDisplayReporter = new System.Windows.Forms.CheckBox();
            this.cbDisplayContract = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKey = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.plOutputHeaderList = new System.Windows.Forms.FlowLayoutPanel();
            this.plMasterHeader = new DevExpress.XtraEditors.GroupControl();
            this.fplProject = new System.Windows.Forms.FlowLayoutPanel();
            this.plDetailHeader = new DevExpress.XtraEditors.GroupControl();
            this.fplSubject = new System.Windows.Forms.FlowLayoutPanel();
            this.rcTopBar = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSetSourceDir = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetDestDir = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportWithSelected = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.rpMaster = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            this.plOutputHeaderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plMasterHeader)).BeginInit();
            this.plMasterHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plDetailHeader)).BeginInit();
            this.plDetailHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSub
            // 
            this.dgvSub.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn25,
            this.gridColumn24,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.dgvSub.GridControl = this.gcGrid;
            this.dgvSub.Name = "dgvSub";
            this.dgvSub.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "课题名称";
            this.gridColumn15.FieldName = "row1";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "课题负责人";
            this.gridColumn16.FieldName = "row2";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "课题负责人座机";
            this.gridColumn25.FieldName = "row7";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 2;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "课题负责人手机";
            this.gridColumn24.FieldName = "row8";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 3;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "课题负责单位";
            this.gridColumn17.FieldName = "row3";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 4;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "所属大单位";
            this.gridColumn18.FieldName = "row4";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 5;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "单位地址";
            this.gridColumn19.FieldName = "row5";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 6;
            // 
            // gcGrid
            // 
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.dgvSub;
            gridLevelNode1.RelationName = "SubjectView";
            this.gcGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcGrid.Location = new System.Drawing.Point(0, 26);
            this.gcGrid.MainView = this.dgvDetail;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.Size = new System.Drawing.Size(1421, 227);
            this.gcGrid.TabIndex = 5;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail,
            this.dgvSub});
            // 
            // dgvDetail
            // 
            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn20,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn21,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn26,
            this.gridColumn23,
            this.gridColumn22,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32});
            this.dgvDetail.GridControl = this.gcGrid;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.dgvDetail_MasterRowExpanded);
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "ProjectID";
            this.gridColumn20.FieldName = "row15";
            this.gridColumn20.Name = "gridColumn20";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "版本";
            this.gridColumn1.FieldName = "row1";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "类型";
            this.gridColumn2.FieldName = "row2";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "项目编号";
            this.gridColumn5.FieldName = "row5";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "项目领域";
            this.gridColumn3.FieldName = "row3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 70;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "项目名称";
            this.gridColumn6.FieldName = "row6";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "项目关键词";
            this.gridColumn21.FieldName = "row16";
            this.gridColumn21.Name = "gridColumn21";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "总经费(万元)";
            this.gridColumn7.FieldName = "row7";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 70;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "周期";
            this.gridColumn8.FieldName = "row8";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 70;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "密级";
            this.gridColumn9.FieldName = "row9";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "计划批次";
            this.gridColumn4.FieldName = "row4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 70;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "项目负责人";
            this.gridColumn10.FieldName = "row10";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 70;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "项目牵头单位";
            this.gridColumn11.FieldName = "row11";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 101;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "项目负责人职务/职称";
            this.gridColumn26.FieldName = "row19";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 9;
            this.gridColumn26.Width = 111;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "项目负责人座机";
            this.gridColumn23.FieldName = "row17";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 10;
            this.gridColumn23.Width = 109;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "项目负责人手机";
            this.gridColumn22.FieldName = "row18";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 11;
            this.gridColumn22.Width = 105;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "牵头单位所属大单位";
            this.gridColumn12.FieldName = "row12";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            this.gridColumn12.Width = 58;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "牵头单位地址";
            this.gridColumn13.FieldName = "row13";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 13;
            this.gridColumn13.Width = 93;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "研究内容与目标";
            this.gridColumn14.FieldName = "row14";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "选题评议";
            this.gridColumn27.FieldName = "row20";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 14;
            this.gridColumn27.Width = 39;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "立项审核";
            this.gridColumn28.FieldName = "row21";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 15;
            this.gridColumn28.Width = 39;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "立项复议";
            this.gridColumn29.FieldName = "row22";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 16;
            this.gridColumn29.Width = 39;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "合同审查等级";
            this.gridColumn30.FieldName = "row23";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 17;
            this.gridColumn30.Width = 39;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "合同审核等级";
            this.gridColumn31.FieldName = "row24";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 18;
            this.gridColumn31.Width = 39;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "备注";
            this.gridColumn32.FieldName = "row25";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 19;
            this.gridColumn32.Width = 71;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1427, 534);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 18);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcGrid);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.plOutputHeaderList);
            this.splitContainer1.Size = new System.Drawing.Size(1421, 513);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportTo);
            this.panel1.Controls.Add(this.cbDisplayReporter);
            this.panel1.Controls.Add(this.cbDisplayContract);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1421, 26);
            this.panel1.TabIndex = 3;
            // 
            // btnExportTo
            // 
            this.btnExportTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExportTo.Location = new System.Drawing.Point(1046, 0);
            this.btnExportTo.Name = "btnExportTo";
            this.btnExportTo.Size = new System.Drawing.Size(101, 26);
            this.btnExportTo.TabIndex = 8;
            this.btnExportTo.Text = "导出到Excel";
            this.btnExportTo.UseVisualStyleBackColor = true;
            this.btnExportTo.Click += new System.EventHandler(this.btnExportTo_Click);
            // 
            // cbDisplayReporter
            // 
            this.cbDisplayReporter.AutoSize = true;
            this.cbDisplayReporter.Checked = true;
            this.cbDisplayReporter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisplayReporter.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDisplayReporter.Location = new System.Drawing.Point(936, 0);
            this.cbDisplayReporter.Name = "cbDisplayReporter";
            this.cbDisplayReporter.Size = new System.Drawing.Size(110, 26);
            this.cbDisplayReporter.TabIndex = 6;
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
            this.cbDisplayContract.Location = new System.Drawing.Point(814, 0);
            this.cbDisplayContract.Name = "cbDisplayContract";
            this.cbDisplayContract.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.cbDisplayContract.Size = new System.Drawing.Size(122, 26);
            this.cbDisplayContract.TabIndex = 5;
            this.cbDisplayContract.Text = "显示合同书内容";
            this.cbDisplayContract.UseVisualStyleBackColor = true;
            this.cbDisplayContract.CheckedChanged += new System.EventHandler(this.cbDisplayReporter_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Location = new System.Drawing.Point(727, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKey
            // 
            this.txtKey.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtKey.Location = new System.Drawing.Point(155, 0);
            this.txtKey.Name = "txtKey";
            this.txtKey.Properties.NullValuePrompt = "请输入项目名称、计划批次！";
            this.txtKey.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtKey.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtKey.Size = new System.Drawing.Size(572, 20);
            this.txtKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "搜索关键字：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // plOutputHeaderList
            // 
            this.plOutputHeaderList.Controls.Add(this.plMasterHeader);
            this.plOutputHeaderList.Controls.Add(this.plDetailHeader);
            this.plOutputHeaderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plOutputHeaderList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.plOutputHeaderList.Location = new System.Drawing.Point(0, 0);
            this.plOutputHeaderList.Name = "plOutputHeaderList";
            this.plOutputHeaderList.Size = new System.Drawing.Size(1421, 255);
            this.plOutputHeaderList.TabIndex = 0;
            this.plOutputHeaderList.SizeChanged += new System.EventHandler(this.plOutputHeaderList_SizeChanged);
            // 
            // plMasterHeader
            // 
            this.plMasterHeader.Controls.Add(this.fplProject);
            this.plMasterHeader.Location = new System.Drawing.Point(3, 3);
            this.plMasterHeader.Name = "plMasterHeader";
            this.plMasterHeader.Size = new System.Drawing.Size(851, 121);
            this.plMasterHeader.TabIndex = 2;
            this.plMasterHeader.Text = "项目基本信息要素";
            // 
            // fplProject
            // 
            this.fplProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fplProject.Location = new System.Drawing.Point(2, 21);
            this.fplProject.Name = "fplProject";
            this.fplProject.Size = new System.Drawing.Size(847, 98);
            this.fplProject.TabIndex = 0;
            // 
            // plDetailHeader
            // 
            this.plDetailHeader.Controls.Add(this.fplSubject);
            this.plDetailHeader.Location = new System.Drawing.Point(3, 130);
            this.plDetailHeader.Name = "plDetailHeader";
            this.plDetailHeader.Size = new System.Drawing.Size(851, 122);
            this.plDetailHeader.TabIndex = 1;
            this.plDetailHeader.Text = "课题要素";
            // 
            // fplSubject
            // 
            this.fplSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fplSubject.Location = new System.Drawing.Point(2, 21);
            this.fplSubject.Name = "fplSubject";
            this.fplSubject.Size = new System.Drawing.Size(847, 99);
            this.fplSubject.TabIndex = 0;
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
            this.btnExportToExcel});
            this.rcTopBar.Location = new System.Drawing.Point(0, 0);
            this.rcTopBar.MaxItemId = 6;
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
            this.rcTopBar.Size = new System.Drawing.Size(1427, 123);
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
            // btnExportToExcel
            // 
            this.btnExportToExcel.Caption = "年度经费汇总信息导出";
            this.btnExportToExcel.Id = 5;
            this.btnExportToExcel.LargeGlyph = global::PublicManager.Properties.Resources.printtoexcel;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportToExcel_ItemClick);
            // 
            // rpMaster
            // 
            this.rpMaster.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgExport});
            this.rpMaster.Name = "rpMaster";
            this.rpMaster.Text = "合同书";
            // 
            // rpgExport
            // 
            this.rpgExport.ItemLinks.Add(this.btnExportToExcel);
            this.rpgExport.Name = "rpgExport";
            this.rpgExport.Text = "导出";
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rcTopBar);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1427, 657);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            this.plOutputHeaderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plMasterHeader)).EndInit();
            this.plMasterHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plDetailHeader)).EndInit();
            this.plDetailHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraBars.Ribbon.RibbonControl rcTopBar;
        private DevExpress.XtraBars.BarButtonItem btnSetSourceDir;
        private DevExpress.XtraBars.BarButtonItem btnSetDestDir;
        private DevExpress.XtraBars.BarButtonItem btnImportAll;
        private DevExpress.XtraBars.BarButtonItem btnImportWithSelected;
        private DevExpress.XtraBars.BarButtonItem btnExportToExcel;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMaster;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportTo;
        private System.Windows.Forms.CheckBox cbDisplayReporter;
        private System.Windows.Forms.CheckBox cbDisplayContract;
        private System.Windows.Forms.Button btnSearch;
        private DevExpress.XtraEditors.TextEdit txtKey;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvSub;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private System.Windows.Forms.FlowLayoutPanel plOutputHeaderList;
        private DevExpress.XtraEditors.GroupControl plMasterHeader;
        private DevExpress.XtraEditors.GroupControl plDetailHeader;
        private System.Windows.Forms.FlowLayoutPanel fplProject;
        private System.Windows.Forms.FlowLayoutPanel fplSubject;
    }
}
