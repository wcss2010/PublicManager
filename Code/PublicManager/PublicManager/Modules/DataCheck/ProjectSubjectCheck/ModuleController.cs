using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;

namespace PublicManager.Modules.DataCheck.ProjectSubjectCheck
{
    public partial class ModuleController : BaseModuleController
    {
        public ModuleController()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Project> projList = ConnectionManager.Context.table("Project").where("ProjectName like '%" + txtKey.Text + "%'").select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
               List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
               foreach (Subject sub in subList)
               {
                   List<object> cells = new List<object>();
                   cells.Add(proj.ProjectName);
                   cells.Add(sub.SubjectName);
                   cells.Add(sub.TotalMoney);
                   cells.Add(sub.WorkDest);
                   cells.Add(sub.WorkContent);
                   cells.Add(sub.WorkTask);

                   dataGridView1.Rows.Add(cells.ToArray());
               }
            }
        }
    }
}