namespace PublicManager.Modules.Lines.MoneyLines
{
    partial class MoneyLinePage2
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
            this.plMain = new DevExpress.XtraEditors.GroupControl();
            this.plTop = new DevExpress.XtraEditors.PanelControl();
            this.plContent = new DevExpress.XtraEditors.GroupControl();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTag4 = new System.Windows.Forms.Label();
            this.lblTag2 = new System.Windows.Forms.Label();
            this.lblTag1 = new System.Windows.Forms.Label();
            this.lblTag3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).BeginInit();
            this.plMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plTop)).BeginInit();
            this.plTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plContent)).BeginInit();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.plContent);
            this.plMain.Controls.Add(this.plTop);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1000, 567);
            this.plMain.TabIndex = 0;
            this.plMain.Text = "项目经费总体收支情况(节点X)";
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.lblTag4);
            this.plTop.Controls.Add(this.label5);
            this.plTop.Controls.Add(this.lblTag3);
            this.plTop.Controls.Add(this.label4);
            this.plTop.Controls.Add(this.lblTag2);
            this.plTop.Controls.Add(this.label3);
            this.plTop.Controls.Add(this.lblTag1);
            this.plTop.Controls.Add(this.label1);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(2, 21);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(996, 29);
            this.plTop.TabIndex = 0;
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.gcGrid);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(2, 50);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(996, 515);
            this.plContent.TabIndex = 1;
            this.plContent.Text = "项目经费预算及支出情况";
            // 
            // gcGrid
            // 
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGrid.Location = new System.Drawing.Point(2, 21);
            this.gcGrid.MainView = this.dgvDetail;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.Size = new System.Drawing.Size(992, 492);
            this.gcGrid.TabIndex = 5;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail});
            // 
            // dgvDetail
            // 
            this.dgvDetail.GridControl = this.gcGrid;
            this.dgvDetail.Name = "dgvDetail";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "合同价款";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(190, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "累计预算经费";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(378, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "累计到位经费";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(566, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "累计支出经费";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTag4
            // 
            this.lblTag4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTag4.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTag4.Location = new System.Drawing.Point(660, 2);
            this.lblTag4.Margin = new System.Windows.Forms.Padding(1);
            this.lblTag4.Name = "lblTag4";
            this.lblTag4.Size = new System.Drawing.Size(94, 25);
            this.lblTag4.TabIndex = 6;
            this.lblTag4.Text = "空";
            this.lblTag4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTag2
            // 
            this.lblTag2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTag2.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTag2.Location = new System.Drawing.Point(284, 2);
            this.lblTag2.Margin = new System.Windows.Forms.Padding(1);
            this.lblTag2.Name = "lblTag2";
            this.lblTag2.Size = new System.Drawing.Size(94, 25);
            this.lblTag2.TabIndex = 7;
            this.lblTag2.Text = "空";
            this.lblTag2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTag1
            // 
            this.lblTag1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTag1.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTag1.Location = new System.Drawing.Point(96, 2);
            this.lblTag1.Margin = new System.Windows.Forms.Padding(1);
            this.lblTag1.Name = "lblTag1";
            this.lblTag1.Size = new System.Drawing.Size(94, 25);
            this.lblTag1.TabIndex = 8;
            this.lblTag1.Text = "空";
            this.lblTag1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTag3
            // 
            this.lblTag3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTag3.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTag3.Location = new System.Drawing.Point(472, 2);
            this.lblTag3.Margin = new System.Windows.Forms.Padding(1);
            this.lblTag3.Name = "lblTag3";
            this.lblTag3.Size = new System.Drawing.Size(94, 25);
            this.lblTag3.TabIndex = 9;
            this.lblTag3.Text = "空";
            this.lblTag3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MoneyLinePage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plMain);
            this.Name = "MoneyLinePage2";
            this.Size = new System.Drawing.Size(1000, 567);
            ((System.ComponentModel.ISupportInitialize)(this.plMain)).EndInit();
            this.plMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plTop)).EndInit();
            this.plTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plContent)).EndInit();
            this.plContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl plMain;
        private DevExpress.XtraEditors.PanelControl plTop;
        private DevExpress.XtraEditors.GroupControl plContent;
        private DevExpress.XtraGrid.GridControl gcGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTag4;
        private System.Windows.Forms.Label lblTag2;
        private System.Windows.Forms.Label lblTag1;
        private System.Windows.Forms.Label lblTag3;
    }
}
