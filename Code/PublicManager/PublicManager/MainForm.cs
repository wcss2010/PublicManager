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
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PublicManager
{
    public partial class MainForm : RibbonForm
    {
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
            ModuleDict["项目课题关系"] = new Modules.DataCheck.ProjectSubjectCheck.ModuleController();
            ModuleDict["项目成员关系"] = new Modules.DataCheck.ProjectPersonCheck.ModuleController();
            ModuleDict["成员分析"] = new Modules.DataCheck.PersonCheck.ModuleController();
        }

        /// <summary>
        /// 显示模块
        /// </summary>
        /// <param name="name">模块名称</param>
        /// <param name="isDisableAllModules">是否屏蔽其它模块</param>
        public void showModule(string name, bool isDisableAllModules)
        {
            //检查是否需要屏蔽其它的模块
            if (isDisableAllModules)
            {
                foreach (BaseModuleController bmc in ModuleDict.Values)
                {
                    //停止
                    bmc.stop();
                }

                //清除顶部工具条
                int clearCount = rcTopBar.Pages.Count - 1;
                if (clearCount >= 1)
                {
                    for (int kk = 0; kk < clearCount; kk++)
                    {
                        rcTopBar.Pages.RemoveAt(0);
                    }
                }
            }

            //按名称搜索并显示模块
            BaseModuleController currentModule = null;
            if (ModuleDict.ContainsKey(name))
            {
                //设置当前模块引用
                currentModule = ModuleDict[name];

                //设置内容显示控件
                currentModule.DisplayControl = plRightContent;

                //设置底部提示文本控件
                currentModule.StatusLabelControl = bsiBottomText;

                //插入顶部工具条
                RibbonPage[] pages = currentModule.getTopBarPages();
                if (pages != null && pages.Length >= 1)
                {
                    //显示顶部工具条
                    foreach (RibbonPage rp in pages) 
                    {
                        if (rcTopBar.Pages.Contains(rp))
                        {
                            continue;
                        }
                        else
                        {
                            rcTopBar.Pages.Insert(rcTopBar.Pages.Count - 1, rp);
                        }
                    }
                    
                    //显示新添加的页面
                    rcTopBar.SelectedPage = pages[0];
                }

                //启动
                currentModule.start();
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
            showModule(e.Node.GetDisplayText(0), true);
        }

        private void btnSkinColorModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ColorWheelForm form = new ColorWheelForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            form.ShowDialog(this);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="text"></param>
        public static void writeLog(string text)
        {
            //日志目录
            string logPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            //判断是否需要创建目录
            if (!System.IO.Directory.Exists(logPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(logPath);
                }
                catch (Exception ex) { }
            }

            //生成日志文件名称
            string fileFullName = System.IO.Path.Combine(logPath, string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd")));

            //写日志
            try
            {
                File.AppendAllText(fileFullName, DateTime.Now.ToString() + ":" + text + Environment.NewLine);
            }
            catch (Exception ex) { }

            //错误计数
            ProgressForm.errorCount++;
        }

        private void tlTestB_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            showModule(e.Node.GetDisplayText(0), true);
        }

        private void tlTestC_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            showModule(e.Node.GetDisplayText(0), true);
        }
    }
}