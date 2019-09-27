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
                   cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
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

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                string content = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty;
                if (content != null && content.EndsWith(".doc"))
                {
                    if (File.Exists(content))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(content);
                        }
                        catch (Exception ex) { }
                    }
                }
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dataGridView1.Rows.Count <= 0) return;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty).ToString();
        }
    }
}