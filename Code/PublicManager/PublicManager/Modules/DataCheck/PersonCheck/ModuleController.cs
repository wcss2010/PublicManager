﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;

namespace PublicManager.Modules.DataCheck.PersonCheck
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
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row1" });
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
            DataTable dt = getTempDataTable("row", 13);

            List<Project> projList = ConnectionManager.Context.table("Project").where("(ProjectName like '%" + txtKey.Text + "%' or ProjectID in (select ProjectID from Subject where SubjectName like '%" + txtKey.Text + "%') or ProjectID in (select ProjectID from Person where PersonName like '%" + txtKey.Text + "%'))" + strCatalogIDFilterString).select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                //显示仅为项目负责人
                Person masterPersonObj = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '' and JobInProject = '负责人' and IsProjectMaster = 'true'").select("*").getItem<Person>(new Person());
                if (masterPersonObj != null && masterPersonObj.PersonID != null && masterPersonObj.PersonID.Length >= 1)
                {
                    if ((masterPersonObj.PersonName == null || !masterPersonObj.PersonName.Contains(txtKey.Text)) && (proj.ProjectName == null || !proj.ProjectName.Contains(txtKey.Text)))
                    {
                        //
                    }
                    else
                    {
                        //存在仅为负责人的记录
                        List<object> cells = new List<object>();
                        cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                        cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                        cells.Add(proj.ProjectName);
                        cells.Add("*****");
                        cells.Add(masterPersonObj.PersonName);
                        cells.Add(masterPersonObj.PersonIDCard);
                        cells.Add(masterPersonObj.PersonSex);
                        cells.Add(masterPersonObj.WorkUnit);
                        cells.Add(masterPersonObj.PersonJob);
                        cells.Add(masterPersonObj.PersonSpecialty);
                        cells.Add(masterPersonObj.TotalTime);
                        cells.Add(masterPersonObj.TaskContent);

                        cells.Add("项目负责人");

                        dt.Rows.Add(cells.ToArray());
                    }
                }

                //显示课题成员
                List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                foreach (Subject sub in subList)
                {
                    List<Person> perList = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "'").select("*").getList<Person>(new Person());
                    foreach (Person p in perList)
                    {
                        if ((p.PersonName == null || !p.PersonName.Contains(txtKey.Text)) && (proj.ProjectName == null || !proj.ProjectName.Contains(txtKey.Text)) && (sub.SubjectName == null || !sub.SubjectName.Contains(txtKey.Text)))
                        {
                            continue;
                        }

                        List<object> cells = new List<object>();
                        cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
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

                        dt.Rows.Add(cells.ToArray());
                    }
                }
            }
            gcData.DataSource = dt;
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
            BaseModuleController.exportToExcelWithDevExpress(dgvDetail);
        }
    }
}