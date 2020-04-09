using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;

namespace PublicManager.Modules.DataCheck.PersonCheck
{
    public partial class ModuleController : BaseModuleController
    {
        private DEGridViewCellMergeAdapter cma;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3" });

            srpSearch.IsDisplayReporterData = false;
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);
        }

        private void srpSearch_OnSearchClick(object sender, EventArgs args)
        {
            DataTable dt = getTempDataTable("row", 13);

            List<Project> projList = MakeSQLWithSearchRule.getProjectList(srpSearch);
            foreach (Project proj in projList)
            {
                //显示仅为项目负责人
                Person masterPersonObj = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '' and IsProjectMaster = 'true'").select("*").getItem<Person>(new Person());
                if (masterPersonObj != null && masterPersonObj.PersonID != null && masterPersonObj.PersonID.Length >= 1)
                {
                    if (string.IsNullOrEmpty(srpSearch.Key1EditControl.Text) || ((srpSearch.getUsingRuleCount() == 0 || srpSearch.isUsingRule("人员")) && MakeSQLWithSearchRule.isDisplayData(typeof(Person).Name, masterPersonObj.PersonID)) || srpSearch.isUsingRule("课题") == true || srpSearch.isUsingRule("项目") == true)
                    {
                        //存在仅为负责人的记录
                        List<object> cells = new List<object>();
                        cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                        cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                        cells.Add(proj.ProjectName);
                        cells.Add("*****");
                        cells.Add(masterPersonObj.PersonName);
                        cells.Add(masterPersonObj.PersonIDCard);
                        cells.Add(masterPersonObj.PersonSex);
                        cells.Add(masterPersonObj.WorkUnit);
                        cells.Add(masterPersonObj.PersonJob);
                        cells.Add(masterPersonObj.PersonSpecialty);
                        cells.Add(masterPersonObj.TotalTime);
                        cells.Add(masterPersonObj.TaskContent);

                        cells.Add("项目负责人");

                        dt.Rows.Add(cells.ToArray());
                    }
                }

                //显示课题成员
                List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                foreach (Subject sub in subList)
                {
                    if (string.IsNullOrEmpty(srpSearch.Key1EditControl.Text) || ((srpSearch.getUsingRuleCount() == 0 || srpSearch.isUsingRule("课题")) && MakeSQLWithSearchRule.isDisplayData(typeof(Subject).Name, sub.SubjectID)) || srpSearch.isUsingRule("项目") == true || srpSearch.isUsingRule("人员") == true)
                    {
                        List<Person> perList = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "'").select("*").getList<Person>(new Person());
                        foreach (Person p in perList)
                        {
                            if (string.IsNullOrEmpty(srpSearch.Key1EditControl.Text) || ((srpSearch.getUsingRuleCount() == 0 || srpSearch.isUsingRule("人员")) && MakeSQLWithSearchRule.isDisplayData(typeof(Person).Name, p.PersonID)) || srpSearch.isUsingRule("课题") == true || srpSearch.isUsingRule("项目") == true)
                            {
                                List<object> cells = new List<object>();
                                cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                                cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                                cells.Add(proj.ProjectName);
                                cells.Add(sub.SubjectName);
                                cells.Add(p.PersonName);
                                cells.Add(p.PersonIDCard);
                                cells.Add(p.PersonSex);
                                cells.Add(p.WorkUnit);
                                cells.Add(p.PersonJob);
                                cells.Add(p.PersonSpecialty);
                                cells.Add(p.TotalTime);
                                cells.Add(p.TaskContent);

                                string roleStr = "未知";
                                if (p.IsProjectMaster == "true")
                                {
                                    roleStr = "项目负责人兼" + sub.SubjectName + "的" + p.JobInProject;
                                }
                                else
                                {
                                    roleStr = sub.SubjectName + "的" + p.JobInProject;
                                }

                                cells.Add(roleStr);

                                dt.Rows.Add(cells.ToArray());
                            }
                        }
                    }
                }
            }
            gcData.DataSource = dt;
        }

        private void srpSearch_OnResetClick(object sender, EventArgs args)
        {
            srpSearch.search();
        }

        private void srpSearch_OnExportToClick(object sender, EventArgs args)
        {
            BaseModuleController.exportToExcelWithDevExpress(dgvDetail);
        }
    }
}