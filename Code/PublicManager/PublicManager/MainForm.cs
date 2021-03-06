﻿using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
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

        /// <summary>
        /// 综合查询关键词
        /// </summary>
        public static string allCheckKey = string.Empty;

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

            //显示第一页
            nbcLeftTree_ActiveGroupChanged(nbcLeftTree, new NavBarGroupEventArgs(nbcTestA));
        }

        /// <summary>
        /// 载入模块字典
        /// </summary>
        private void loadModules()
        {
            ModuleDict[nbcTestA.Caption + "xxxx" + "合同书数据包导入"] = new ContractModuleController();
            ModuleDict[nbcTestA.Caption + "xxxx" + "建议书数据包导入"] = new ReporterModuleController();
            ModuleDict[nbcTestA.Caption + "xxxx" + "归一化单位字典"] = new Modules.DataLoad.NormalUnitDict.ModuleController();
            ModuleDict[nbcTestA.Caption + "xxxx" + "管理员信息完善"] = new Modules.DataLoad.ManagerInfoEdit.ModuleController();

            ModuleDict[nbcTestH.Caption + "xxxx" + "报表导出"] = new PublicManager.Modules.DataExport.CustomReporter.ModuleController();

            ModuleDict[nbcTestB.Caption + "xxxx" + "项目查询"] = new Modules.DataCheck.ProjectCheck.ModuleController();
            ModuleDict[nbcTestB.Caption + "xxxx" + "课题查询"] = new Modules.DataCheck.SubjectCheck.ModuleController();
            ModuleDict[nbcTestB.Caption + "xxxx" + "成员查询"] = new Modules.DataCheck.PersonCheck.ModuleController();
            ModuleDict[nbcTestB.Caption + "xxxx" + "单位查询"] = new Modules.DataCheck.AddressCheck.ModuleController();
            ModuleDict[nbcTestB.Caption + "xxxx" + "合同经费预算"] = new Modules.DataCheck.MoneyCheck.ModuleController();
            ModuleDict[nbcTestB.Caption + "xxxx" + "综合查询"] = new Modules.DataCheck.AllCheck.ModuleController2();

            ModuleDict[nbcTestF.Caption + "xxxx" + "审核信息录入"] = new Modules.Lines.ProjectLines.ModuleController();
            ModuleDict[nbcTestF.Caption + "xxxx" + "节点评估管理"] = new Modules.Lines.ProjectNodes.ModuleController();
            ModuleDict[nbcTestF.Caption + "xxxx" + "经费过程管理"] = new Modules.Lines.MoneyLines.ModuleController();
            ModuleDict[nbcTestF.Caption + "xxxx" + "课题经费管理"] = new Modules.Lines.SubjectMoneys.ModuleController();

            ModuleDict[nbcTestC.Caption + "xxxx" + "专家信息管理"] = new Modules.Teacher.TeacherManager.ModuleController();

            ModuleDict[nbcTestG.Caption + "xxxx" + "信息提醒"] = new PublicManager.Modules.MainPage.ModuleController();

            allCheckKey = nbcTestB.Caption + "xxxx" + "综合查询";
        }

        /// <summary>
        /// 显示模块
        /// </summary>
        /// <param name="name">模块名称</param>
        /// <param name="isDisableAllModules">是否屏蔽其它模块</param>
        public void showModule(string oldName, bool isDisableAllModules)
        {
            string name = oldName.Trim();

            //检查是否需要屏蔽其它的模块
            if (isDisableAllModules)
            {
                foreach (BaseModuleController bmc in ModuleDict.Values)
                {
                    //停止
                    bmc.stop();
                }

                //清除顶部工具条
                int clearCount = rcTopBar.Pages.Count;
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
            plRightContent.Controls.Clear();

            if (e.Group.ControlContainer != null)
            {
                if (e.Group.ControlContainer.Controls.Count >= 1)
                {
                    if (e.Group.ControlContainer.Controls[0] is TreeList)
                    {
                        TreeList tl = ((TreeList)e.Group.ControlContainer.Controls[0]);
                        if (tl.Nodes.Count >= 1)
                        {
                            tl.SetFocusedNode(tl.Nodes[0]);

                            showModule(e.Group.Caption + "xxxx" + tl.Nodes[0].GetDisplayText(0), true);
                        }
                    }
                }
            }
            else
            {
                if (e.Group.Caption == "信息提醒")
                {
                    showModule(e.Group.Caption + "xxxx" + "信息提醒", true);
                }
            }
        }
        
        private void btnSkinColorModify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ColorWheelForm form = new ColorWheelForm();
            //form.StartPosition = FormStartPosition.CenterParent;
            //form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor;
            //form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2;
            //form.ShowDialog(this);

            //MainConfig.Config.Dict["皮肤颜色1"] = UserLookAndFeel.Default.SkinMaskColor != null ? UserLookAndFeel.Default.SkinMaskColor.ToArgb().ToString() : "-1";
            //MainConfig.Config.Dict["皮肤颜色2"] = UserLookAndFeel.Default.SkinMaskColor2 != null ? UserLookAndFeel.Default.SkinMaskColor2.ToArgb().ToString() : "-1";

            //MainConfig.Config.Dict["当前皮肤"] = UserLookAndFeel.Default.ActiveSkinName;
            //MainConfig.saveConfig();
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
        
        private void tlTestA_MouseClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tree = ((DevExpress.XtraTreeList.TreeList)sender);
            Point p = new Point(Cursor.Position.X, Cursor.Position.Y);　　//获取到鼠标点击的坐标位置
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (hitInfo.HitInfoType == HitInfoType.Cell)
            {
                tree.SetFocusedNode(hitInfo.Node);         //这句话就是关键，用于选中节点　　

                //显示模块
                if (nbcLeftTree.ActiveGroup != null)
                {
                    showModule(nbcLeftTree.ActiveGroup.Caption + "xxxx" + hitInfo.Node.GetDisplayText(0), true);
                }
            }
        }

        private void tlTestB_MouseClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tree = ((DevExpress.XtraTreeList.TreeList)sender);
            Point p = new Point(Cursor.Position.X, Cursor.Position.Y);　　//获取到鼠标点击的坐标位置
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (hitInfo.HitInfoType == HitInfoType.Cell)
            {
                tree.SetFocusedNode(hitInfo.Node);         //这句话就是关键，用于选中节点　　

                //显示模块
                if (nbcLeftTree.ActiveGroup != null)
                {
                    showModule(nbcLeftTree.ActiveGroup.Caption + "xxxx" + hitInfo.Node.GetDisplayText(0).Trim(), true);
                }
            }
        }

        private void tlTestC_MouseClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tree = ((DevExpress.XtraTreeList.TreeList)sender);
            Point p = new Point(Cursor.Position.X, Cursor.Position.Y);　　//获取到鼠标点击的坐标位置
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (hitInfo.HitInfoType == HitInfoType.Cell)
            {
                tree.SetFocusedNode(hitInfo.Node);         //这句话就是关键，用于选中节点　　

                //显示模块
                if (nbcLeftTree.ActiveGroup != null)
                {
                    showModule(nbcLeftTree.ActiveGroup.Caption + "xxxx" + hitInfo.Node.GetDisplayText(0), true);
                }
            }
        }

        private void skinRibbonGalleryBarItem1_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            //MainConfig.Config.Dict["当前皮肤"] = string.Concat(e.Item.Tag);
            //MainConfig.saveConfig();
        }

        private void tlTestF_MouseClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tree = ((DevExpress.XtraTreeList.TreeList)sender);
            Point p = new Point(Cursor.Position.X, Cursor.Position.Y);　　//获取到鼠标点击的坐标位置
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (hitInfo.HitInfoType == HitInfoType.Cell)
            {
                tree.SetFocusedNode(hitInfo.Node);         //这句话就是关键，用于选中节点　　

                //显示模块
                if (nbcLeftTree.ActiveGroup != null)
                {
                    showModule(nbcLeftTree.ActiveGroup.Caption + "xxxx" + hitInfo.Node.GetDisplayText(0), true);
                }
            }
        }

        private void tlTestG_MouseClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tree = ((DevExpress.XtraTreeList.TreeList)sender);
            Point p = new Point(Cursor.Position.X, Cursor.Position.Y);　　//获取到鼠标点击的坐标位置
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (hitInfo.HitInfoType == HitInfoType.Cell)
            {
                tree.SetFocusedNode(hitInfo.Node);         //这句话就是关键，用于选中节点　　

                //显示模块
                if (nbcLeftTree.ActiveGroup != null)
                {
                    showModule(nbcLeftTree.ActiveGroup.Caption + "xxxx" + hitInfo.Node.GetDisplayText(0), true);
                }
            }
        }
    }
}