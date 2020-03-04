namespace PublicManager.Modules.Lines.MoneyRequest
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
            this.tcMoneyTables = new System.Windows.Forms.TabControl();
            this.tpProjectMoney = new System.Windows.Forms.TabPage();
            this.moneyTableControl1 = new PublicManager.Modules.Lines.MoneyRequest.MoneyTableControl();
            this.tcMoneyTables.SuspendLayout();
            this.tpProjectMoney.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMoneyTables
            // 
            this.tcMoneyTables.Controls.Add(this.tpProjectMoney);
            this.tcMoneyTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMoneyTables.Location = new System.Drawing.Point(0, 0);
            this.tcMoneyTables.Name = "tcMoneyTables";
            this.tcMoneyTables.SelectedIndex = 0;
            this.tcMoneyTables.Size = new System.Drawing.Size(1072, 559);
            this.tcMoneyTables.TabIndex = 0;
            // 
            // tpProjectMoney
            // 
            this.tpProjectMoney.Controls.Add(this.moneyTableControl1);
            this.tpProjectMoney.Location = new System.Drawing.Point(4, 22);
            this.tpProjectMoney.Name = "tpProjectMoney";
            this.tpProjectMoney.Padding = new System.Windows.Forms.Padding(3);
            this.tpProjectMoney.Size = new System.Drawing.Size(1064, 533);
            this.tpProjectMoney.TabIndex = 0;
            this.tpProjectMoney.Text = "项目经费预算";
            this.tpProjectMoney.UseVisualStyleBackColor = true;
            // 
            // moneyTableControl1
            // 
            this.moneyTableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moneyTableControl1.Location = new System.Drawing.Point(3, 3);
            this.moneyTableControl1.Name = "moneyTableControl1";
            this.moneyTableControl1.Size = new System.Drawing.Size(1058, 527);
            this.moneyTableControl1.TabIndex = 0;
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcMoneyTables);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1072, 559);
            this.tcMoneyTables.ResumeLayout(false);
            this.tpProjectMoney.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMoneyTables;
        private System.Windows.Forms.TabPage tpProjectMoney;
        private MoneyTableControl moneyTableControl1;

    }
}
