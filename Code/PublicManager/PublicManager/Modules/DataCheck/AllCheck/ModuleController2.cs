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
using System.IO;
using System.Diagnostics;

namespace PublicManager.Modules.DataCheck.AllCheck
{
    public partial class ModuleController2 : BaseModuleController
    {
        private string strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";

        private DEGridViewCellMergeAdapterWithPT cma;

        private bool isFirstLoad = true;

        public ModuleController2()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapterWithPT(dgvDetail, new string[] { "row1", "row2", "row3", "row5", "row7", "row9", "row11", "row13", "row14", "row15" }, "row17");
            //cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row1", "row2", "row3", "row5", "row7", "row9", "row11" });
            //dgvDetail.OptionsView.RowAutoHeight = true;

            switchCatalogType(true, false);
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);

            if (isFirstLoad)
            {
                reloadData();
                isFirstLoad = false;
            }
        }

        public void reloadData()
        {
            DataTable dt = getTempDataTable("row", 17);

            List<Project> projList = ConnectionManager.Context.table("Project").where("IsNeedHide='0'" + strCatalogIDFilterString).select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                //项目类型
                string catalogType = ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知");

                //路径
                string decompressDir = ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogDecompressDir").getValue<string>("未知");

                //节点评估时间
                StringBuilder nodeTimeString = new StringBuilder();
                List<MoneySends> nodeList = ConnectionManager.Context.table("MoneySends").where("(CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "')").orderBy("NodeIndex").select("*").getList<MoneySends>(new MoneySends());
                foreach (MoneySends mss in nodeList)
                {
                    nodeTimeString.Append(mss.NodeIndex).Append(":").Append(ExcelHelper.getDateTimeForString(mss.WillTime, "yyyy年MM月dd日", string.Empty)).AppendLine();
                }

                List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                foreach (Subject sub in subList)
                {
                    List<object> cells = new List<object>();

                    //项目领域
                    cells.Add(proj.Domains);

                    //计划批次
                    cells.Add(proj.TaskNumber);

                    //项目名称
                    cells.Add(proj.ProjectName);

                    //课题名称
                    cells.Add(sub.SubjectName);

                    //项目负责人
                    Person masterPerson = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '' and IsProjectMaster = 'true'").select("*").getItem<Person>(new Person());
                    if (masterPerson != null && masterPerson.PersonID != null && masterPerson.PersonID.Length >= 1)
                    {
                        cells.Add(masterPerson.PersonName);
                    }
                    else
                    {
                        cells.Add(string.Empty);
                    }

                    //课题负责人
                    Person subjectPerson = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "' and JobInProject = '负责人'").select("*").getItem<Person>(new Person());
                    if (string.IsNullOrEmpty(subjectPerson.PersonID))
                    {
                        cells.Add(string.Empty);
                    }
                    else
                    {
                        cells.Add(subjectPerson.PersonName);
                    }

                    //项目牵头单位
                    cells.Add(proj.DutyUnit);

                    //课题负责单位
                    cells.Add(sub.DutyUnit);

                    //项目牵头单位地址
                    cells.Add(proj.DutyUnitAddress);

                    //课题负责单位所在地址
                    cells.Add(sub.DutyUnitAddress);

                    //项目牵头单位所属单位
                    cells.Add(proj.DutyUnitOrg);

                    //课题负责单位所属单位
                    cells.Add(sub.DutyUnitOrg);

                    //合同审查等级
                    cells.Add(proj.ContactCheckLevelA);

                    //节点评估时间                    
                    cells.Add(nodeTimeString.ToString());

                    //项目牵头单位常用名
                    cells.Add(proj.DutyNormalUnit);

                    //PDF路径
                    if (catalogType == "合同书")
                    {
                        //合同书PDF
                        cells.Add(Path.Combine(decompressDir, "合同书.pdf"));
                    }
                    else
                    {
                        //建议书PDF
                        cells.Add(Path.Combine(decompressDir, "建议书.pdf"));
                    }

                    cells.Add(proj.ProjectID);

                    dt.Rows.Add(cells.ToArray());
                }
            }
            gcGrid.DataSource = dt;
        }

        private void btnColSelect_Click(object sender, EventArgs e)
        {
            dgvDetail.ShowCustomization();
        }

        private void cbDisplayContract_CheckedChanged(object sender, EventArgs e)
        {
            switchCatalogType(cbDisplayContract.Checked, cbDisplayReporter.Checked);
            reloadData();
        }

        /// <summary>
        /// 切换目录类型
        /// </summary>
        /// <param name="isContract"></param>
        /// <param name="isReporter"></param>
        protected void switchCatalogType(bool isContract, bool isReporter)
        {
            if (isContract && isReporter)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
            }
            else if (isContract)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog where CatalogType = '合同书')";
            }
            else if (isReporter)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog where CatalogType = '建议书')";
            }
            else
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
            }
        }

        private void btnOpenPDF_Click(object sender, EventArgs e)
        {
            if (dgvDetail.GetSelectedRows() != null && dgvDetail.GetSelectedRows().Length == 1)
            {
                object objValue = dgvDetail.GetRowCellValue(dgvDetail.GetSelectedRows()[0], "row16");
                if (objValue != null && !string.IsNullOrEmpty(objValue.ToString()))
                {
                    string pdfFile = objValue.ToString();

                    if (File.Exists(pdfFile))
                    {
                        try
                        {
                            Process.Start(pdfFile);
                        }
                        catch (Exception ex) { }
                    }
                    else
                    {
                        MessageBox.Show("对不起，当前项目不存在PDF文档！");
                    }
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
        }
    }
}