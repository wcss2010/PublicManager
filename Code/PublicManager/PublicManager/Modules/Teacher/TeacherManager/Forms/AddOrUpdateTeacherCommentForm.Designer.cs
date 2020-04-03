namespace PublicManager.Modules.Teacher.TeacherManager.Forms
{
    partial class AddOrUpdateTeacherCommentForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCommentDate = new System.Windows.Forms.DateTimePicker();
            this.txtCommentText = new System.Windows.Forms.TextBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "评审日期：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 192);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "评审内容：";
            // 
            // txtCommentDate
            // 
            this.txtCommentDate.Location = new System.Drawing.Point(90, 40);
            this.txtCommentDate.Name = "txtCommentDate";
            this.txtCommentDate.Size = new System.Drawing.Size(125, 22);
            this.txtCommentDate.TabIndex = 1;
            // 
            // txtCommentText
            // 
            this.txtCommentText.Location = new System.Drawing.Point(90, 76);
            this.txtCommentText.Multiline = true;
            this.txtCommentText.Name = "txtCommentText";
            this.txtCommentText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommentText.Size = new System.Drawing.Size(668, 417);
            this.txtCommentText.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 508);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(770, 43);
            this.panelControl1.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(594, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 39);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(681, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.rcTopBar.Size = new System.Drawing.Size(770, 27);
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
            // AddOrUpdateTeacherCommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 551);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.txtCommentText);
            this.Controls.Add(this.txtCommentDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.rcTopBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrUpdateTeacherCommentForm";
            this.Ribbon = this.rcTopBar;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加/编辑评审内容";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.DateTimePicker txtCommentDate;
        private System.Windows.Forms.TextBox txtCommentText;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
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