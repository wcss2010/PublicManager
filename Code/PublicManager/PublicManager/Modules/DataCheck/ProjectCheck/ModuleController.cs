using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using DevExpress.XtraGrid.Views.Grid;

namespace PublicManager.Modules.DataCheck.ProjectCheck
{
    public partial class ModuleController : BaseModuleController
    {
        private DEGridViewCellMergeAdapter cma1;
        private DEGridViewCellMergeAdapter cma2;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            dgvDetail.OptionsDetail.AllowExpandEmptyDetails = true;
            dgvDetail.OptionsDetail.ShowDetailTabs = false;
            cma1 = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3", "row4", "row5", "row6" });

            dgvSub.OptionsBehavior.Editable = false;
            dgvSub.OptionsView.AllowCellMerge = true;
            dgvSub.OptionsView.ShowGroupPanel = false;
            cma2 = new DEGridViewCellMergeAdapter(dgvSub, new string[] { "row1" });

            srpSearch.IsDisplayContractData = true;
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            exportToExcelWithDevExpress(dgvDetail);
        }

        private void dgvDetail_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                object objProjectID = view.GetRowCellValue(e.RowHandle, "row15");
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

        private void srpSearch_OnResetClick(object sender, EventArgs args)
        {
            srpSearch.search();
        }

        private void srpSearch_OnExportToClick(object sender, EventArgs args)
        {
            exportToExcelWithDevExpress(dgvDetail);
        }

        private void srpSearch_OnSearchClick(object sender, EventArgs args)
        {
            DataSet dsAll = new DataSet();
            DataTable masterDt = getTempDataTable("row", 20);
            DataTable detailDt = getTempDataTable("row", 9);

            List<Project> projList = MakeSQLWithSearchRule.getProjectList(srpSearch);
            foreach (Project proj in projList)
            {
                #region 主表数据
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
                Person masterPerson = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '' and IsProjectMaster = 'true'").select("*").getItem<Person>(new Person());
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
                cells.Add(string.Empty);
                cells.Add(proj.ProjectID);
                cells.Add(proj.Keywords);

                if (masterPerson != null && masterPerson.PersonID != null && masterPerson.PersonID.Length >= 1)
                {
                    cells.Add(masterPerson.Telephone);
                    cells.Add(masterPerson.Mobilephone);
                }
                else
                {
                    cells.Add(string.Empty);
                    cells.Add(string.Empty);
                }

                cells.Add(proj.DutyNormalUnit);

                cells.Add(proj.ProjectRange);

                masterDt.Rows.Add(cells.ToArray());
                #endregion

                #region 生成从表数据
                if (proj != null && !string.IsNullOrEmpty(proj.ProjectID))
                {
                    List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                    foreach (Subject sub in subList)
                    {
                        if (string.IsNullOrEmpty(srpSearch.Key1EditControl.Text) || ((srpSearch.getUsingRuleCount() == 0 || srpSearch.isUsingRule("课题")) && MakeSQLWithSearchRule.isDisplayData(typeof(Subject).Name, sub.SubjectID)) || proj.ProjectName.Contains(srpSearch.Key1EditControl.Text) || proj.Keywords.Contains(srpSearch.Key1EditControl.Text))
                        {
                            cells = new List<object>();
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
                            cells.Add(proj.ProjectID);

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

                            detailDt.Rows.Add(cells.ToArray());
                        }
                    }
                }
                #endregion
            }

            #region 生成从属关系数据
            masterDt.TableName = "MainView";
            detailDt.TableName = "SubjectView";
            dsAll.Tables.Add(masterDt);
            dsAll.Tables.Add(detailDt);

            DataColumn keyColumn = dsAll.Tables[masterDt.TableName].Columns["row15"];         //主键
            DataColumn foreignColumn = dsAll.Tables[detailDt.TableName].Columns["row6"];    //外键
            //
            //对于主从表，层次名至关重要，关系名必须和从表的层次名一致,
            //否则从表显示的是从表的所有字段，而不是所设计的显示字段
            //

            dsAll.Relations.Add(detailDt.TableName, keyColumn, foreignColumn, false);     //从表的层次名
            gcGrid.DataSource = dsAll.Tables[masterDt.TableName];
            #endregion
        }

        private void srpSearch_OnCustomButtonClick(object sender, CustomButtonEventArgs args)
        {
            if (args.ButtonName == "列选择器")
            {
                dgvDetail.ShowCustomization();
            }
        }

        private void dgvDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            int[] rowIndexxx = dgvDetail.GetSelectedRows();
            if (rowIndexxx != null && rowIndexxx.Length == 1)
            {
                //第一行  
                if (e.RowHandle == rowIndexxx[0])
                {
                    if (cma1.MergeFieldNameList.Contains(e.Column.FieldName))
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