namespace PublicManager.Modules.DataCheck.MoneyCheck
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvProjectList = new PublicManager.Modules.TreeViewWithSearch();
            this.xtcData = new DevExpress.XtraTab.XtraTabControl();
            this.tpTag1 = new DevExpress.XtraTab.XtraTabPage();
            this.tpTag2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcGridForSubject = new DevExpress.XtraGrid.GridControl();
            this.gvDetailForSubject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpTag3 = new DevExpress.XtraTab.XtraTabPage();
            this.gcGridForUnit = new DevExpress.XtraGrid.GridControl();
            this.gvDetailForUnit = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcData)).BeginInit();
            this.xtcData.SuspendLayout();
            this.tpTag2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGridForSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetailForSubject)).BeginInit();
            this.tpTag3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGridForUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetailForUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvProjectList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xtcData);
            this.splitContainer1.Size = new System.Drawing.Size(1127, 665);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // tvProjectList
            // 
            this.tvProjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProjectList.Font = new System.Drawing.Font("仿宋", 12F);
            this.tvProjectList.Location = new System.Drawing.Point(0, 0);
            this.tvProjectList.Margin = new System.Windows.Forms.Padding(5);
            this.tvProjectList.Name = "tvProjectList";
            this.tvProjectList.Size = new System.Drawing.Size(299, 665);
            this.tvProjectList.TabIndex = 1;
            // 
            // xtcData
            // 
            this.xtcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcData.Location = new System.Drawing.Point(0, 0);
            this.xtcData.Name = "xtcData";
            this.xtcData.SelectedTabPage = this.tpTag1;
            this.xtcData.Size = new System.Drawing.Size(823, 665);
            this.xtcData.TabIndex = 0;
            this.xtcData.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpTag1,
            this.tpTag2,
            this.tpTag3});
            // 
            // tpTag1
            // 
            this.tpTag1.Name = "tpTag1";
            this.tpTag1.PageVisible = false;
            this.tpTag1.Size = new System.Drawing.Size(817, 636);
            this.tpTag1.Text = "经费预算";
            // 
            // tpTag2
            // 
            this.tpTag2.Controls.Add(this.gcGridForSubject);
            this.tpTag2.Name = "tpTag2";
            this.tpTag2.Size = new System.Drawing.Size(817, 636);
            this.tpTag2.Text = "课题节点经费预算";
            // 
            // gcGridForSubject
            // 
            this.gcGridForSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGridForSubject.Location = new System.Drawing.Point(0, 0);
            this.gcGridForSubject.MainView = this.gvDetailForSubject;
            this.gcGridForSubject.Name = "gcGridForSubject";
            this.gcGridForSubject.Size = new System.Drawing.Size(817, 636);
            this.gcGridForSubject.TabIndex = 6;
            this.gcGridForSubject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetailForSubject});
            // 
            // gvDetailForSubject
            // 
            this.gvDetailForSubject.GridControl = this.gcGridForSubject;
            this.gvDetailForSubject.Name = "gvDetailForSubject";
            this.gvDetailForSubject.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gvDetailForSubject.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvDetailForSubject_RowCellStyle);
            // 
            // tpTag3
            // 
            this.tpTag3.Controls.Add(this.gcGridForUnit);
            this.tpTag3.Name = "tpTag3";
            this.tpTag3.Size = new System.Drawing.Size(817, 636);
            this.tpTag3.Text = "单位节点经费预算";
            // 
            // gcGridForUnit
            // 
            this.gcGridForUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGridForUnit.Location = new System.Drawing.Point(0, 0);
            this.gcGridForUnit.MainView = this.gvDetailForUnit;
            this.gcGridForUnit.Name = "gcGridForUnit";
            this.gcGridForUnit.Size = new System.Drawing.Size(817, 636);
            this.gcGridForUnit.TabIndex = 5;
            this.gcGridForUnit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetailForUnit});
            // 
            // gvDetailForUnit
            // 
            this.gvDetailForUnit.GridControl = this.gcGridForUnit;
            this.gvDetailForUnit.Name = "gvDetailForUnit";
            this.gvDetailForUnit.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gvDetailForUnit.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvDetailForUnit_RowCellStyle);
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1127, 665);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtcData)).EndInit();
            this.xtcData.ResumeLayout(false);
            this.tpTag2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGridForSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetailForSubject)).EndInit();
            this.tpTag3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGridForUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetailForUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private TreeViewWithSearch tvProjectList;
        private DevExpress.XtraTab.XtraTabControl xtcData;
        private DevExpress.XtraTab.XtraTabPage tpTag1;
        private DevExpress.XtraTab.XtraTabPage tpTag2;
        private DevExpress.XtraTab.XtraTabPage tpTag3;
        private DevExpress.XtraGrid.GridControl gcGridForSubject;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetailForSubject;
        private DevExpress.XtraGrid.GridControl gcGridForUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetailForUnit;
    }
}
