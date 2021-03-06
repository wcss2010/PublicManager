﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB.Entitys;
using PublicManager.DB;
using PublicManager.Modules.DataLoad.ManagerInfoEdit.Froms;

namespace PublicManager.Modules.DataLoad.ManagerInfoEdit
{
    public partial class ModuleController : BaseModuleController
    {
        private DEGridViewCellMergeAdapter cma;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3", "row4", "row23" });

            srpSearch.IsDisplayContractData = true;
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

        private void srpSearch_OnSearchClick(object sender, EventArgs args)
        {
            DataTable dt = getTempDataTable("row", 26);

            List<Project> projList = MakeSQLWithSearchRule.getProjectList(srpSearch);
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

                cells.Add(proj.OKQuestionMemo);
                cells.Add(proj.OKCheckA);
                cells.Add(proj.OKCheckB);
                cells.Add(proj.ContactCheckLevelA);
                cells.Add(proj.ContactCheckLevelB);
                cells.Add(proj.Memo);

                cells.Add(proj.ProjectID);

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

                cells.Add(proj.ProjectRange);

                cells.Add(proj.DutyNormalUnit);

                cells.Add(proj.IsCheckUnitComplete);

                cells.Add("修改");

                dt.Rows.Add(cells.ToArray());
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
            if (args.ButtonName == "管理员信息完善")
            {
                int[] selecteds = dgvDetail.GetSelectedRows();
                if (selecteds != null && selecteds.Length >= 1)
                {
                    object objValue = dgvDetail.GetRowCellValue(selecteds[0], "row20");
                    if (objValue != null && !string.IsNullOrEmpty(objValue.ToString()))
                    {
                        string projectId = objValue.ToString();

                        Project proj = ConnectionManager.Context.table("Project").where("ProjectID='" + projectId + "'").select("*").getItem<Project>(new Project());
                        if (new ModifyManagerInfoForm(proj).ShowDialog() == DialogResult.OK)
                        {
                            //刷新综合查询
                            if (MainForm.ModuleDict.ContainsKey(MainForm.allCheckKey))
                            {
                                ((PublicManager.Modules.DataCheck.AllCheck.ModuleController2)MainForm.ModuleDict[MainForm.allCheckKey]).reloadData();
                            }

                            srpSearch.search();
                        }
                    }
                }
            }
            else if (args.ButtonName == "列选择器")
            {
                dgvDetail.ShowCustomization();
            }
            else if (args.ButtonName == "批量修改项目领域/技术方向")
            {
                ModifyManagerInfoWithSelectedForm xlcf = new ModifyManagerInfoWithSelectedForm(srpSearch, "项目领域/技术方向:");
                if (xlcf.ShowDialog() == DialogResult.OK)
                {
                    //刷新综合查询
                    if (MainForm.ModuleDict.ContainsKey(MainForm.allCheckKey))
                    {
                        ((PublicManager.Modules.DataCheck.AllCheck.ModuleController2)MainForm.ModuleDict[MainForm.allCheckKey]).reloadData();
                    }

                    srpSearch.search();
                }
            }
            else if (args.ButtonName == "批量修改计划批次")
            {
                ModifyManagerInfoWithSelectedForm xlcf = new ModifyManagerInfoWithSelectedForm(srpSearch, "计划批次:");
                if (xlcf.ShowDialog() == DialogResult.OK)
                {
                    //刷新综合查询
                    if (MainForm.ModuleDict.ContainsKey(MainForm.allCheckKey))
                    {
                        ((PublicManager.Modules.DataCheck.AllCheck.ModuleController2)MainForm.ModuleDict[MainForm.allCheckKey]).reloadData();
                    }

                    srpSearch.search();
                }
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

            if (e.Column.FieldName == "row25")
            {
                object unitObj = dgvDetail.GetRowCellValue(e.RowHandle, "row25");
                if (unitObj != null && unitObj.ToString() == "不通过")
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
        }

        private void dgvDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "row26")
            {
                object objValue = dgvDetail.GetRowCellValue(e.RowHandle, "row20");
                if (objValue != null && !string.IsNullOrEmpty(objValue.ToString()))
                {
                    string projectId = objValue.ToString();

                    Project proj = ConnectionManager.Context.table("Project").where("ProjectID='" + projectId + "'").select("*").getItem<Project>(new Project());
                    if (new ModifyNormalUnitForm(proj).ShowDialog() == DialogResult.OK)
                    {
                        //刷新综合查询
                        if (MainForm.ModuleDict.ContainsKey(MainForm.allCheckKey))
                        {
                            ((PublicManager.Modules.DataCheck.AllCheck.ModuleController2)MainForm.ModuleDict[MainForm.allCheckKey]).reloadData();
                        }

                        srpSearch.search();
                    }
                }
            }
        }
    }
}