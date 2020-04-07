﻿using System;
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
using DevExpress.XtraGrid.Views.Grid;

namespace PublicManager.Modules.CustomReporter
{
    public partial class ModuleController : BaseModuleController
    {
        /// <summary>
        /// CatalogID筛选条件
        /// </summary>
        string strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
        private DEGridViewCellMergeAdapter cma1;
        private DEGridViewCellMergeAdapter cma2;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            dgvDetail.OptionsDetail.AllowExpandEmptyDetails = true;
            dgvDetail.OptionsDetail.ShowDetailTabs = false;
            cma1 = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3", "row4", "row5", "row6" });

            dgvSub.OptionsBehavior.Editable = false;
            dgvSub.OptionsView.AllowCellMerge = true;
            dgvSub.OptionsView.ShowGroupPanel = false;
            cma2 = new DEGridViewCellMergeAdapter(dgvSub, new string[] { "row1" });

            cbDisplayReporter.Checked = false;
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

        private void cbDisplayReporter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisplayContract.Checked && cbDisplayReporter.Checked)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
            }
            else if (cbDisplayContract.Checked)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog where CatalogType = '合同书')";
            }
            else if (cbDisplayReporter.Checked)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog where CatalogType = '建议书')";
            }
            else
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet dsAll = new DataSet();
            DataTable masterDt = getTempDataTable("row", 25);
            DataTable detailDt = getTempDataTable("row", 8);

            List<Project> projList = ConnectionManager.Context.table("Project").where("(TaskNumber like '%" + txtKey.Text + "%' or ProjectName like '%" + txtKey.Text + "%')" + strCatalogIDFilterString).select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                #region 主表数据
                List<object> cells = new List<object>();
                cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                cells.Add(proj.Domains);
                cells.Add(proj.TaskNumber);
                cells.Add(proj.ProjectNumber);
                cells.Add(proj.ProjectName);
                cells.Add(proj.TotalMoney);
                cells.Add(proj.TotalTime);
                cells.Add(proj.SecretLevel);
                //显示仅为项目负责人
                Person masterPerson = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '' and IsProjectMaster = 'true'").select("*").getItem<Person>(new Person());
                if (masterPerson != null && masterPerson.PersonID != null && masterPerson.PersonID.Length >= 1)
                {
                    cells.Add(masterPerson.PersonName);
                }
                else
                {
                    cells.Add(string.Empty);
                }
                cells.Add(proj.DutyUnit);
                cells.Add(proj.DutyUnitOrg);
                cells.Add(proj.DutyUnitAddress);
                cells.Add(string.Empty);
                cells.Add(proj.ProjectID);
                cells.Add(proj.Keywords);

                if (masterPerson != null && masterPerson.PersonID != null && masterPerson.PersonID.Length >= 1)
                {
                    cells.Add(masterPerson.Telephone);
                    cells.Add(masterPerson.Mobilephone);
                    cells.Add(masterPerson.PersonJob);
                }
                else
                {
                    cells.Add(string.Empty);
                    cells.Add(string.Empty);
                    cells.Add(string.Empty);
                }

                cells.Add(proj.OKQuestionMemo);
                cells.Add(proj.OKCheckA);
                cells.Add(proj.OKCheckB);
                cells.Add(proj.ContactCheckLevelA);
                cells.Add(proj.ContactCheckLevelB);
                cells.Add(proj.Memo);

                masterDt.Rows.Add(cells.ToArray());
                #endregion

                #region 生成从表数据
                if (proj != null && !string.IsNullOrEmpty(proj.ProjectID))
                {
                    List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                    foreach (Subject sub in subList)
                    {
                        cells = new List<object>();
                        cells.Add(sub.SubjectName);
                        Person personObj = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "' and JobInProject = '负责人'").select("*").getItem<Person>(new Person());
                        if (string.IsNullOrEmpty(personObj.PersonID))
                        {
                            cells.Add(string.Empty);
                        }
                        else
                        {
                            cells.Add(personObj.PersonName);
                        }
                        cells.Add(sub.DutyUnit);
                        cells.Add(sub.DutyUnitOrg);
                        cells.Add(sub.DutyUnitAddress);
                        cells.Add(proj.ProjectID);

                        if (string.IsNullOrEmpty(personObj.PersonID))
                        {
                            cells.Add(string.Empty);
                            cells.Add(string.Empty);
                        }
                        else
                        {
                            cells.Add(personObj.Telephone);
                            cells.Add(personObj.Mobilephone);
                        }

                        detailDt.Rows.Add(cells.ToArray());
                    }
                }
                #endregion
            }

            #region 生成从属关系数据
            masterDt.TableName = "MainView";
            detailDt.TableName = "SubjectView";
            dsAll.Tables.Add(masterDt);
            dsAll.Tables.Add(detailDt);

            DataColumn keyColumn = dsAll.Tables[masterDt.TableName].Columns["row15"];         //主键
            DataColumn foreignColumn = dsAll.Tables[detailDt.TableName].Columns["row6"];    //外键
            //
            //对于主从表，层次名至关重要，关系名必须和从表的层次名一致,
            //否则从表显示的是从表的所有字段，而不是所设计的显示字段
            //

            dsAll.Relations.Add(detailDt.TableName, keyColumn, foreignColumn, false);     //从表的层次名
            gcGrid.DataSource = dsAll.Tables[masterDt.TableName];
            #endregion
        }

        private void dgvDetail_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                object objProjectID = view.GetRowCellValue(e.RowHandle, "row15");
                if (objProjectID != null)
                {
                    string projectID = objProjectID.ToString();

                    GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                    if (detailView != null)
                    {
                        view.ExpandGroupRow(-1);
                    }
                }
            }
        }
    }
}