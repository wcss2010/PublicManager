using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB.Entitys;
using PublicManager.DB;

namespace PublicManager.Modules.MainPage
{
    public partial class ModuleController : BaseModuleController
    {
        private DEGridViewCellMergeAdapter cma;
        public ModuleController()
        {
            InitializeComponent();

            gvDetail.OptionsBehavior.Editable = false;
            gvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(gvDetail, new string[] { "row1" });

            switchNodeData();
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);

            //this.tvProjectList.ContentTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProjectList_AfterSelect);

            loadData();
        }

        private void loadData()
        {
            //tvProjectList.ContentTreeView.Nodes.Clear();
            //List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").where("CatalogType='合同书'").select("*").getList<Catalog>(new Catalog());
            //foreach (Catalog catalog in catalogList)
            //{
            //    TreeNode parentNode = new TreeNode();
            //    parentNode.Text = catalog.CatalogName + "(" + catalog.CatalogVersion + ")";
            //    parentNode.Tag = catalog;
            //    tvProjectList.ContentTreeView.Nodes.Add(parentNode);

            //    ////课题金额
            //    //List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalog.CatalogID + "' and ProjectID='" + catalog.CatalogID + "'").select("*").getList<Subject>(new Subject());
            //    //foreach (Subject sub in subjectList)
            //    //{
            //    //    TreeNode subjectNode = new TreeNode();
            //    //    subjectNode.Text = sub.SubjectName;
            //    //    subjectNode.Tag = sub;
            //    //    parentNode.Nodes.Add(subjectNode);
            //    //}
            //}
        }

        private void rbCurrentMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNodeSearch.Checked)
            {
                plSearchBar.Enabled = true;
            }
            else
            {
                plSearchBar.Enabled = false;
            }

            switchNodeData();
        }

        private void switchNodeData()
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.Now;

            if (rbCurrentMonth.Checked)
            {
                //当月
                int monthDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, monthDay, 23, 59, 59);
            }
            else if (rbNextMonth.Checked)
            {
                //下月
                int monthDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month + 1);
                d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1, 0, 0, 0);
                d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, monthDay, 23, 59, 59);
            }

            reloadNodeView(d1, d2);
        }

        private void reloadNodeView(DateTime start, DateTime end)
        {
            DataTable dtTemp = getTempDataTable("row", 4);

            List<MoneySends> nodeList = ConnectionManager.Context.table("MoneySends").select("*").getList<MoneySends>(new MoneySends());
            foreach (MoneySends mss in nodeList)
            {
                if (mss.WillTime >= start && mss.WillTime <= end)
                {
                    List<object> cells = new List<object>();

                    Project projObj = ConnectionManager.Context.table("Project").where("ProjectID='" + mss.ProjectID + "'").select("*").getItem<Project>(new Project());
                    if (string.IsNullOrEmpty(projObj.ProjectID))
                    {
                        continue;
                    }
                    else
                    {
                        cells.Add(projObj.ProjectName);
                        cells.Add(mss.SendRule);
                        cells.Add(ExcelHelper.getDateTimeForString(mss.WillTime, "yyyy年MM月dd日", string.Empty));
                        cells.Add(string.Empty);

                        dtTemp.Rows.Add(cells.ToArray());
                    }
                }
            }
            gcData.DataSource = dtTemp;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime d1 = new DateTime(txtStartTime.Value.Year, txtStartTime.Value.Month, txtStartTime.Value.Day, 0, 0, 0);
            DateTime d2 = new DateTime(txtEndTime.Value.Year, txtEndTime.Value.Month, txtEndTime.Value.Day, 23, 59, 59);

            reloadNodeView(d1, d2);
        }
    }
}