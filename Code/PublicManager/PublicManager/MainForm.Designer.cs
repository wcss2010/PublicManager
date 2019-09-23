namespace PublicManager
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rcTopBar = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rpPageA = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rsbStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.nbcLeftTree = new DevExpress.XtraNavBar.NavBarControl();
            this.nbcTestA = new DevExpress.XtraNavBar.NavBarGroup();
            this.plRightContent = new DevExpress.XtraEditors.PanelControl();
            this.nbcTestB = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbcTestC = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.bvcMenus = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.bvtiItemA = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.bvtiItemB = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewClientControl3 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.bvtiItemC = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.tlTestA = new DevExpress.XtraTreeList.TreeList();
            this.rpPageB = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpPageC = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgGroupA = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbcLeftTree)).BeginInit();
            this.nbcLeftTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plRightContent)).BeginInit();
            this.plRightContent.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvcMenus)).BeginInit();
            this.bvcMenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlTestA)).BeginInit();
            this.SuspendLayout();
            // 
            // rcTopBar
            // 
            this.rcTopBar.ApplicationButtonDropDownControl = this.bvcMenus;
            this.rcTopBar.ExpandCollapseItem.Id = 0;
            this.rcTopBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcTopBar.ExpandCollapseItem,
            this.barCheckItem1});
            this.rcTopBar.Location = new System.Drawing.Point(0, 0);
            this.rcTopBar.MaxItemId = 3;
            this.rcTopBar.Name = "rcTopBar";
            this.rcTopBar.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpPageA,
            this.rpPageB,
            this.rpPageC});
            this.rcTopBar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.rcTopBar.Size = new System.Drawing.Size(943, 147);
            this.rcTopBar.StatusBar = this.rsbStatusBar;
            // 
            // rpPageA
            // 
            this.rpPageA.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgGroupA});
            this.rpPageA.Name = "rpPageA";
            this.rpPageA.Text = "演示页1";
            // 
            // rsbStatusBar
            // 
            this.rsbStatusBar.Location = new System.Drawing.Point(0, 580);
            this.rsbStatusBar.Name = "rsbStatusBar";
            this.rsbStatusBar.Ribbon = this.rcTopBar;
            this.rsbStatusBar.Size = new System.Drawing.Size(943, 31);
            // 
            // nbcLeftTree
            // 
            this.nbcLeftTree.ActiveGroup = this.nbcTestA;
            this.nbcLeftTree.Controls.Add(this.navBarGroupControlContainer1);
            this.nbcLeftTree.Controls.Add(this.navBarGroupControlContainer2);
            this.nbcLeftTree.Controls.Add(this.navBarGroupControlContainer3);
            this.nbcLeftTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbcLeftTree.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbcTestA,
            this.nbcTestB,
            this.nbcTestC});
            this.nbcLeftTree.Location = new System.Drawing.Point(0, 147);
            this.nbcLeftTree.Name = "nbcLeftTree";
            this.nbcLeftTree.Size = new System.Drawing.Size(251, 433);
            this.nbcLeftTree.TabIndex = 2;
            this.nbcLeftTree.Text = "navBarControl1";
            // 
            // nbcTestA
            // 
            this.nbcTestA.Caption = "演示1";
            this.nbcTestA.ControlContainer = this.navBarGroupControlContainer1;
            this.nbcTestA.Expanded = true;
            this.nbcTestA.GroupClientHeight = 264;
            this.nbcTestA.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbcTestA.Name = "nbcTestA";
            // 
            // plRightContent
            // 
            this.plRightContent.Controls.Add(this.bvcMenus);
            this.plRightContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRightContent.Location = new System.Drawing.Point(251, 147);
            this.plRightContent.Name = "plRightContent";
            this.plRightContent.Size = new System.Drawing.Size(692, 433);
            this.plRightContent.TabIndex = 3;
            // 
            // nbcTestB
            // 
            this.nbcTestB.Caption = "演示2";
            this.nbcTestB.ControlContainer = this.navBarGroupControlContainer2;
            this.nbcTestB.GroupClientHeight = 212;
            this.nbcTestB.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbcTestB.Name = "nbcTestB";
            // 
            // nbcTestC
            // 
            this.nbcTestC.Caption = "演示3";
            this.nbcTestC.ControlContainer = this.navBarGroupControlContainer3;
            this.nbcTestC.GroupClientHeight = 177;
            this.nbcTestC.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbcTestC.Name = "nbcTestC";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.tlTestA);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(243, 260);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer2.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(243, 208);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer3.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(243, 173);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // bvcMenus
            // 
            this.bvcMenus.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.bvcMenus.Controls.Add(this.backstageViewClientControl1);
            this.bvcMenus.Controls.Add(this.backstageViewClientControl2);
            this.bvcMenus.Controls.Add(this.backstageViewClientControl3);
            this.bvcMenus.Items.Add(this.bvtiItemA);
            this.bvcMenus.Items.Add(this.bvtiItemB);
            this.bvcMenus.Items.Add(this.bvtiItemC);
            this.bvcMenus.Location = new System.Drawing.Point(40, 16);
            this.bvcMenus.Name = "bvcMenus";
            this.bvcMenus.Ribbon = this.rcTopBar;
            this.bvcMenus.SelectedTab = this.bvtiItemA;
            this.bvcMenus.SelectedTabIndex = 0;
            this.bvcMenus.Size = new System.Drawing.Size(640, 411);
            this.bvcMenus.TabIndex = 0;
            this.bvcMenus.Text = "backstageViewControl1";
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Location = new System.Drawing.Point(133, 63);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(506, 347);
            this.backstageViewClientControl1.TabIndex = 1;
            // 
            // bvtiItemA
            // 
            this.bvtiItemA.Caption = "演示菜单项1";
            this.bvtiItemA.ContentControl = this.backstageViewClientControl1;
            this.bvtiItemA.Name = "bvtiItemA";
            this.bvtiItemA.Selected = true;
            // 
            // backstageViewClientControl2
            // 
            this.backstageViewClientControl2.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            this.backstageViewClientControl2.Size = new System.Drawing.Size(508, 411);
            this.backstageViewClientControl2.TabIndex = 2;
            // 
            // bvtiItemB
            // 
            this.bvtiItemB.Caption = "演示菜单项2";
            this.bvtiItemB.ContentControl = this.backstageViewClientControl2;
            this.bvtiItemB.Name = "bvtiItemB";
            this.bvtiItemB.Selected = false;
            // 
            // backstageViewClientControl3
            // 
            this.backstageViewClientControl3.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl3.Name = "backstageViewClientControl3";
            this.backstageViewClientControl3.Size = new System.Drawing.Size(508, 411);
            this.backstageViewClientControl3.TabIndex = 3;
            // 
            // bvtiItemC
            // 
            this.bvtiItemC.Caption = "演示菜单项3";
            this.bvtiItemC.ContentControl = this.backstageViewClientControl3;
            this.bvtiItemC.Name = "bvtiItemC";
            this.bvtiItemC.Selected = false;
            // 
            // tlTestA
            // 
            this.tlTestA.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlTestA.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.tlTestA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlTestA.Location = new System.Drawing.Point(0, 0);
            this.tlTestA.Name = "tlTestA";
            this.tlTestA.BeginUnboundLoad();
            this.tlTestA.AppendNode(new object[] {
            "AAA"}, -1);
            this.tlTestA.AppendNode(new object[] {
            "111"}, 0);
            this.tlTestA.AppendNode(new object[] {
            "222"}, 0);
            this.tlTestA.AppendNode(new object[] {
            "333"}, 0);
            this.tlTestA.AppendNode(new object[] {
            "BBB"}, -1);
            this.tlTestA.AppendNode(new object[] {
            "444"}, 4);
            this.tlTestA.AppendNode(new object[] {
            "555"}, 4);
            this.tlTestA.AppendNode(new object[] {
            "666"}, 4);
            this.tlTestA.AppendNode(new object[] {
            "CCC"}, -1);
            this.tlTestA.AppendNode(new object[] {
            "777"}, 8);
            this.tlTestA.AppendNode(new object[] {
            "888"}, 8);
            this.tlTestA.AppendNode(new object[] {
            "999"}, 8);
            this.tlTestA.EndUnboundLoad();
            this.tlTestA.OptionsBehavior.Editable = false;
            this.tlTestA.OptionsView.ShowColumns = false;
            this.tlTestA.OptionsView.ShowHorzLines = false;
            this.tlTestA.OptionsView.ShowIndentAsRowStyle = true;
            this.tlTestA.OptionsView.ShowIndicator = false;
            this.tlTestA.OptionsView.ShowVertLines = false;
            this.tlTestA.Size = new System.Drawing.Size(243, 260);
            this.tlTestA.TabIndex = 0;
            // 
            // rpPageB
            // 
            this.rpPageB.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgGroup2});
            this.rpPageB.Name = "rpPageB";
            this.rpPageB.Text = "演示页2";
            // 
            // rpPageC
            // 
            this.rpPageC.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgGroup3});
            this.rpPageC.Name = "rpPageC";
            this.rpPageC.Text = "演示页3";
            // 
            // rpgGroupA
            // 
            this.rpgGroupA.ItemLinks.Add(this.barCheckItem1);
            this.rpgGroupA.Name = "rpgGroupA";
            this.rpgGroupA.Text = "演示组1";
            // 
            // rpgGroup2
            // 
            this.rpgGroup2.Name = "rpgGroup2";
            this.rpgGroup2.Text = "演示组2";
            // 
            // rpgGroup3
            // 
            this.rpgGroup3.Name = "rpgGroup3";
            this.rpgGroup3.Text = "演示组3";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "演示选择";
            this.barCheckItem1.Id = 1;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.MinWidth = 52;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowFocus = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 93;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 611);
            this.Controls.Add(this.plRightContent);
            this.Controls.Add(this.nbcLeftTree);
            this.Controls.Add(this.rsbStatusBar);
            this.Controls.Add(this.rcTopBar);
            this.Name = "MainForm";
            this.Ribbon = this.rcTopBar;
            this.StatusBar = this.rsbStatusBar;
            this.Text = "Mail Client";
            ((System.ComponentModel.ISupportInitialize)(this.rcTopBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbcLeftTree)).EndInit();
            this.nbcLeftTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plRightContent)).EndInit();
            this.plRightContent.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bvcMenus)).EndInit();
            this.bvcMenus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlTestA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rcTopBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpPageA;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar rsbStatusBar;
        private DevExpress.XtraNavBar.NavBarControl nbcLeftTree;
        private DevExpress.XtraNavBar.NavBarGroup nbcTestA;
        private DevExpress.XtraEditors.PanelControl plRightContent;
        private DevExpress.XtraNavBar.NavBarGroup nbcTestB;
        private DevExpress.XtraNavBar.NavBarGroup nbcTestC;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer3;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl bvcMenus;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl3;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtiItemA;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtiItemB;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtiItemC;
        private DevExpress.XtraTreeList.TreeList tlTestA;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgGroupA;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpPageB;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpPageC;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgGroup3;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;

    }
}

