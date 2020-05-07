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
        private DEGridViewCellMergeAdapter cma;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3" });

            srpSearch.IsDisplayContractData = true;
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
            DataTable dt = getTempDataTable("row", 12);

            List<Project> projList = MakeSQLWithSearchRule.getProjectList(srpSearch);
            foreach (Project proj in projList)
            {
               List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
               foreach (Subject sub in subList)
               {
                   if (string.IsNullOrEmpty(srpSearch.Key1EditControl.Text) || ((srpSearch.getUsingRuleCount() == 0 || srpSearch.isUsingRule("课题")) && MakeSQLWithSearchRule.isDisplayData(typeof(Subject).Name, sub.SubjectID)) || srpSearch.isUsingRule("项目") == true)
                   {
                       List<object> cells = new List<object>();
                       cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                       cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                       cells.Add(proj.ProjectName);
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

                       if (cells[1] != null && cells[1].ToString() == "合同书")
                       {
                           //合同书总经费
                           //cells.Add(ConnectionManager.Context.table("Dicts").where("CatalogID = '" + proj.CatalogID + "' and SubjectID ='" + sub.SubjectID + "' and DictType='SubjectMoney,SubjectMoneyInfo' and DictName = 'Money1'").select("DictValue").getValue<string>(""));
                           cells.Add(sub.TotalMoney);
                       }
                       else
                       {
                           //建议书总经费
                           cells.Add(sub.TotalMoney);
                       }

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

                       cells.Add(sub.SecretLevel);

                       dt.Rows.Add(cells.ToArray());
                   }
               }
            }
            gcGrid.DataSource = dt;
        }

        private void srpSearch_OnResetClick(object sender, EventArgs args)
        {
            srpSearch.search();
        }

        private void srpSearch_OnExportToClick(object sender, EventArgs args)
        {
            exportToExcelWithDevExpress(dgvDetail);
        }

        private void srpSearch_OnCustomButtonClick(object sender, CustomButtonEventArgs args)
        {
            if (args.ButtonName == "列选择器")
            {
                dgvDetail.ShowCustomization();
            }
        }

        private void dgvDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int[] rowIndexxx = dgvDetail.GetSelectedRows();
            if (rowIndexxx != null && rowIndexxx.Length == 1)
            {
                //第一行  
                if (e.RowHandle == rowIndexxx[0])
                {
                    if (cma.MergeFieldNameList.Contains(e.Column.FieldName))
                    {
                        return;
                    }

                    e.Appearance.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    e.Appearance.Reset();
                }
            }
            else
            {
                e.Appearance.Reset();
            }
        }
    }
}