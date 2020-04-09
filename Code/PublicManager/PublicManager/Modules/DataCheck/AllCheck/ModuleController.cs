using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using Noear.Weed;

namespace PublicManager.Modules.DataCheck.AllCheck
{
    public partial class ModuleController : BaseModuleController
    {
        private DEGridViewCellMergeAdapter cma;
        private DataSet dsAll;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row2", "row3", "row13" });

            dgvSubjectPersons.OptionsBehavior.Editable = false;
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);

            loadData();
        }

        private void loadData()
        {
            dsAll = new DataSet();
            DataTable masterDt = getTempDataTable("row", 33);
            DataTable detailDt = getTempDataTable("row", 11);

            List<Project> projList = ConnectionManager.Context.table("Project").select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                #region 生成数据
                List<object> cells = new List<object>();

                if (proj != null && !string.IsNullOrEmpty(proj.ProjectID))
                {
                    //项目类型
                    string catalogType = ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知");

                    //课题列表
                    List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());

                    foreach (Subject sub in subList)
                    {
                        #region 生成主表数据
                        cells = new List<object>();

                        //项目编号
                        cells.Add(proj.ProjectNumber);

                        //项目领域 2
                        cells.Add(proj.Domains);

                        //项目名称 3
                        cells.Add(proj.ProjectName);

                        //总经费(万元)
                        cells.Add(proj.TotalMoney);

                        //周期
                        cells.Add(proj.TotalTime);

                        //第一年度经费+第二年度经费+第三年度经费+第四年度经费+第五年度经费
                        for (int kkk = 1; kkk <= 5; kkk++)
                        {
                            cells.Add(ConnectionManager.Context.table("Dicts").where("CatalogID='" + proj.CatalogID + "' and DictName='Year" + kkk + "'").select("DictValue").getValue<string>(string.Empty));
                        }

                        //密级
                        cells.Add(proj.SecretLevel);

                        //起止时间
                        List<DateTime> dtList = new List<DateTime>();
                        Noear.Weed.DataList dlMoneySendList = ConnectionManager.Context.table("MoneySends").where("CatalogID='" + proj.CatalogID + "'").orderBy("WillTime").select("WillTime").getDataList();
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

                        //计划批次 13
                        cells.Add(proj.TaskNumber);

                        //项目负责人
                        Person masterPerson = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '' and IsProjectMaster = 'true'").select("*").getItem<Person>(new Person());
                        if (masterPerson != null && masterPerson.PersonID != null && masterPerson.PersonID.Length >= 1)
                        {
                            cells.Add(masterPerson.PersonName);
                        }
                        else
                        {
                            cells.Add(string.Empty);
                        }

                        //项目牵头单位
                        cells.Add(proj.DutyUnit);

                        //项目负责人职务/职称+项目负责人座机+项目负责人手机
                        if (masterPerson != null && masterPerson.PersonID != null && masterPerson.PersonID.Length >= 1)
                        {
                            cells.Add(masterPerson.PersonJob);
                            cells.Add(masterPerson.Telephone);
                            cells.Add(masterPerson.Mobilephone);
                        }
                        else
                        {
                            cells.Add(string.Empty);
                            cells.Add(string.Empty);
                            cells.Add(string.Empty);
                        }

                        //牵头单位所属大单位
                        cells.Add(proj.DutyUnitOrg);

                        //牵头单位地址
                        cells.Add(proj.DutyUnitAddress);

                        //课题名称
                        cells.Add(sub.SubjectName);

                        //课题负责单位
                        cells.Add(sub.DutyUnit);

                        //课题负责单位所属大单位
                        cells.Add(sub.DutyUnitOrg);

                        //课题负责单位通信地址
                        cells.Add(sub.DutyUnitAddress);

                        //课题总经费
                        if (catalogType != null && catalogType == "合同书")
                        {
                            //合同书总经费
                            cells.Add(ConnectionManager.Context.table("Dicts").where("CatalogID = '" + proj.CatalogID + "' and SubjectID ='" + sub.SubjectID + "' and DictType='SubjectMoney,SubjectMoneyInfo' and DictName = 'Money1'").select("DictValue").getValue<string>(""));
                        }
                        else
                        {
                            //建议书总经费
                            cells.Add(sub.TotalMoney);
                        }

                        //选题评议
                        cells.Add(proj.OKQuestionMemo);

                        //立项审核
                        cells.Add(proj.OKCheckA);

                        //立项复议
                        cells.Add(proj.OKCheckB);

                        //合同审查等级
                        cells.Add(proj.ContactCheckLevelA);

                        //合同审核等级
                        cells.Add(proj.ContactCheckLevelB);

                        //备注
                        cells.Add(proj.Memo);

                        //项目ID
                        cells.Add(proj.ProjectID);

                        //课题ID
                        cells.Add(sub.SubjectID);

                        masterDt.Rows.Add(cells.ToArray());
                        #endregion

                        #region 生成从表数据
                        if (sub != null && !string.IsNullOrEmpty(sub.SubjectID))
                        {
                            List<Person> perList = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "'").select("*").getList<Person>(new Person());
                            foreach (Person p in perList)
                            {
                                cells = new List<object>();

                                //姓名
                                cells.Add(p.PersonName);

                                //身份证
                                cells.Add(p.PersonIDCard);

                                //性别
                                cells.Add(p.PersonSex);

                                //工作单位
                                cells.Add(p.WorkUnit);

                                //职务/职称
                                cells.Add(p.PersonJob);

                                //专业
                                cells.Add(p.PersonSpecialty);

                                //座机
                                cells.Add(p.Telephone);

                                //手机
                                cells.Add(p.Mobilephone);

                                //任务分工
                                cells.Add(p.TaskContent);

                                //项目中职务
                                //string roleStr = "未知";
                                //if (p.IsProjectMaster == "true")
                                //{
                                //    roleStr = "项目负责人兼" + sub.SubjectName + "的" + p.JobInProject;
                                //}
                                //else
                                //{
                                //    roleStr = sub.SubjectName + "的" + p.JobInProject;
                                //}
                                //cells.Add(roleStr);
                                string roleStr = "未知";
                                if (p.IsProjectMaster == "true")
                                {
                                    roleStr = "项目负责人兼" + p.JobInProject;
                                }
                                else
                                {
                                    roleStr = p.JobInProject;
                                }
                                cells.Add(roleStr);
                                
                                //课题ID
                                cells.Add(sub.SubjectID);

                                detailDt.Rows.Add(cells.ToArray());
                            }
                        }
                        #endregion
                    }
                }
                #endregion
            }

            #region 生成从属关系数据
            masterDt.TableName = "MainView";
            detailDt.TableName = "SubjectView";
            dsAll.Tables.Add(masterDt);
            dsAll.Tables.Add(detailDt);

            DataColumn keyColumn = dsAll.Tables[masterDt.TableName].Columns["row33"];         //主键
            DataColumn foreignColumn = dsAll.Tables[detailDt.TableName].Columns["row11"];    //外键
            //
            //对于主从表，层次名至关重要，关系名必须和从表的层次名一致,
            //否则从表显示的是从表的所有字段，而不是所设计的显示字段
            //

            dsAll.Relations.Add(detailDt.TableName, keyColumn, foreignColumn, false);     //从表的层次名
            gcData.DataSource = dsAll.Tables[masterDt.TableName];
            #endregion
        }

        private void dgvDetail_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                object objProjectID = view.GetRowCellValue(e.RowHandle, "row33");
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