namespace PublicManager.Modules.Reporter
{
    partial class MainView
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
            this.dgvCatalogs = new PublicManager.Modules.DataGridViewEx();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreaterUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCatalogs
            // 
            this.dgvCatalogs.AllowUserToAddRows = false;
            this.dgvCatalogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.Column1,
            this.colNumber,
            this.colName,
            this.colCreater,
            this.colCreaterUnit,
            this.colDel});
            this.dgvCatalogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCatalogs.Location = new System.Drawing.Point(0, 0);
            this.dgvCatalogs.MultiSelect = false;
            this.dgvCatalogs.Name = "dgvCatalogs";
            this.dgvCatalogs.ReadOnly = true;
            this.dgvCatalogs.RowHeadersVisible = false;
            this.dgvCatalogs.RowTemplate.Height = 23;
            this.dgvCatalogs.Size = new System.Drawing.Size(1028, 684);
            this.dgvCatalogs.TabIndex = 1;
            this.dgvCatalogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatalogs_CellContentClick);
            // 
            // colIndex
            // 
            this.colIndex.HeaderText = "序号";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "版本";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // colNumber
            // 
            this.colNumber.HeaderText = "项目编号";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "项目名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colCreater
            // 
            this.colCreater.HeaderText = "申请人";
            this.colCreater.Name = "colCreater";
            this.colCreater.ReadOnly = true;
            // 
            // colCreaterUnit
            // 
            this.colCreaterUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCreaterUnit.HeaderText = "申请人单位";
            this.colCreaterUnit.Name = "colCreaterUnit";
            this.colCreaterUnit.ReadOnly = true;
            // 
            // colDel
            // 
            this.colDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDel.HeaderText = "";
            this.colDel.Name = "colDel";
            this.colDel.ReadOnly = true;
            this.colDel.Text = "删除";
            this.colDel.UseColumnTextForButtonValue = true;
            this.colDel.Width = 5;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCatalogs);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1028, 684);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PublicManager.Modules.DataGridViewEx dgvCatalogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreater;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreaterUnit;
        private System.Windows.Forms.DataGridViewButtonColumn colDel;


    }
}
