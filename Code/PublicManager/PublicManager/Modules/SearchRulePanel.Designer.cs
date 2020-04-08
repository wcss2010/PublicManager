namespace PublicManager.Modules
{
    partial class SearchRulePanel
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
            this.plRules = new DevExpress.XtraEditors.GroupControl();
            this.tplControls = new System.Windows.Forms.TableLayoutPanel();
            this.txtKey1 = new DevExpress.XtraEditors.TextEdit();
            this.plCatalogType = new DevExpress.XtraEditors.PanelControl();
            this.cbDisplayReporter = new System.Windows.Forms.CheckBox();
            this.cbDisplayContract = new System.Windows.Forms.CheckBox();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportTo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtKey2 = new System.Windows.Forms.ComboBox();
            this.fplCheckList = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.plRules)).BeginInit();
            this.plRules.SuspendLayout();
            this.tplControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plCatalogType)).BeginInit();
            this.plCatalogType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plRules
            // 
            this.plRules.Controls.Add(this.tplControls);
            this.plRules.Controls.Add(this.fplCheckList);
            this.plRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRules.Location = new System.Drawing.Point(0, 0);
            this.plRules.Name = "plRules";
            this.plRules.Size = new System.Drawing.Size(979, 85);
            this.plRules.TabIndex = 0;
            this.plRules.Text = "搜索条件";
            // 
            // tplControls
            // 
            this.tplControls.ColumnCount = 3;
            this.tplControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.7085F));
            this.tplControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.2915F));
            this.tplControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplControls.Controls.Add(this.txtKey1, 1, 0);
            this.tplControls.Controls.Add(this.plCatalogType, 2, 0);
            this.tplControls.Controls.Add(this.lblKey2, 0, 1);
            this.tplControls.Controls.Add(this.lblKey1, 0, 0);
            this.tplControls.Controls.Add(this.panelControl2, 2, 1);
            this.tplControls.Controls.Add(this.txtKey2, 1, 1);
            this.tplControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplControls.Location = new System.Drawing.Point(152, 21);
            this.tplControls.Name = "tplControls";
            this.tplControls.RowCount = 2;
            this.tplControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplControls.Size = new System.Drawing.Size(825, 62);
            this.tplControls.TabIndex = 1;
            // 
            // txtKey1
            // 
            this.txtKey1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKey1.Location = new System.Drawing.Point(155, 3);
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.Properties.NullValuePrompt = "请输入XXXXXX！";
            this.txtKey1.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtKey1.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtKey1.Size = new System.Drawing.Size(458, 20);
            this.txtKey1.TabIndex = 3;
            this.txtKey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey1_KeyDown);
            // 
            // plCatalogType
            // 
            this.plCatalogType.Controls.Add(this.cbDisplayReporter);
            this.plCatalogType.Controls.Add(this.cbDisplayContract);
            this.plCatalogType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plCatalogType.Location = new System.Drawing.Point(619, 3);
            this.plCatalogType.Name = "plCatalogType";
            this.plCatalogType.Size = new System.Drawing.Size(203, 25);
            this.plCatalogType.TabIndex = 2;
            // 
            // cbDisplayReporter
            // 
            this.cbDisplayReporter.AutoSize = true;
            this.cbDisplayReporter.Checked = true;
            this.cbDisplayReporter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisplayReporter.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbDisplayReporter.Location = new System.Drawing.Point(139, 2);
            this.cbDisplayReporter.Name = "cbDisplayReporter";
            this.cbDisplayReporter.Size = new System.Drawing.Size(62, 21);
            this.cbDisplayReporter.TabIndex = 6;
            this.cbDisplayReporter.Text = "未立项";
            this.cbDisplayReporter.UseVisualStyleBackColor = true;
            this.cbDisplayReporter.CheckedChanged += new System.EventHandler(this.cbDisplayContract_CheckedChanged);
            // 
            // cbDisplayContract
            // 
            this.cbDisplayContract.AutoSize = true;
            this.cbDisplayContract.Checked = true;
            this.cbDisplayContract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisplayContract.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbDisplayContract.Location = new System.Drawing.Point(2, 2);
            this.cbDisplayContract.Name = "cbDisplayContract";
            this.cbDisplayContract.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.cbDisplayContract.Size = new System.Drawing.Size(74, 21);
            this.cbDisplayContract.TabIndex = 5;
            this.cbDisplayContract.Text = "已立项";
            this.cbDisplayContract.UseVisualStyleBackColor = true;
            this.cbDisplayContract.CheckedChanged += new System.EventHandler(this.cbDisplayContract_CheckedChanged);
            // 
            // lblKey2
            // 
            this.lblKey2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKey2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey2.Location = new System.Drawing.Point(3, 31);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(146, 31);
            this.lblKey2.TabIndex = 1;
            this.lblKey2.Text = "搜索关键字：";
            this.lblKey2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblKey2.Visible = false;
            // 
            // lblKey1
            // 
            this.lblKey1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKey1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey1.Location = new System.Drawing.Point(3, 0);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(146, 31);
            this.lblKey1.TabIndex = 1;
            this.lblKey1.Text = "搜索关键字：";
            this.lblKey1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnReset);
            this.panelControl2.Controls.Add(this.btnExportTo);
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(619, 34);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(203, 25);
            this.panelControl2.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Location = new System.Drawing.Point(67, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 21);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExportTo
            // 
            this.btnExportTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportTo.Location = new System.Drawing.Point(127, 2);
            this.btnExportTo.Name = "btnExportTo";
            this.btnExportTo.Size = new System.Drawing.Size(74, 21);
            this.btnExportTo.TabIndex = 0;
            this.btnExportTo.Text = "导出Excel";
            this.btnExportTo.Click += new System.EventHandler(this.btnExportTo_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Location = new System.Drawing.Point(2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 21);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKey2
            // 
            this.txtKey2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtKey2.Location = new System.Drawing.Point(155, 34);
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.Size = new System.Drawing.Size(458, 22);
            this.txtKey2.TabIndex = 5;
            this.txtKey2.Visible = false;
            // 
            // fplCheckList
            // 
            this.fplCheckList.AutoScroll = true;
            this.fplCheckList.Dock = System.Windows.Forms.DockStyle.Left;
            this.fplCheckList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fplCheckList.Location = new System.Drawing.Point(2, 21);
            this.fplCheckList.Name = "fplCheckList";
            this.fplCheckList.Size = new System.Drawing.Size(150, 62);
            this.fplCheckList.TabIndex = 0;
            // 
            // SearchRulePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plRules);
            this.Name = "SearchRulePanel";
            this.Size = new System.Drawing.Size(979, 85);
            ((System.ComponentModel.ISupportInitialize)(this.plRules)).EndInit();
            this.plRules.ResumeLayout(false);
            this.tplControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtKey1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plCatalogType)).EndInit();
            this.plCatalogType.ResumeLayout(false);
            this.plCatalogType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl plRules;
        private System.Windows.Forms.FlowLayoutPanel fplCheckList;
        private System.Windows.Forms.TableLayoutPanel tplControls;
        private System.Windows.Forms.Label lblKey1;
        private DevExpress.XtraEditors.PanelControl plCatalogType;
        private DevExpress.XtraEditors.TextEdit txtKey1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExportTo;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.CheckBox cbDisplayReporter;
        private System.Windows.Forms.CheckBox cbDisplayContract;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private System.Windows.Forms.Label lblKey2;
        private System.Windows.Forms.ComboBox txtKey2;
    }
}
