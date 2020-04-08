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
            this.lblKey3 = new System.Windows.Forms.CheckBox();
            this.txtKey1 = new DevExpress.XtraEditors.TextEdit();
            this.plCatalogType = new DevExpress.XtraEditors.PanelControl();
            this.cbDisplayReporter = new System.Windows.Forms.CheckBox();
            this.cbDisplayContract = new System.Windows.Forms.CheckBox();
            this.lblKey2 = new System.Windows.Forms.CheckBox();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportTo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtKey2 = new System.Windows.Forms.ComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtKey4 = new System.Windows.Forms.DateTimePicker();
            this.lblKey4 = new System.Windows.Forms.CheckBox();
            this.txtKey3 = new System.Windows.Forms.DateTimePicker();
            this.fplCheckList = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.plRules)).BeginInit();
            this.plRules.SuspendLayout();
            this.tplControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plCatalogType)).BeginInit();
            this.plCatalogType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plRules
            // 
            this.plRules.Controls.Add(this.tplControls);
            this.plRules.Controls.Add(this.fplCheckList);
            this.plRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRules.Location = new System.Drawing.Point(0, 0);
            this.plRules.Name = "plRules";
            this.plRules.Size = new System.Drawing.Size(1040, 119);
            this.plRules.TabIndex = 0;
            this.plRules.Text = "搜索条件";
            // 
            // tplControls
            // 
            this.tplControls.ColumnCount = 3;
            this.tplControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.7085F));
            this.tplControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.2915F));
            this.tplControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplControls.Controls.Add(this.lblKey3, 0, 2);
            this.tplControls.Controls.Add(this.txtKey1, 1, 0);
            this.tplControls.Controls.Add(this.plCatalogType, 2, 0);
            this.tplControls.Controls.Add(this.lblKey2, 0, 1);
            this.tplControls.Controls.Add(this.lblKey1, 0, 0);
            this.tplControls.Controls.Add(this.panelControl2, 2, 1);
            this.tplControls.Controls.Add(this.txtKey2, 1, 1);
            this.tplControls.Controls.Add(this.panelControl1, 1, 2);
            this.tplControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplControls.Location = new System.Drawing.Point(152, 21);
            this.tplControls.Name = "tplControls";
            this.tplControls.RowCount = 3;
            this.tplControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplControls.Size = new System.Drawing.Size(886, 96);
            this.tplControls.TabIndex = 1;
            // 
            // lblKey3
            // 
            this.lblKey3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKey3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey3.Location = new System.Drawing.Point(3, 67);
            this.lblKey3.Name = "lblKey3";
            this.lblKey3.Size = new System.Drawing.Size(161, 26);
            this.lblKey3.TabIndex = 1;
            this.lblKey3.Text = "节点评估时间：";
            this.lblKey3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblKey3.Visible = false;
            // 
            // txtKey1
            // 
            this.txtKey1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKey1.Location = new System.Drawing.Point(170, 3);
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.Properties.NullValuePrompt = "请输入XXXXXX！";
            this.txtKey1.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtKey1.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtKey1.Size = new System.Drawing.Size(502, 20);
            this.txtKey1.TabIndex = 3;
            this.txtKey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey1_KeyDown);
            // 
            // plCatalogType
            // 
            this.plCatalogType.Controls.Add(this.cbDisplayReporter);
            this.plCatalogType.Controls.Add(this.cbDisplayContract);
            this.plCatalogType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plCatalogType.Location = new System.Drawing.Point(678, 3);
            this.plCatalogType.Name = "plCatalogType";
            this.plCatalogType.Size = new System.Drawing.Size(205, 26);
            this.plCatalogType.TabIndex = 2;
            // 
            // cbDisplayReporter
            // 
            this.cbDisplayReporter.AutoSize = true;
            this.cbDisplayReporter.Checked = true;
            this.cbDisplayReporter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisplayReporter.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbDisplayReporter.Location = new System.Drawing.Point(141, 2);
            this.cbDisplayReporter.Name = "cbDisplayReporter";
            this.cbDisplayReporter.Size = new System.Drawing.Size(62, 22);
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
            this.cbDisplayContract.Size = new System.Drawing.Size(74, 22);
            this.cbDisplayContract.TabIndex = 5;
            this.cbDisplayContract.Text = "已立项";
            this.cbDisplayContract.UseVisualStyleBackColor = true;
            this.cbDisplayContract.CheckedChanged += new System.EventHandler(this.cbDisplayContract_CheckedChanged);
            // 
            // lblKey2
            // 
            this.lblKey2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKey2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey2.Location = new System.Drawing.Point(3, 35);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(161, 26);
            this.lblKey2.TabIndex = 1;
            this.lblKey2.Text = "所属部门：";
            this.lblKey2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblKey2.Visible = false;
            // 
            // lblKey1
            // 
            this.lblKey1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKey1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey1.Location = new System.Drawing.Point(3, 0);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(161, 32);
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
            this.panelControl2.Location = new System.Drawing.Point(678, 35);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(205, 26);
            this.panelControl2.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Location = new System.Drawing.Point(67, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(62, 22);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExportTo
            // 
            this.btnExportTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportTo.Location = new System.Drawing.Point(129, 2);
            this.btnExportTo.Name = "btnExportTo";
            this.btnExportTo.Size = new System.Drawing.Size(74, 22);
            this.btnExportTo.TabIndex = 0;
            this.btnExportTo.Text = "导出Excel";
            this.btnExportTo.Click += new System.EventHandler(this.btnExportTo_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Location = new System.Drawing.Point(2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 22);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKey2
            // 
            this.txtKey2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtKey2.Location = new System.Drawing.Point(170, 35);
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.Size = new System.Drawing.Size(502, 22);
            this.txtKey2.TabIndex = 5;
            this.txtKey2.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtKey4);
            this.panelControl1.Controls.Add(this.lblKey4);
            this.panelControl1.Controls.Add(this.txtKey3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(170, 67);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(502, 26);
            this.panelControl1.TabIndex = 6;
            // 
            // txtKey4
            // 
            this.txtKey4.CustomFormat = "yyyy年MM月dd日";
            this.txtKey4.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtKey4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtKey4.Location = new System.Drawing.Point(347, 2);
            this.txtKey4.Name = "txtKey4";
            this.txtKey4.Size = new System.Drawing.Size(124, 22);
            this.txtKey4.TabIndex = 5;
            this.txtKey4.Visible = false;
            // 
            // lblKey4
            // 
            this.lblKey4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKey4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKey4.Location = new System.Drawing.Point(125, 2);
            this.lblKey4.Name = "lblKey4";
            this.lblKey4.Size = new System.Drawing.Size(222, 22);
            this.lblKey4.TabIndex = 1;
            this.lblKey4.Text = "合同书预计评估时间：";
            this.lblKey4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblKey4.Visible = false;
            // 
            // txtKey3
            // 
            this.txtKey3.CustomFormat = "yyyy年MM月dd日";
            this.txtKey3.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtKey3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtKey3.Location = new System.Drawing.Point(2, 2);
            this.txtKey3.Name = "txtKey3";
            this.txtKey3.Size = new System.Drawing.Size(123, 22);
            this.txtKey3.TabIndex = 4;
            this.txtKey3.Visible = false;
            // 
            // fplCheckList
            // 
            this.fplCheckList.AutoScroll = true;
            this.fplCheckList.Dock = System.Windows.Forms.DockStyle.Left;
            this.fplCheckList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fplCheckList.Location = new System.Drawing.Point(2, 21);
            this.fplCheckList.Name = "fplCheckList";
            this.fplCheckList.Size = new System.Drawing.Size(150, 96);
            this.fplCheckList.TabIndex = 0;
            // 
            // SearchRulePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plRules);
            this.Name = "SearchRulePanel";
            this.Size = new System.Drawing.Size(1040, 119);
            ((System.ComponentModel.ISupportInitialize)(this.plRules)).EndInit();
            this.plRules.ResumeLayout(false);
            this.tplControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtKey1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plCatalogType)).EndInit();
            this.plCatalogType.ResumeLayout(false);
            this.plCatalogType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox lblKey2;
        private System.Windows.Forms.ComboBox txtKey2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.CheckBox lblKey3;
        private System.Windows.Forms.CheckBox lblKey4;
        private System.Windows.Forms.DateTimePicker txtKey4;
        private System.Windows.Forms.DateTimePicker txtKey3;
    }
}