﻿namespace PublicManager.Modules.Lines.MoneyRequest
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
            this.tvProjectList = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMoneyTables
            // 
            this.tcMoneyTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMoneyTables.Location = new System.Drawing.Point(0, 0);
            this.tcMoneyTables.Name = "tcMoneyTables";
            this.tcMoneyTables.SelectedIndex = 0;
            this.tcMoneyTables.Size = new System.Drawing.Size(782, 559);
            this.tcMoneyTables.TabIndex = 0;
            // 
            // tvProjectList
            // 
            this.tvProjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProjectList.Location = new System.Drawing.Point(0, 0);
            this.tvProjectList.Name = "tvProjectList";
            this.tvProjectList.Size = new System.Drawing.Size(286, 559);
            this.tvProjectList.TabIndex = 1;
            this.tvProjectList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProjectList_AfterSelect);
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
            this.splitContainer1.Panel2.Controls.Add(this.tcMoneyTables);
            this.splitContainer1.Size = new System.Drawing.Size(1072, 559);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 2;
            // 
            // ModuleController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ModuleController";
            this.Size = new System.Drawing.Size(1072, 559);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMoneyTables;
        private System.Windows.Forms.TreeView tvProjectList;
        private System.Windows.Forms.SplitContainer splitContainer1;

    }
}
