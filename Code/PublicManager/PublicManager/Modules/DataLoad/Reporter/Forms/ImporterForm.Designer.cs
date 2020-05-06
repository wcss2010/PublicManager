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
            this.lvErrorList = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.rcTopBar = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.btnSkinColorModify = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.bsiBottomText = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIgnoreList)).BeginInit();
            this.gcIgnoreList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 27);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlTestA);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcIgnoreList);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(996, 513);
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
            this.tlTestA.Size = new System.Drawing.Size(344, 513);
            this.tlTestA.TabIndex = 0;
            this.tlTestA.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tlTestA_AfterCheck);
            this.tlTestA.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tlTestA_AfterSelect);
            // 
            // gcIgnoreList
            // 
            this.gcIgnoreList.Controls.Add(this.lvErrorList);
            this.gcIgnoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIgnoreList.Location = new System.Drawing.Point(0, 0);
            this.gcIgnoreList.Name = "gcIgnoreList";
            this.gcIgnoreList.Size = new System.Drawing.Size(647, 513);
            this.gcIgnoreList.TabIndex = 0;
            this.gcIgnoreList.Text = "是否需要覆盖已存在数据？";
            // 
            // lvErrorList
            // 
            this.lvErrorList.CheckBoxes = true;
            this.lvErrorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID});
            this.lvErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvErrorList.Location = new System.Drawing.Point(2, 21);
            this.lvErrorList.Name = "lvErrorList";
            this.lvErrorList.Size = new System.Drawing.Size(643, 490);
            this.lvErrorList.TabIndex = 1;
            this.lvErrorList.UseCompatibleStateImageBehavior = false;
            this.lvErrorList.View = System.Windows.Forms.View.Details;
            this.lvErrorList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvErrorList_ItemChecked);
            // 
            // chID
            // 
            this.chID.Text = "项目编号";
            this.chID.Width = 300;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 540);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(996, 44);
            this.panelControl2.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(910, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "导入";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rcTopBar
            // 
            this.rcTopBar.AutoHideEmptyItems = true;
            this.rcTopBar.AutoSaveLayoutToXml = true;
            this.rcTopBar.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.DrawGroupsBorder = false;
            this.rcTopBar.ExpandCollapseItem.Id = 0;
            this.rcTopBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcTopBar.ExpandCollapseItem,
            this.barCheckItem1,
            this.skinRibbonGalleryBarItem1,
            this.ribbonGalleryBarItem1,
            this.btnSkinColorModify,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.bsiBottomText});
            this.rcTopBar.Location = new System.Drawing.Point(0, 0);
            this.rcTopBar.MaxItemId = 13;
            this.rcTopBar.Name = "rcTopBar";
            this.rcTopBar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.rcTopBar.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowCategoryInCaption = false;
            this.rcTopBar.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcTopBar.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.rcTopBar.ShowQatLocationSelector = false;
            this.rcTopBar.ShowToolbarCustomizeItem = false;
            this.rcTopBar.Size = new System.Drawing.Size(996, 27);
            this.rcTopBar.Toolbar.ShowCustomizeItem = false;
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "演示选择";
            this.barCheckItem1.Id = 1;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 3;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.Id = 4;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // btnSkinColorModify
            // 
            this.btnSkinColorModify.Caption = "自定义";
            this.btnSkinColorModify.Id = 5;
            this.btnSkinColorModify.LargeGlyph = global::PublicManager.Properties.Resources.ColorMixer_32x32;
            this.btnSkinColorModify.Name = "btnSkinColorModify";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 7;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 8;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 9;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 10;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 11;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // bsiBottomText
            // 
            this.bsiBottomText.Caption = "...";
            this.bsiBottomText.Id = 12;
            this.bsiBottomText.Name = "bsiBottomText";
            this.bsiBottomText.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ImporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 584);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.rcTopBar);
            this.MaximizeBox = false;
            this.Name = "ImporterForm";
            this.Ribbon = this.rcTopBar;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIgnoreList)).EndInit();
            this.gcIgnoreList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcIgnoreList;
        private System.Windows.Forms.TreeView tlTestA;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.ListView lvErrorList;
        private System.Windows.Forms.ColumnHeader chID;
        private DevExpress.XtraBars.Ribbon.RibbonControl rcTopBar;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem btnSkinColorModify;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarStaticItem bsiBottomText;
    }
}