﻿namespace PublicManager.Modules.Reporter.Forms
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnImport = new DevExpress.XtraBars.BarButtonItem();
            this.rpBase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpbGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlTestA = new DevExpress.XtraTreeList.TreeList();
            this.col1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gcIgnoreList = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col22 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlTestA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcIgnoreList)).BeginInit();
            this.gcIgnoreList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnImport});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpBase});
            this.ribbonControl1.Size = new System.Drawing.Size(996, 147);
            // 
            // btnImport
            // 
            this.btnImport.Caption = "导入";
            this.btnImport.Id = 1;
            this.btnImport.LargeGlyph = global::PublicManager.Properties.Resources.importA;
            this.btnImport.Name = "btnImport";
            // 
            // rpBase
            // 
            this.rpBase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpbGroup1});
            this.rpBase.Name = "rpBase";
            this.rpBase.Text = "基本";
            // 
            // rpbGroup1
            // 
            this.rpbGroup1.ItemLinks.Add(this.btnImport);
            this.rpbGroup1.Name = "rpbGroup1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 147);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlTestA);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcIgnoreList);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(996, 438);
            this.splitContainerControl1.SplitterPosition = 295;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tlTestA
            // 
            this.tlTestA.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlTestA.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.col1});
            this.tlTestA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlTestA.Location = new System.Drawing.Point(0, 0);
            this.tlTestA.Name = "tlTestA";
            this.tlTestA.BeginUnboundLoad();
            this.tlTestA.AppendNode(new object[] {
            "2019-XXXX-01-XXXXX"}, -1);
            this.tlTestA.AppendNode(new object[] {
            "2019-XXXX-02-XXXXX"}, -1);
            this.tlTestA.EndUnboundLoad();
            this.tlTestA.OptionsBehavior.Editable = false;
            this.tlTestA.OptionsView.ShowColumns = false;
            this.tlTestA.OptionsView.ShowHorzLines = false;
            this.tlTestA.OptionsView.ShowIndentAsRowStyle = true;
            this.tlTestA.OptionsView.ShowIndicator = false;
            this.tlTestA.OptionsView.ShowVertLines = false;
            this.tlTestA.Size = new System.Drawing.Size(295, 438);
            this.tlTestA.TabIndex = 1;
            // 
            // col1
            // 
            this.col1.MinWidth = 52;
            this.col1.Name = "col1";
            this.col1.OptionsColumn.AllowFocus = false;
            this.col1.Visible = true;
            this.col1.VisibleIndex = 0;
            this.col1.Width = 93;
            // 
            // gcIgnoreList
            // 
            this.gcIgnoreList.Controls.Add(this.gridControl1);
            this.gcIgnoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIgnoreList.Location = new System.Drawing.Point(0, 0);
            this.gcIgnoreList.Name = "gcIgnoreList";
            this.gcIgnoreList.Size = new System.Drawing.Size(696, 438);
            this.gcIgnoreList.TabIndex = 0;
            this.gcIgnoreList.Text = "是否需要覆盖已存在数据？";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(692, 415);
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
            // ImporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 585);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ImporterForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlTestA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcIgnoreList)).EndInit();
            this.gcIgnoreList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpBase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpbGroup1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarButtonItem btnImport;
        private DevExpress.XtraTreeList.TreeList tlTestA;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col1;
        private DevExpress.XtraEditors.GroupControl gcIgnoreList;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col11;
        private DevExpress.XtraGrid.Columns.GridColumn col22;
    }
}