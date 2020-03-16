using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PublicManager.DB.Entitys;
using PublicManager.DB;
using Noear.Weed;

namespace PublicManager.Modules.CustomReporter
{
    public partial class ModuleController : BaseModuleController
    {
        public ModuleController()
        {
            InitializeComponent();
        }

        public override DevExpress.XtraBars.Ribbon.RibbonPage[] getTopBarPages()
        {
            return new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpMaster };
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);

            //this.tvProjectList.ContentTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProjectList_AfterSelect);

            loadData();
        }

        private void loadData()
        {
            //tvProjectList.ContentTreeView.Nodes.Clear();
            //List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").where("CatalogType='合同书'").select("*").getList<Catalog>(new Catalog());
            //foreach (Catalog catalog in catalogList)
            //{
            //    TreeNode parentNode = new TreeNode();
            //    parentNode.Text = catalog.CatalogName + "(" + catalog.CatalogVersion + ")";
            //    parentNode.Tag = catalog;
            //    tvProjectList.ContentTreeView.Nodes.Add(parentNode);

            //    ////课题金额
            //    //List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalog.CatalogID + "' and ProjectID='" + catalog.CatalogID + "'").select("*").getList<Subject>(new Subject());
            //    //foreach (Subject sub in subjectList)
            //    //{
            //    //    TreeNode subjectNode = new TreeNode();
            //    //    subjectNode.Text = sub.SubjectName;
            //    //    subjectNode.Tag = sub;
            //    //    parentNode.Nodes.Add(subjectNode);
            //    //}
            //}
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

                    //基本数据
                    DataTable dtBase = new DataTable();

                    #region 输出基本数据
                    //生成列
                    dtBase.Columns.Add("合同编号", typeof(string));
                    dtBase.Columns.Add("合同名称", typeof(string));
                    dtBase.Columns.Add("承担单位", typeof(string));
                    dtBase.Columns.Add("项目负责人", typeof(string));
                    dtBase.Columns.Add("联系电话", typeof(string));
                    dtBase.Columns.Add("职务职称", typeof(string));
                    dtBase.Columns.Add("周期", typeof(string));
                    dtBase.Columns.Add("总经费", typeof(string));
                    dtBase.Columns.Add("第一年度经费", typeof(string));
                    dtBase.Columns.Add("第二年度经费", typeof(string));
                    dtBase.Columns.Add("第三年度经费", typeof(string));
                    dtBase.Columns.Add("第四年度经费", typeof(string));
                    dtBase.Columns.Add("第五年度经费", typeof(string));
                    dtBase.Columns.Add("密级", typeof(string));
                    dtBase.Columns.Add("起止时间", typeof(string));
                    dtBase.Columns.Add("单位通信地址", typeof(string));

                    List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").where("CatalogType='合同书'").select("*").getList<Catalog>(new Catalog());

                    //生成内容
                    foreach (Catalog c in catalogList)
                    {
                        List<object> cells = new List<object>();

                        //项目信息
                        Project p = ConnectionManager.Context.table("Project").where("CatalogID = '" + c.CatalogID + "'").select("*").getItem<Project>(new Project());

                        //合同编号
                        cells.Add(p.ProjectNumber);

                        //合同名称
                        cells.Add(p.ProjectName);

                        //承担单位
                        cells.Add(p.DutyUnit);

                        Person projectMaster = ConnectionManager.Context.table("Person").where("IsProjectMaster='true' and JobInProject='负责人' and CatalogID = '" + c.CatalogID + "'").select("*").getItem<Person>(new Person());
                        //项目负责人
                        cells.Add(projectMaster.PersonName);

                        //联系电话
                        cells.Add(projectMaster.Telephone);

                        //职务职称
                        cells.Add(projectMaster.PersonJob);

                        //周期
                        cells.Add(p.TotalTime);

                        //总经费
                        cells.Add(p.TotalMoney);

                        //第一年度经费,第二年度经费,第三年度经费,第四年度经费,第五年度经费
                        for (int kkk = 1; kkk <= 5; kkk++)
                        {
                            cells.Add(ConnectionManager.Context.table("Dicts").where("CatalogID='" + c.CatalogID + "' and DictName='Year" + kkk + "'").select("DictValue").getValue<string>(string.Empty));
                        }

                        //密级
                        cells.Add(p.SecretLevel);

                        //起止时间(拨付时间)
                        List<DateTime> dtList = new List<DateTime>();
                        DataList dlMoneySendList = ConnectionManager.Context.table("MoneySends").where("CatalogID='" + c.CatalogID + "'").orderBy("WillTime").select("WillTime").getDataList();
                        if (dlMoneySendList.getRowCount() >= 1)
                        {
                            foreach (DataItem diiii in dlMoneySendList.getRows())
                            {
                                DateTime willTime = diiii.get("WillTime") != null ? DateTime.Parse(diiii.get("WillTime").ToString()) : DateTime.Now;
                                dtList.Add(willTime);
                            }
                        }
                        if (dtList.Count >= 2)
                        {
                            cells.Add(dtList[0].ToString("yyyy年MM月dd日") + "~" + dtList[dtList.Count - 1].ToString("yyyy年MM月dd日"));
                        }
                        else if (dtList.Count == 1)
                        {
                            cells.Add(dtList[0].ToString("yyyy年MM月dd日") + "~");
                        }
                        else
                        {
                            cells.Add("");
                        }

                        //单位通信地址
                        cells.Add(p.DutyUnitAddress);

                        dtBase.Rows.Add(cells.ToArray());
                    }
                    #endregion

                    //写入基本数据
                    writeSheet(workbook, cellStyleA, cellStyleB, dtBase);

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
    }
}