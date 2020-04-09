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
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpTag3 = new DevExpress.XtraTab.XtraTabPage();
            this.gcGridForUnit = new DevExpress.XtraGrid.GridControl();
            this.gvDetailForUnit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.tvProjectList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.tpTag1.Size = new System.Drawing.Size(817, 636);
            this.tpTag1.Text = "经费预算";
            // 
            // tpTag2
            // 
            this.tpTag2.Controls.Add(this.gcGridForSubject);
            this.tpTag2.Name = "tpTag2";
            this.tpTag2.Size = new System.Drawing.Size(817, 636);
            this.tpTag2.Text = "课题年度经费预算";
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
            this.gvDetailForSubject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvDetailForSubject.GridControl = this.gcGridForSubject;
            this.gvDetailForSubject.Name = "gvDetailForSubject";
            this.gvDetailForSubject.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "名称";
            this.gridColumn1.FieldName = "row1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "第一年度";
            this.gridColumn2.FieldName = "row2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "第二年度";
            this.gridColumn3.FieldName = "row3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "第三年度";
            this.gridColumn4.FieldName = "row4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "第四年度";
            this.gridColumn5.FieldName = "row5";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "第五年度";
            this.gridColumn6.FieldName = "row6";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "合计";
            this.gridColumn7.FieldName = "row7";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // tpTag3
            // 
            this.tpTag3.Controls.Add(this.gcGridForUnit);
            this.tpTag3.Name = "tpTag3";
            this.tpTag3.Size = new System.Drawing.Size(817, 636);
            this.tpTag3.Text = "单位年度经费预算";
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
            this.gvDetailForUnit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gvDetailForUnit.GridControl = this.gcGridForUnit;
            this.gvDetailForUnit.Name = "gvDetailForUnit";
            this.gvDetailForUnit.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "名称";
            this.gridColumn8.FieldName = "row1";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "第一年度";
            this.gridColumn9.FieldName = "row2";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "第二年度";
            this.gridColumn10.FieldName = "row3";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "第三年度";
            this.gridColumn11.FieldName = "row4";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "第四年度";
            this.gridColumn12.FieldName = "row5";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "第五年度";
            this.gridColumn13.FieldName = "row6";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "合计";
            this.gridColumn14.FieldName = "row7";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.GridControl gcGridForUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetailForUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}
