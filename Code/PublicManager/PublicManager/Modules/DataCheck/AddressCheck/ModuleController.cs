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
        private DEGridViewCellMergeAdapter cma;

        public ModuleController()
        {
            InitializeComponent();

            srpSearch.Key2EditControl.Items.AddRange(new object[]
            {
            "全部",
            "陆军",
            "海军",
            "空军",
            "火箭军",
            "战略支援部队",
            "联合勤务保障部队",
            "军委机关直属单位",
            "军事科学院",
            "国防大学",
            "国防科技大学",
            "武警部队",
            "教育部",
            "工信部",
            "中国科学院",
            "中国兵器工业集团公司",
            "中国兵器装备集团公司",
            "中国船舶工业集团公司",
            "中国船舶重工集团公司",
            "中国电子科技集团公司",
            "中国电子信息产业集团公司",
            "中国航空发动机集团公司",
            "中国航空工业集团公司",
            "中国航天科工集团公司",
            "中国航天科技集团公司",
            "中国核工业集团公司",
            "中国工程物理研究院",
            "其它"
            });
            srpSearch.Key2EditControl.SelectedIndex = 0;

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3" });

            srpSearch.IsDisplayReporterData = false;
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
            DataTable dt = getTempDataTable("row", 7);

            List<Project> projList = MakeSQLWithSearchRule.getProjectList(srpSearch);
            foreach (Project proj in projList)
            {
                List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                foreach (Subject sub in subList)
                {
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
    }
}