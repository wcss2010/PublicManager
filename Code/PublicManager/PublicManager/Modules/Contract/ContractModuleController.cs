﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System.IO;

namespace PublicManager.Modules.Contract
{
    public partial class ContractModuleController : BaseModuleController
    {
        private string totalDir = "(未设置)";

        private string decompressDir = "(未设置)";
        private MainView tc;

        public ContractModuleController()
        {
            InitializeComponent();
        }

        public override DevExpress.XtraBars.Ribbon.RibbonPage[] getTopBarPages()
        {
            return new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpMaster };
        }

        public override void start()
        {
            //显示详细页
            showDetailPage();

            //更新目录提示
            updateDirectoryHint();
        }

        /// <summary>
        /// 更新目录提示
        /// </summary>
        private void updateDirectoryHint()
        {
            if (MainConfig.Config.Dict.ContainsKey("合同总目录"))
            {
                totalDir = MainConfig.Config.Dict["合同总目录"];
            }
            
            if (MainConfig.Config.Dict.ContainsKey("合同解压目录"))
            {
                decompressDir = MainConfig.Config.Dict["合同解压目录"];
            }

            StatusLabelControl.Caption = "主目录:" + totalDir + ",解压目录:" + decompressDir;
        }

        /// <summary>
        /// 显示详细页
        /// </summary>
        private void showDetailPage()
        {
            DisplayControl.Controls.Clear();
            tc = new MainView();
            tc.updateCatalogs();
            tc.Dock = DockStyle.Fill;
            DisplayControl.Controls.Add(tc);
        }

        public override void stop()
        {

        }

        private void btnSetSourceDir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fbdFolderSelect.SelectedPath = totalDir == "(未设置)" ? string.Empty : totalDir;
            if (fbdFolderSelect.ShowDialog() == DialogResult.OK)
            {
                totalDir = fbdFolderSelect.SelectedPath;

                MainConfig.Config.Dict["合同总目录"] = totalDir;
                MainConfig.saveConfig();

                updateDirectoryHint();
            }
        }

        private void btnSetDestDir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fbdFolderSelect.SelectedPath = decompressDir == "(未设置)" ? string.Empty : decompressDir;
            if (fbdFolderSelect.ShowDialog() == DialogResult.OK)
            {
                decompressDir = fbdFolderSelect.SelectedPath;

                MainConfig.Config.Dict["合同解压目录"] = decompressDir;
                MainConfig.saveConfig();

                updateDirectoryHint();
            }
        }

        private void btnImportAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ImporterForm ifm = new Forms.ImporterForm(tc, true, totalDir, decompressDir);
            ifm.ShowDialog();
        }

        private void btnImportWithSelected_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ImporterForm ifm = new Forms.ImporterForm(tc, false, totalDir, decompressDir);
            ifm.ShowDialog();
        }

        private void btnExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Empty;
            sfd.Filter = "*.xlsx|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //输出的Excel路径
                    string excelFile = sfd.FileName;

                    //Excel数据
                    MemoryStream memoryStream = new MemoryStream();
                    //创建Workbook
                    NPOI.XSSF.UserModel.XSSFWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();

                    #region 设置Excel样式
                    //创建单元格设置对象(普通内容)
                    NPOI.SS.UserModel.ICellStyle cellStyleA = workbook.CreateCellStyle();
                    cellStyleA.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
                    cellStyleA.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                    cellStyleA.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleA.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleA.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleA.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleA.WrapText = true;

                    //创建单元格设置对象(普通内容)
                    NPOI.SS.UserModel.ICellStyle cellStyleB = workbook.CreateCellStyle();
                    cellStyleB.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    cellStyleB.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                    cellStyleB.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleB.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleB.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleB.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    cellStyleB.WrapText = true;

                    //创建设置字体对象(内容字体)
                    NPOI.SS.UserModel.IFont fontA = workbook.CreateFont();
                    fontA.FontHeightInPoints = 16;//设置字体大小
                    fontA.FontName = "宋体";
                    cellStyleA.SetFont(fontA);

                    //创建设置字体对象(标题字体)
                    NPOI.SS.UserModel.IFont fontB = workbook.CreateFont();
                    fontB.FontHeightInPoints = 16;//设置字体大小
                    fontB.FontName = "宋体";
                    fontB.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                    cellStyleB.SetFont(fontB);
                    #endregion

                    #region 输出数据
                    DataTable dt = new DataTable();

                    //生成列
                    dt.Columns.Add("项目名称", typeof(string));
                    dt.Columns.Add("项目领域", typeof(string));
                    dt.Columns.Add("合同牵头单位", typeof(string));
                    dt.Columns.Add("项目负责人", typeof(string));
                    dt.Columns.Add("项目负责人电话", typeof(string));
                    dt.Columns.Add("研究周期", typeof(string));
                    dt.Columns.Add("项目总经费", typeof(string));
                    dt.Columns.Add("研究目标", typeof(string));
                    dt.Columns.Add("研究内容", typeof(string));
                    //统计最大课题数量
                    int maxSubjectCount = 0;
                    List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").where("CatalogType='合同书'").select("*").getList<Catalog>(new Catalog());
                    foreach (Catalog c in catalogList)
                    {
                        object objValue = ConnectionManager.Context.table("Subject").where("CatalogID = '" + c.CatalogID + "'").select("count(*)").getValue();
                        if (objValue != null)
                        {
                            int intValue = 0;
                            try
                            {
                                intValue = int.Parse(objValue.ToString());
                            }
                            catch (Exception ex) { }

                            if (intValue >= maxSubjectCount)
                            {
                                maxSubjectCount = intValue;
                            }
                        }
                    }
                    for (int kk = 1; kk <= maxSubjectCount; kk++)
                    {
                        dt.Columns.Add("课题" + kk + "名称", typeof(string));
                        dt.Columns.Add("课题" + kk + "单位", typeof(string));
                        dt.Columns.Add("课题" + kk + "负责人", typeof(string));
                        dt.Columns.Add("课题" + kk + "负责人电话", typeof(string));
                    }

                    //生成内容
                    foreach (Catalog c in catalogList)
                    {
                        List<object> cells = new List<object>();

                        //项目信息
                        Project p = ConnectionManager.Context.table("Project").where("CatalogID = '" + c.CatalogID + "'").select("*").getItem<Project>(new Project());

                        //项目名称
                        cells.Add(p.ProjectName);

                        //项目领域
                        cells.Add(p.Domains);

                        //项目牵头单位
                        cells.Add(p.DutyUnit);

                        Person projectMaster = ConnectionManager.Context.table("Person").where("IsProjectMaster='true' and JobInProject='负责人'").select("*").getItem<Person>(new Person());
                        //项目负责人
                        cells.Add(projectMaster.PersonName);
                        //项目负责人电话
                        cells.Add(string.Empty);

                        //研究周期
                        cells.Add(string.Empty);

                        //总经费
                        cells.Add(p.TotalMoney);

                        //研究目标
                        cells.Add(getTxtContent(c, "研究目标"));

                        //研究内容
                        cells.Add(string.Empty);

                        //课题列表
                        List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + c.CatalogID + "'").select("*").getList<Subject>(new Subject());
                        foreach (Subject s in subjectList)
                        {
                            cells.Add(s.SubjectName);
                            cells.Add(s.DutyUnit);

                            Person subjectMaster = ConnectionManager.Context.table("Person").where("JobInProject='负责人' and CatalogID = '" + c.CatalogID + "' and SubjectID = '" + s.SubjectID + "'").select("*").getItem<Person>(new Person());
                            cells.Add(subjectMaster.PersonName);
                            cells.Add(string.Empty);
                        }
                        int emptyCount = maxSubjectCount - subjectList.Count;
                        for (int vvv = 0; vvv < emptyCount; vvv++)
                        {
                            cells.Add(string.Empty);
                        }

                        dt.Rows.Add(cells.ToArray());
                    }

                    writeSheet(workbook, cellStyleA, cellStyleB, dt);
                    #endregion

                    #region 输出文件并打开文件
                    //输出到流
                    workbook.Write(memoryStream);

                    //写Excel文件
                    File.WriteAllBytes(excelFile, memoryStream.ToArray());

                    //显示提示
                    MessageBox.Show("导出完成！路径：" + excelFile, "提示");

                    //打开Excel文件
                    System.Diagnostics.Process.Start(excelFile);
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对不起，导出失败！Ex:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 获得文本内容
        /// </summary>
        /// <param name="catalog"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private string getTxtContent(Catalog catalog,string name)
        {
            string result = string.Empty;
            string filePath = Path.Combine(decompressDir, Path.Combine(catalog.CatalogNumber, Path.Combine("Files", name + ".txt")));
            if (File.Exists(filePath))
            {
                result = File.ReadAllText(filePath);
            }
            return result;
        }
    }
}