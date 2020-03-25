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
using PublicManager.Modules.Lines.ProjectLines.Froms;

namespace PublicManager.Modules.Lines.ProjectLines
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
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3", "row4", "row5", "row6" });

            cbDisplayReporter.Checked = false;
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);

            this.loadData();
        }

        private void loadData()
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = getTempDataTable("row", 20);

            List<Project> projList = ConnectionManager.Context.table("Project").where("(ProjectName like '%" + txtKey.Text + "%')" + strCatalogIDFilterString).select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
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
                Person masterPerson = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '' and JobInProject = '负责人' and IsProjectMaster = 'true'").select("*").getItem<Person>(new Person());
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

                cells.Add(proj.OKQuestionMemo);
                cells.Add(proj.OKCheckA);
                cells.Add(proj.OKCheckB);
                cells.Add(proj.ContactCheckLevelA);
                cells.Add(proj.ContactCheckLevelB);
                cells.Add(proj.Memo);

                cells.Add(proj.ProjectID);
                dt.Rows.Add(cells.ToArray());
            }
            gcGrid.DataSource = dt;
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

        private void btnCheckProject_Click(object sender, EventArgs e)
        {
            int[] selecteds = dgvDetail.GetSelectedRows();
            if (selecteds != null && selecteds.Length >= 1)
            {
                object objValue = dgvDetail.GetRowCellValue(selecteds[0], "row20");
                if (objValue != null && !string.IsNullOrEmpty(objValue.ToString()))
                {
                    string projectId = objValue.ToString();

                    Project proj = ConnectionManager.Context.table("Project").where("ProjectID='" + projectId + "'").select("*").getItem<Project>(new Project());
                    if (new CheckEditForm(proj).ShowDialog() == DialogResult.OK)
                    {
                        btnSearch.PerformClick();
                    }
                }
            }
        }
    }
}