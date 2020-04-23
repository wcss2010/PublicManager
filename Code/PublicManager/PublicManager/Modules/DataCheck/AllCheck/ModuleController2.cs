using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB.Entitys;
using PublicManager.DB;

namespace PublicManager.Modules.DataCheck.AllCheck
{
    public partial class ModuleController2 : BaseModuleController
    {
        private DEGridViewCellMergeAdapter cma;

        public ModuleController2()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row1", "row2", "row3" });
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
            DataTable dt = getTempDataTable("row", 14);

            List<Project> projList = ConnectionManager.Context.table("Project").select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                //项目类型
                string catalogType = ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知");

                List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                foreach (Subject sub in subList)
                {
                    List<object> cells = new List<object>();

                    //项目领域
                    cells.Add(proj.Domains);

                    //计划批次
                    cells.Add(proj.TaskNumber);

                    //项目名称
                    cells.Add(proj.ProjectName);

                    //课题名称
                    cells.Add(sub.SubjectName);

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

                    //课题负责人
                    Person subjectPerson = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "' and JobInProject = '负责人'").select("*").getItem<Person>(new Person());
                    if (string.IsNullOrEmpty(subjectPerson.PersonID))
                    {
                        cells.Add(string.Empty);
                    }
                    else
                    {
                        cells.Add(subjectPerson.PersonName);
                    }

                    //项目牵头单位
                    cells.Add(proj.DutyUnit);

                    //课题负责单位
                    cells.Add(sub.DutyUnit);

                    //项目牵头单位地址
                    cells.Add(proj.DutyUnitAddress);

                    //课题负责单位所在地址
                    cells.Add(sub.DutyUnitAddress);

                    //项目牵头单位所属单位
                    cells.Add(proj.DutyUnitOrg);

                    //课题负责单位所属单位
                    cells.Add(sub.DutyUnitOrg);

                    //合同审查等级
                    cells.Add(proj.ContactCheckLevelA);

                    //节点评估时间
                    cells.Add("");

                    dt.Rows.Add(cells.ToArray());
                }
            }
            gcGrid.DataSource = dt;
        }
    }
}