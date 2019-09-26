using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;

namespace PublicManager.Modules.DataCheck.ProjectPersonCheck
{
    public partial class ModuleController : BaseModuleController
    {
        public ModuleController()
        {
            InitializeComponent();
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Project> projList = ConnectionManager.Context.table("Project").where("ProjectName like '%" + txtKey.Text + "%'").select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                //显示仅为项目负责人
                //Person masterPerson = ConnectionManager.Context.table("Person").where
                //显示课题成员
                List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                foreach (Subject sub in subList)
                {
                    List<Person> perList = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "'").select("*").getList<Person>(new Person());
                    foreach (Person p in perList)
                    {
                        List<object> cells = new List<object>();
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

                        dataGridView1.Rows.Add(cells.ToArray());
                    }
                }
            }
        }
    }
}