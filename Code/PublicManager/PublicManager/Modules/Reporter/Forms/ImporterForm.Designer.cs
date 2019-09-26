namespace PublicManager.Modules.Reporter.Forms
{
    partial class ImporterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlTestA = new System.Windows.Forms.TreeView();
            this.gcIgnoreList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIgnoreList)).BeginInit();
            this.gcIgnoreList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlTestA);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcIgnoreList);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(854, 463);
            this.splitContainerControl1.SplitterPosition = 295;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tlTestA
            // 
            this.tlTestA.CheckBoxes = true;
            this.tlTestA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlTestA.Location = new System.Drawing.Point(0, 0);
            this.tlTestA.Name = "tlTestA";
            this.tlTestA.Size = new System.Drawing.Size(253, 463);
            this.tlTestA.TabIndex = 0;
            // 
            // gcIgnoreList
            // 
            this.gcIgnoreList.Controls.Add(this.gridControl1);
            this.gcIgnoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIgnoreList.Location = new System.Drawing.Point(0, 0);
            this.gcIgnoreList.Name = "gcIgnoreList";
            this.gcIgnoreList.Size = new System.Drawing.Size(596, 463);
            this.gcIgnoreList.TabIndex = 0;
            this.gcIgnoreList.Text = "是否需要覆盖已存在数据？";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(592, 440);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col11,
            this.col22});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.FindNullPrompt = "";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // col11
            // 
            this.col11.Caption = "是否仍需要导入";
            this.col11.FieldName = "A";
            this.col11.Name = "col11";
            this.col11.OptionsColumn.AllowFocus = false;
            this.col11.Visible = true;
            this.col11.VisibleIndex = 0;
            // 
            // col22
            // 
            this.col22.Caption = "名称";
            this.col22.FieldName = "B";
            this.col22.Name = "col22";
            this.col22.OptionsColumn.AllowFocus = false;
            this.col22.Visible = true;
            this.col22.VisibleIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 463);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(854, 38);
            this.panelControl2.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(780, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 34);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "导入";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ImporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 501);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl2);
            this.MaximizeBox = false;
            this.Name = "ImporterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIgnoreList)).EndInit();
            this.gcIgnoreList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcIgnoreList;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col11;
        private DevExpress.XtraGrid.Columns.GridColumn col22;
        private System.Windows.Forms.TreeView tlTestA;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}