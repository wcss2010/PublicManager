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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.srpSearch = new PublicManager.Modules.SearchRulePanel();
            this.rcTopBar = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.htnDownloadTemplete = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportExcelWithTeams = new DevExpress.XtraBars.BarButtonItem();
            this.rpMaster = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpbLoad = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).BeginInit();
            this.SuspendLayout();
            // 
            // gcGrid
            // 
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGrid.Location = new System.Drawing.Point(3, 75);
            this.gcGrid.MainView = this.gvDetail;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gcGrid.Size = new System.Drawing.Size(1246, 427);
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
            this.gvDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
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
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "评估等级";
            this.gridColumn9.FieldName = "row10";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "评估专家";
            this.gridColumn8.FieldName = "row11";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "经费金额(万元)";
            this.gridColumn4.FieldName = "row4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "备注";
            this.gridColumn5.FieldName = "row5";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "row6";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "...";
            this.gridColumn12.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn12.FieldName = "row12";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "从Excel导入数据", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcGrid);
            this.groupBox1.Controls.Add(this.srpSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1252, 505);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // srpSearch
            // 
            this.srpSearch.CustomButtonsNames = "结果内容搜索;列选择器";
            this.srpSearch.DisplayGridControl = this.gcGrid;
            this.srpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.srpSearch.IsDisplayCatalogTypePanel = false;
            this.srpSearch.IsDisplayCheckListPanel = false;
            this.srpSearch.IsDisplayContractData = true;
            this.srpSearch.IsDisplayCustomButtonPanel = true;
            this.srpSearch.IsDisplayKey1Panel = true;
            this.srpSearch.IsDisplayKey2Panel = false;
            this.srpSearch.IsDisplayKey3OR4Panel = true;
            this.srpSearch.IsDisplayKey3Panel = true;
            this.srpSearch.IsDisplayKey4Panel = true;
            this.srpSearch.IsDisplayReporterData = false;
            this.srpSearch.Key1FieldString = "项目名称";
            this.srpSearch.Key1PanelWidth = 350;
            this.srpSearch.Key2PanelWidth = 547;
            this.srpSearch.Key3OR4PanelWidth = 694;
            this.srpSearch.Key3PanelWidth = 275;
            this.srpSearch.Key4PanelWidth = 275;
            this.srpSearch.Location = new System.Drawing.Point(3, 18);
            this.srpSearch.Name = "srpSearch";
            this.srpSearch.RightButtonPanelWidth = 325;
            this.srpSearch.Size = new System.Drawing.Size(1246, 57);
            this.srpSearch.TabIndex = 7;
            this.srpSearch.OnSearchClick += new PublicManager.Modules.SearchClickDelegate(this.srpSearch_OnSearchClick);
            this.srpSearch.OnResetClick += new PublicManager.Modules.ResetClickDelegate(this.srpSearch_OnResetClick);
            this.srpSearch.OnExportToClick += new PublicManager.Modules.ExportToClickDelegate(this.srpSearch_OnExportToClick);
            this.srpSearch.OnCustomButtonClick += new PublicManager.Modules.CustomButtonClickDelegate(this.srpSearch_OnCustomButtonClick);
            // 
            // rcTopBar
            // 
            this.rcTopBar.ExpandCollapseItem.Id = 0;
            this.rcTopBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcTopBar.ExpandCollapseItem,
            this.htnDownloadTemplete,
            this.btnImportExcel,
            this.btnImportExcelWithTeams});
            this.rcTopBar.Location = new System.Drawing.Point(0, 0);
            this.rcTopBar.MaxItemId = 6;
            this.rcTopBar.Name = "rcTopBar";
            this.rcTopBar.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpMaster});
            this.rcTopBar.Size = new System.Drawing.Size(1252, 145);
            this.rcTopBar.Visible = false;
            // 
            // htnDownloadTemplete
            // 
            this.htnDownloadTemplete.Caption = "下载节点模板";
            this.htnDownloadTemplete.Id = 2;
            this.htnDownloadTemplete.LargeGlyph = global::PublicManager.Properties.Resources.printtoexcel;
            this.htnDownloadTemplete.Name = "htnDownloadTemplete";
            this.htnDownloadTemplete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.htnDownloadTemplete_ItemClick);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Caption = "数据导入";
            this.btnImportExcel.Id = 3;
            this.btnImportExcel.LargeGlyph = global::PublicManager.Properties.Resources.importA;
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportExcel_ItemClick);
            // 
            // btnImportExcelWithTeams
            // 
            this.btnImportExcelWithTeams.Caption = "批量数据导入";
            this.btnImportExcelWithTeams.Id = 4;
            this.btnImportExcelWithTeams.LargeGlyph = global::PublicManager.Properties.Resources.importB;
            this.btnImportExcelWithTeams.Name = "btnImportExcelWithTeams";
            this.btnImportExcelWithTeams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportExcelWithTeams_ItemClick);
            // 
            // rpMaster
            // 
            this.rpMaster.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpbLoad});
            this.rpMaster.Name = "rpMaster";
            this.rpMaster.Text = "节点评估管理";
            // 
            // rpbLoad
            // 
            this.rpbLoad.ItemLinks.Add(this.htnDownloadTemplete);
            this.rpbLoad.ItemLinks.Add(this.btnImportExcel);
            this.rpbLoad.ItemLinks.Add(this.btnImportExcelWithTeams);
            this.rpbLoad.Name = "rpbLoad";
            this.rpbLoad.Text = "其它";
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rcTopBar);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1252, 650);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private SearchRulePanel srpSearch;
        private DevExpress.XtraBars.Ribbon.RibbonControl rcTopBar;
        private DevExpress.XtraBars.BarButtonItem htnDownloadTemplete;
        private DevExpress.XtraBars.BarButtonItem btnImportExcel;
        private DevExpress.XtraBars.BarButtonItem btnImportExcelWithTeams;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMaster;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpbLoad;

    }
}
