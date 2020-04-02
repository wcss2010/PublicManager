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

namespace PublicManager.Modules.DataCheck.SubjectCheck
{
    public partial class ModuleController : BaseModuleController
    {
        /// <summary>
        /// CatalogID筛选条件
        /// </summary>
        string strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
        private DEGridViewCellMergeAdapter cma;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3" });

            cbDisplayReporter.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = getTempDataTable("row", 11);

            List<Project> projList = ConnectionManager.Context.table("Project").where("(ProjectName like '%" + txtKey.Text + "%' or ProjectID in (select ProjectID from Subject where SubjectName like '%" + txtKey.Text + "%'))" + strCatalogIDFilterString).select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
               List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
               foreach (Subject sub in subList)
               {
                   if ((proj.ProjectName == null || !proj.ProjectName.Contains(txtKey.Text)) && (sub.SubjectName == null || !sub.SubjectName.Contains(txtKey.Text)))
                   {
                       continue;
                   }

                   List<object> cells = new List<object>();
                   cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                   cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                   cells.Add(proj.ProjectName);
                   cells.Add(sub.SubjectName);

                   Person personObj = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "' and JobInProject = '负责人'").select("*").getItem<Person>(new Person());
                   if (string.IsNullOrEmpty(personObj.PersonID))
                   {
                       continue;
                   }
                   else
                   {
                       cells.Add(personObj.PersonName);
                   }

                   cells.Add(sub.DutyUnit);
                   cells.Add(sub.DutyUnitOrg);
                   cells.Add(sub.DutyUnitAddress);

                   if (cells[1] != null && cells[1].ToString() == "合同书")
                   {
                       //合同书总经费
                       cells.Add(ConnectionManager.Context.table("Dicts").where("CatalogID = '" + proj.CatalogID + "' and SubjectID ='" + sub.SubjectID + "' and DictType='SubjectMoney,SubjectMoneyInfo' and DictName = 'Money1'").select("DictValue").getValue<string>(""));
                   }
                   else
                   {
                       //建议书总经费
                       cells.Add(sub.TotalMoney);
                   }

                   if (string.IsNullOrEmpty(personObj.PersonID))
                   {
                       continue;
                   }
                   else
                   {
                       cells.Add(personObj.Telephone);
                       cells.Add(personObj.Mobilephone);
                   }

                   dt.Rows.Add(cells.ToArray());
               }
            }
            gcGrid.DataSource = dt;
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);
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

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            exportToExcelWithDevExpress(dgvDetail);
        }
    }
}