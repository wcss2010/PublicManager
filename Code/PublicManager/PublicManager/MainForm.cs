using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.XtraNavBar;
using PublicManager.Modules;
using PublicManager.Modules.Contract;
using PublicManager.Modules.Reporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublicManager
{
    public partial class MainForm : RibbonForm
    {
        /// <summary>
        /// 当前模块
        /// </summary>
        public static BaseModuleController CurrentModule { get; set; }

        private static Dictionary<string, BaseModuleController> moduleDict = new Dictionary<string, BaseModuleController>();
        /// <summary>
        /// 模块字典(Key=名称,Value=模块控制器)
        /// </summary>
        public static Dictionary<string, BaseModuleController> ModuleDict
        {
            get { return MainForm.moduleDict; }
        }

        /// <summary>
        /// 菜单控制器
        /// </summary>
        private MainMenuController menuController = new MainMenuController();

        public MainForm()
        {
            InitializeComponent();

            //加载菜单
            menuController.MenuControl.Width = 0;
            menuController.MenuControl.Height = 0;
            Controls.Add(menuController.MenuControl);
            rcTopBar.ApplicationButtonDropDownControl = menuController.MenuControl;

            //加载所有模块
            loadModules();
        }

        /// <summary>
        /// 载入模块字典
        /// </summary>
        private void loadModules()
        {
            ModuleDict["合同书汇总"] = new ContractModuleController();
            ModuleDict["建议书汇总"] = new ReporterModuleController();
        }

        /// <summary>
        /// 显示模块
        /// </summary>
        /// <param name="name"></param>
        public void showModule(string name)
        {
            if (CurrentModule != null)
            {
                //停止
                CurrentModule.stop();

                //清除顶部工具条
                int clearCount = rcTopBar.Pages.Count - 1;
                if (clearCount >= 1)
                {
                    for (int kk = 0; kk < clearCount; kk++)
                    {
                        rcTopBar.Pages.RemoveAt(0);
                    }
                }

                //清除引用
                CurrentModule = null;
            }

            if (ModuleDict.ContainsKey(name))
            {
                //设置当前模块引用
                CurrentModule = ModuleDict[name];

                //设置内容显示控件
                CurrentModule.DisplayControl = plRightContent;

                //设置底部提示文本控件
                CurrentModule.StatusLabelControl = bsiBottomText;

                //插入顶部工具条
                RibbonPage[] pages = CurrentModule.getTopBarPages();
                if (pages != null)
                {
                    foreach (RibbonPage rp in pages) 
                    {
                        rcTopBar.Pages.Insert(rcTopBar.Pages.Count - 1, rp);
                    }
                }

                //启动
                CurrentModule.start();
            }
        }

        private void nbcLeftTree_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {

        }

        private void nbcLeftTree_NavPaneStateChanged(object sender, EventArgs e)
        {

        }

        private void tlTestA_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            showModule(e.Node.GetDisplayText(0));
        }

        private void btnSkinColorModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }
    }
}