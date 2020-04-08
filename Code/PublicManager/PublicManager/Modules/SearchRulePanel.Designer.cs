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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.plKey3Panel = new DevExpress.XtraEditors.PanelControl();
            this.txtKey4 = new System.Windows.Forms.DateTimePicker();
            this.lblKey4 = new System.Windows.Forms.CheckBox();
            this.lblKey3 = new System.Windows.Forms.CheckBox();
            this.txtKey3 = new System.Windows.Forms.DateTimePicker();
            this.plKey2Panel = new DevExpress.XtraEditors.PanelControl();
            this.txtKey2 = new System.Windows.Forms.ComboBox();
            this.lblKey2 = new System.Windows.Forms.CheckBox();
            this.plKey1Panel = new DevExpress.XtraEditors.PanelControl();
            this.txtKey1 = new DevExpress.XtraEditors.TextEdit();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportTo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.plCatalogType = new DevExpress.XtraEditors.PanelControl();
            this.cbDisplayReporter = new System.Windows.Forms.CheckBox();
            this.cbDisplayContract = new System.Windows.Forms.CheckBox();
            this.fplCheckList = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.plRules)).BeginInit();
            this.plRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plKey3Panel)).BeginInit();
            this.plKey3Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plKey2Panel)).BeginInit();
            this.plKey2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plKey1Panel)).BeginInit();
            this.plKey1Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plCatalogType)).BeginInit();
            this.plCatalogType.SuspendLayout();
            this.SuspendLayout();
            // 
            // plRules
            // 
            this.plRules.Controls.Add(this.panelControl1);
            this.plRules.Controls.Add(this.fplCheckList);
            this.plRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRules.Location = new System.Drawing.Point(0, 0);
            this.plRules.Name = "plRules";
            this.plRules.Size = new System.Drawing.Size(1040, 112);
            this.plRules.TabIndex = 0;
            this.plRules.Text = "搜索条件";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(152, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(886, 89);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.plKey3Panel);
            this.panelControl3.Controls.Add(this.plKey2Panel);
            this.panelControl3.Controls.Add(this.plKey1Panel);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(670, 85);
            this.panelControl3.TabIndex = 2;
            // 
            // plKey3Panel
            // 
            this.plKey3Panel.Controls.Add(this.txtKey4);
            this.plKey3Panel.Controls.Add(this.lblKey4);
            this.plKey3Panel.Controls.Add(this.lblKey3);
            this.plKey3Panel.Controls.Add(this.txtKey3);
            this.plKey3Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.plKey3Panel.Location = new System.Drawing.Point(2, 54);
            this.plKey3Panel.Name = "plKey3Panel";
            this.plKey3Panel.Size = new System.Drawing.Size(666, 30);
            this.plKey3Panel.TabIndex = 2;
            this.plKey3Panel.Visible = false;
            // 
            // txtKey4
            // 
            this.txtKey4.CustomFormat = "yyyy年MM月dd日";
            this.txtKey4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtKey4.Location = new System.Drawing.Point(527, 5);
            this.txtKey4.Name = "txtKey4";
            this.txtKey4.Size = new System.Drawing.Size(124, 22);
            this.txtKey4.TabIndex = 5;
            this.txtKey4.Visible = false;
            // 
            // lblKey4
            // 
            this.lblKey4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey4.Location = new System.Drawing.Point(301, 5);
            this.lblKey4.Name = "lblKey4";
            this.lblKey4.Size = new System.Drawing.Size(222, 22);
            this.lblKey4.TabIndex = 1;
            this.lblKey4.Text = "合同书预计评估时间：";
            this.lblKey4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblKey4.Visible = false;
            // 
            // lblKey3
            // 
            this.lblKey3.AutoSize = true;
            this.lblKey3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKey3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey3.Location = new System.Drawing.Point(2, 2);
            this.lblKey3.Name = "lblKey3";
            this.lblKey3.Size = new System.Drawing.Size(161, 26);
            this.lblKey3.TabIndex = 1;
            this.lblKey3.Text = "节点评估时间：";
            this.lblKey3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblKey3.Visible = false;
            // 
            // txtKey3
            // 
            this.txtKey3.CustomFormat = "yyyy年MM月dd日";
            this.txtKey3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtKey3.Location = new System.Drawing.Point(167, 5);
            this.txtKey3.Name = "txtKey3";
            this.txtKey3.Size = new System.Drawing.Size(123, 22);
            this.txtKey3.TabIndex = 4;
            this.txtKey3.Visible = false;
            // 
            // plKey2Panel
            // 
            this.plKey2Panel.Controls.Add(this.txtKey2);
            this.plKey2Panel.Controls.Add(this.lblKey2);
            this.plKey2Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.plKey2Panel.Location = new System.Drawing.Point(2, 27);
            this.plKey2Panel.Name = "plKey2Panel";
            this.plKey2Panel.Size = new System.Drawing.Size(666, 27);
            this.plKey2Panel.TabIndex = 1;
            this.plKey2Panel.Visible = false;
            // 
            // txtKey2
            // 
            this.txtKey2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtKey2.Location = new System.Drawing.Point(125, 2);
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.Size = new System.Drawing.Size(539, 22);
            this.txtKey2.TabIndex = 5;
            this.txtKey2.Visible = false;
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKey2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey2.Location = new System.Drawing.Point(2, 2);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(123, 23);
            this.lblKey2.TabIndex = 1;
            this.lblKey2.Text = "所属部门：";
            this.lblKey2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblKey2.Visible = false;
            // 
            // plKey1Panel
            // 
            this.plKey1Panel.Controls.Add(this.txtKey1);
            this.plKey1Panel.Controls.Add(this.lblKey1);
            this.plKey1Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.plKey1Panel.Location = new System.Drawing.Point(2, 2);
            this.plKey1Panel.Name = "plKey1Panel";
            this.plKey1Panel.Size = new System.Drawing.Size(666, 25);
            this.plKey1Panel.TabIndex = 0;
            // 
            // txtKey1
            // 
            this.txtKey1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKey1.Location = new System.Drawing.Point(125, 2);
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.Properties.NullValuePrompt = "请输入XXXXXX！";
            this.txtKey1.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtKey1.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtKey1.Size = new System.Drawing.Size(539, 20);
            this.txtKey1.TabIndex = 3;
            this.txtKey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey1_KeyDown);
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKey1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey1.Location = new System.Drawing.Point(2, 2);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(123, 19);
            this.lblKey1.TabIndex = 1;
            this.lblKey1.Text = "搜索关键字：";
            this.lblKey1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.panelControl2);
            this.panelControl4.Controls.Add(this.plCatalogType);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(672, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(212, 85);
            this.panelControl4.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnReset);
            this.panelControl2.Controls.Add(this.btnExportTo);
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 31);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(208, 32);
            this.panelControl2.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Location = new System.Drawing.Point(67, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(65, 28);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExportTo
            // 
            this.btnExportTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportTo.Location = new System.Drawing.Point(132, 2);
            this.btnExportTo.Name = "btnExportTo";
            this.btnExportTo.Size = new System.Drawing.Size(74, 28);
            this.btnExportTo.TabIndex = 0;
            this.btnExportTo.Text = "导出Excel";
            this.btnExportTo.Click += new System.EventHandler(this.btnExportTo_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Location = new System.Drawing.Point(2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 28);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // plCatalogType
            // 
            this.plCatalogType.Controls.Add(this.cbDisplayReporter);
            this.plCatalogType.Controls.Add(this.cbDisplayContract);
            this.plCatalogType.Dock = System.Windows.Forms.DockStyle.Top;
            this.plCatalogType.Location = new System.Drawing.Point(2, 2);
            this.plCatalogType.Name = "plCatalogType";
            this.plCatalogType.Size = new System.Drawing.Size(208, 29);
            this.plCatalogType.TabIndex = 2;
            // 
            // cbDisplayReporter
            // 
            this.cbDisplayReporter.AutoSize = true;
            this.cbDisplayReporter.Checked = true;
            this.cbDisplayReporter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisplayReporter.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbDisplayReporter.Location = new System.Drawing.Point(144, 2);
            this.cbDisplayReporter.Name = "cbDisplayReporter";
            this.cbDisplayReporter.Size = new System.Drawing.Size(62, 25);
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
            this.cbDisplayContract.Size = new System.Drawing.Size(74, 25);
            this.cbDisplayContract.TabIndex = 5;
            this.cbDisplayContract.Text = "已立项";
            this.cbDisplayContract.UseVisualStyleBackColor = true;
            this.cbDisplayContract.CheckedChanged += new System.EventHandler(this.cbDisplayContract_CheckedChanged);
            // 
            // fplCheckList
            // 
            this.fplCheckList.AutoScroll = true;
            this.fplCheckList.Dock = System.Windows.Forms.DockStyle.Left;
            this.fplCheckList.Location = new System.Drawing.Point(2, 21);
            this.fplCheckList.Name = "fplCheckList";
            this.fplCheckList.Size = new System.Drawing.Size(150, 89);
            this.fplCheckList.TabIndex = 0;
            // 
            // SearchRulePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plRules);
            this.Name = "SearchRulePanel";
            this.Size = new System.Drawing.Size(1040, 112);
            ((System.ComponentModel.ISupportInitialize)(this.plRules)).EndInit();
            this.plRules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plKey3Panel)).EndInit();
            this.plKey3Panel.ResumeLayout(false);
            this.plKey3Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plKey2Panel)).EndInit();
            this.plKey2Panel.ResumeLayout(false);
            this.plKey2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plKey1Panel)).EndInit();
            this.plKey1Panel.ResumeLayout(false);
            this.plKey1Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plCatalogType)).EndInit();
            this.plCatalogType.ResumeLayout(false);
            this.plCatalogType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl plRules;
        private System.Windows.Forms.FlowLayoutPanel fplCheckList;
        private System.Windows.Forms.Label lblKey1;
        private DevExpress.XtraEditors.PanelControl plCatalogType;
        private DevExpress.XtraEditors.TextEdit txtKey1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExportTo;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.CheckBox cbDisplayReporter;
        private System.Windows.Forms.CheckBox cbDisplayContract;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private System.Windows.Forms.CheckBox lblKey2;
        private System.Windows.Forms.ComboBox txtKey2;
        private System.Windows.Forms.CheckBox lblKey3;
        private System.Windows.Forms.CheckBox lblKey4;
        private System.Windows.Forms.DateTimePicker txtKey4;
        private System.Windows.Forms.DateTimePicker txtKey3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl plKey3Panel;
        private DevExpress.XtraEditors.PanelControl plKey2Panel;
        private DevExpress.XtraEditors.PanelControl plKey1Panel;
    }
}