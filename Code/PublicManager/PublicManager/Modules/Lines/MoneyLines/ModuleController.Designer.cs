namespace PublicManager.Modules.Lines.MoneyLines
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
            this.plContent = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvProjectList = new PublicManager.Modules.TreeViewWithSearch();
            this.moneyLinePage1 = new PublicManager.Modules.Lines.MoneyLines.MoneyLinePage();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.moneyLinePage1);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 0);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(782, 568);
            this.plContent.TabIndex = 0;
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
            this.splitContainer1.Panel2.Controls.Add(this.plContent);
            this.splitContainer1.Size = new System.Drawing.Size(1070, 568);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 5;
            // 
            // tvProjectList
            // 
            this.tvProjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProjectList.FocusNodeBackColor = System.Drawing.Color.Crimson;
            this.tvProjectList.FocusNodeFontColor = System.Drawing.Color.White;
            this.tvProjectList.Font = new System.Drawing.Font("仿宋", 12F);
            this.tvProjectList.Location = new System.Drawing.Point(0, 0);
            this.tvProjectList.Margin = new System.Windows.Forms.Padding(4);
            this.tvProjectList.Name = "tvProjectList";
            this.tvProjectList.NoFocusNodeBackColor = System.Drawing.Color.White;
            this.tvProjectList.NoFocusNodeFontColor = System.Drawing.Color.Black;
            this.tvProjectList.Size = new System.Drawing.Size(284, 568);
            this.tvProjectList.TabIndex = 1;
            // 
            // moneyLinePage1
            // 
            this.moneyLinePage1.BackColor = System.Drawing.Color.White;
            this.moneyLinePage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moneyLinePage1.Location = new System.Drawing.Point(0, 0);
            this.moneyLinePage1.Name = "moneyLinePage1";
            this.moneyLinePage1.Size = new System.Drawing.Size(782, 568);
            this.moneyLinePage1.TabIndex = 0;
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1070, 568);
            this.plContent.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private TreeViewWithSearch tvProjectList;
        private MoneyLinePage moneyLinePage1;

    }
}
