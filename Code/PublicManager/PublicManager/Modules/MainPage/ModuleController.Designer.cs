namespace PublicManager.Modules.MainPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.plSearchBar = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.rbNodeSearch = new System.Windows.Forms.RadioButton();
            this.rbNextMonth = new System.Windows.Forms.RadioButton();
            this.rbCurrentMonth = new System.Windows.Forms.RadioButton();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plSearchBar)).BeginInit();
            this.plSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.plSearchBar);
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 24);
            this.panel1.TabIndex = 2;
            // 
            // plSearchBar
            // 
            this.plSearchBar.Controls.Add(this.btnSearch);
            this.plSearchBar.Controls.Add(this.txtEndTime);
            this.plSearchBar.Controls.Add(this.label2);
            this.plSearchBar.Controls.Add(this.txtStartTime);
            this.plSearchBar.Controls.Add(this.label1);
            this.plSearchBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.plSearchBar.Enabled = false;
            this.plSearchBar.Location = new System.Drawing.Point(311, 0);
            this.plSearchBar.Name = "plSearchBar";
            this.plSearchBar.Size = new System.Drawing.Size(523, 24);
            this.plSearchBar.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Location = new System.Drawing.Point(441, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 20);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtEndTime
            // 
            this.txtEndTime.CustomFormat = "yyyy年MM月dd日";
            this.txtEndTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtEndTime.Location = new System.Drawing.Point(312, 2);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(129, 22);
            this.txtEndTime.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(222, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "终止时间：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStartTime
            // 
            this.txtStartTime.CustomFormat = "yyyy年MM月dd日";
            this.txtStartTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtStartTime.Location = new System.Drawing.Point(93, 2);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(129, 22);
            this.txtStartTime.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "起始时间：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.rbNodeSearch);
            this.panelControl1.Controls.Add(this.rbNextMonth);
            this.panelControl1.Controls.Add(this.rbCurrentMonth);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(311, 24);
            this.panelControl1.TabIndex = 0;
            // 
            // rbNodeSearch
            // 
            this.rbNodeSearch.AutoSize = true;
            this.rbNodeSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbNodeSearch.Location = new System.Drawing.Point(196, 2);
            this.rbNodeSearch.Name = "rbNodeSearch";
            this.rbNodeSearch.Size = new System.Drawing.Size(109, 20);
            this.rbNodeSearch.TabIndex = 2;
            this.rbNodeSearch.Text = "节点自定义查询";
            this.rbNodeSearch.UseVisualStyleBackColor = true;
            this.rbNodeSearch.CheckedChanged += new System.EventHandler(this.rbCurrentMonth_CheckedChanged);
            // 
            // rbNextMonth
            // 
            this.rbNextMonth.AutoSize = true;
            this.rbNextMonth.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbNextMonth.Location = new System.Drawing.Point(99, 2);
            this.rbNextMonth.Name = "rbNextMonth";
            this.rbNextMonth.Size = new System.Drawing.Size(97, 20);
            this.rbNextMonth.TabIndex = 1;
            this.rbNextMonth.Text = "下月节点列表";
            this.rbNextMonth.UseVisualStyleBackColor = true;
            this.rbNextMonth.CheckedChanged += new System.EventHandler(this.rbCurrentMonth_CheckedChanged);
            // 
            // rbCurrentMonth
            // 
            this.rbCurrentMonth.AutoSize = true;
            this.rbCurrentMonth.Checked = true;
            this.rbCurrentMonth.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbCurrentMonth.Location = new System.Drawing.Point(2, 2);
            this.rbCurrentMonth.Name = "rbCurrentMonth";
            this.rbCurrentMonth.Size = new System.Drawing.Size(97, 20);
            this.rbCurrentMonth.TabIndex = 0;
            this.rbCurrentMonth.TabStop = true;
            this.rbCurrentMonth.Text = "当月节点列表";
            this.rbCurrentMonth.UseVisualStyleBackColor = true;
            this.rbCurrentMonth.CheckedChanged += new System.EventHandler(this.rbCurrentMonth_CheckedChanged);
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvDetail.GridControl = this.gcData;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "项目名称";
            this.gridColumn1.FieldName = "row1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "节点";
            this.gridColumn2.FieldName = "row2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "节点时间";
            this.gridColumn3.FieldName = "row3";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "经费是否拨付";
            this.gridColumn4.FieldName = "row4";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Location = new System.Drawing.Point(3, 42);
            this.gcData.MainView = this.gvDetail;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(1182, 535);
            this.gcData.TabIndex = 3;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcData);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1188, 580);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1188, 580);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plSearchBar)).EndInit();
            this.plSearchBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.GridControl gcData;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RadioButton rbNodeSearch;
        private System.Windows.Forms.RadioButton rbNextMonth;
        private System.Windows.Forms.RadioButton rbCurrentMonth;
        private DevExpress.XtraEditors.PanelControl plSearchBar;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.DateTimePicker txtEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtStartTime;
        private System.Windows.Forms.Label label1;
    }
}
