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

namespace PublicManager.Modules.DataCheck.AddressCheck
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
            cbOrgList.SelectedIndex = 0;

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3" });

            cbDisplayReporter.Checked = false;
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = getTempDataTable("row", 7);

            List<Project> projList = ConnectionManager.Context.table("Project").where("ProjectID in (select ProjectID from Subject where " + (string.IsNullOrEmpty(txtKey.Text) ? "1=1" : "DutyUnitAddress like '%" + txtKey.Text + "%' or DutyUnit like '%" + txtKey.Text + "%'") + (cbOrgList.SelectedItem.ToString() == "全部" ? string.Empty : " and DutyUnitOrg = '" + cbOrgList.SelectedItem.ToString() + "'") + ")" + strCatalogIDFilterString).select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
               List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
               foreach (Subject sub in subList)
               {
                   if (sub.DutyUnitOrg == cbOrgList.SelectedItem.ToString() || cbOrgList.SelectedItem.ToString() == "全部")
                   {
                       if (!string.IsNullOrEmpty(txtKey.Text) && ((sub.DutyUnit != null && !sub.DutyUnit.Contains(txtKey.Text)) && (sub.DutyUnitAddress != null && !sub.DutyUnitAddress.Contains(txtKey.Text))))
                       {
                           continue;
                       }

                       List<object> cells = new List<object>();
                       cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                       cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                       cells.Add(proj.ProjectName);
                       cells.Add(sub.SubjectName);
                       cells.Add(sub.DutyUnit);
                       cells.Add(sub.DutyUnitOrg);
                       cells.Add(sub.DutyUnitAddress);

                       dt.Rows.Add(cells.ToArray());
                   }
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

        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnSearch.PerformClick();
            }
        }

        private void cbOrgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnSearch.PerformClick();
        }
    }
}