namespace PublicManager.Modules.DataLoad.NormalUnitDict
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rcTopBar = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rpMaster = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpbLoad = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDownloadExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoadExcel = new DevExpress.XtraBars.BarButtonItem();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1414, 0);
            this.panel1.TabIndex = 2;
            // 
            // gcGrid
            // 
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGrid.Location = new System.Drawing.Point(3, 163);
            this.gcGrid.MainView = this.dgvDetail;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.gcGrid.Size = new System.Drawing.Size(1414, 513);
            this.gcGrid.TabIndex = 4;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail});
            // 
            // dgvDetail
            // 
            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.dgvDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.dgvDetail.GridControl = this.gcGrid;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.dgvDetail.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.dgvDetail_RowCellClick);
            this.dgvDetail.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.dgvDetail_RowCellStyle);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcGrid);
            this.groupBox1.Controls.Add(this.rcTopBar);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1420, 679);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rcTopBar
            // 
            this.rcTopBar.ExpandCollapseItem.Id = 0;
            this.rcTopBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcTopBar.ExpandCollapseItem,
            this.btnDownloadExcel,
            this.btnLoadExcel});
            this.rcTopBar.Location = new System.Drawing.Point(3, 18);
            this.rcTopBar.MaxItemId = 11;
            this.rcTopBar.Name = "rcTopBar";
            this.rcTopBar.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpMaster});
            this.rcTopBar.Size = new System.Drawing.Size(1414, 145);
            this.rcTopBar.Visible = false;
            // 
            // rpMaster
            // 
            this.rpMaster.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpbLoad});
            this.rpMaster.Name = "rpMaster";
            this.rpMaster.Text = "归一化单位字典";
            // 
            // rpbLoad
            // 
            this.rpbLoad.ItemLinks.Add(this.btnDownloadExcel);
            this.rpbLoad.ItemLinks.Add(this.btnLoadExcel);
            this.rpbLoad.Name = "rpbLoad";
            this.rpbLoad.Text = "其它";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "单位法人名称";
            this.gridColumn1.FieldName = "row1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 349;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "归一化名称";
            this.gridColumn2.FieldName = "row2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 963;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "DictID";
            this.gridColumn3.FieldName = "row3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // btnDownloadExcel
            // 
            this.btnDownloadExcel.Caption = "下载导入模板";
            this.btnDownloadExcel.Id = 6;
            this.btnDownloadExcel.LargeGlyph = global::PublicManager.Properties.Resources.printtoexcel;
            this.btnDownloadExcel.Name = "btnDownloadExcel";
            this.btnDownloadExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDownloadExcel_ItemClick);
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Caption = "从Excel导入";
            this.btnLoadExcel.Id = 7;
            this.btnLoadExcel.LargeGlyph = global::PublicManager.Properties.Resources.importA;
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoadExcel_ItemClick);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "...";
            this.gridColumn4.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn4.FieldName = "row4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 35;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "...";
            this.gridColumn5.ColumnEdit = this.repositoryItemButtonEdit2;
            this.gridColumn5.FieldName = "row5";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 31;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "删除", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "编辑", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16, "", null, null, true)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1420, 679);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraBars.Ribbon.RibbonControl rcTopBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMaster;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpbLoad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraBars.BarButtonItem btnDownloadExcel;
        private DevExpress.XtraBars.BarButtonItem btnLoadExcel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
    }
}
