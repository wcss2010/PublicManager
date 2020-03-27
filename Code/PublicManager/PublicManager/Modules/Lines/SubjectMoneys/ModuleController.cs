using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.DB.Entitys;

namespace PublicManager.Modules.Lines.SubjectMoneys
{
    public partial class ModuleController : BaseModuleController
    {
        public ModuleController()
        {
            InitializeComponent();

            gvDetail.OptionsBehavior.Editable = false;
            //gvDetail.OptionsView.AllowCellMerge = true;
            //cma = new DEGridViewCellMergeAdapter(gvDetail, new string[] { "row3" });
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);

            tvProjectList.ContentTreeView.AfterSelect += tvProjectList_AfterSelect;

            this.loadData();
        }

        private void loadData()
        {
            tvProjectList.ContentTreeView.Nodes.Clear();
            List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").where("CatalogType='合同书'").select("*").getList<Catalog>(new Catalog());
            foreach (Catalog catalog in catalogList)
            {
                TreeNode parentNode = new TreeNode();
                parentNode.Text = catalog.CatalogName + "(" + catalog.CatalogVersion + ")";
                parentNode.Tag = catalog;
                tvProjectList.ContentTreeView.Nodes.Add(parentNode);

                //节点
                List<MoneySends> subList = ConnectionManager.Context.table("MoneySends").where("(CatalogID = '" + catalog.CatalogID + "' and ProjectID = '" + catalog.CatalogID + "')").select("*").getList<MoneySends>(new MoneySends());
                int indexxxx = 0;
                foreach (MoneySends mss in subList)
                {
                    indexxxx++;

                    TreeNode nodeSub = new TreeNode();
                    nodeSub.Text = "节点" + indexxxx + "(" + mss.SendRule + ")";
                    nodeSub.Tag = mss;
                    parentNode.Nodes.Add(nodeSub);

                    //课题金额
                    List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalog.CatalogID + "' and ProjectID='" + catalog.CatalogID + "'").select("*").getList<Subject>(new Subject());
                    foreach (Subject sub in subjectList)
                    {
                        TreeNode subjectNode = new TreeNode();
                        subjectNode.Text = sub.SubjectName;
                        subjectNode.Tag = sub;
                        nodeSub.Nodes.Add(subjectNode);
                    }
                }
            }
        }

        private void tvProjectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<List<object>> objectList = new List<List<object>>();

            if (e.Node.Tag is Catalog)
            {
                //项目年度列表
                Catalog catalogObj = (Catalog)e.Node.Tag;

                #region 显示数据
                DataTable dt = getTempDataTable("row", 9);

                foreach (TreeNode ptnss in e.Node.Nodes)
                {
                    MoneySends moneySendObj = (MoneySends)ptnss.Tag;

                    foreach (TreeNode tns in ptnss.Nodes)
                    {
                        Subject subjectObj = (Subject)tns.Tag;

                        //显示节点经费
                        List<Contact_Table5> moneyss = ConnectionManager.Context.table("Contact_Table5").where("NodeID='" + moneySendObj.MSID + "' and SubjectID = '" + subjectObj.SubjectID + "'").select("*").getList<Contact_Table5>(new Contact_Table5());
                        foreach (Contact_Table5 mObj in moneyss)
                        {
                            List<object> cells = new List<object>();

                            cells.Add(subjectObj.SubjectName);
                            cells.Add(mObj.SubjectWorkUnit);
                            cells.Add(mObj.SubjectTotalMoney);
                            cells.Add(mObj.SubjectSendMoney);
                            cells.Add(mObj.SubjectSendTime);
                            cells.Add(mObj.SubjectSendedMoney);
                            cells.Add(mObj.SubjectUseMoney);
                            cells.Add(mObj.SubjectNoSendMoney);
                            cells.Add(ptnss.Text);

                            dt.Rows.Add(cells.ToArray());
                        }
                        gcGrid.DataSource = dt;
                    }
                }
                #endregion
            }
            else if (e.Node.Tag is Subject)
            {
                //项目年度列表
                Subject subjectObj = (Subject)e.Node.Tag;
                MoneySends moneySendObj = (MoneySends)e.Node.Parent.Tag;

                #region 显示数据
                DataTable dt = getTempDataTable("row", 9);
                //显示节点经费
                List<Contact_Table5> moneyss = ConnectionManager.Context.table("Contact_Table5").where("NodeID='" + moneySendObj.MSID + "' and SubjectID = '" + subjectObj.SubjectID + "'").select("*").getList<Contact_Table5>(new Contact_Table5());
                foreach (Contact_Table5 mObj in moneyss)
                {
                    List<object> cells = new List<object>();

                    cells.Add(subjectObj.SubjectName);
                    cells.Add(mObj.SubjectWorkUnit);
                    cells.Add(mObj.SubjectTotalMoney);
                    cells.Add(mObj.SubjectSendMoney);
                    cells.Add(mObj.SubjectSendTime);
                    cells.Add(mObj.SubjectSendedMoney);
                    cells.Add(mObj.SubjectUseMoney);
                    cells.Add(mObj.SubjectNoSendMoney);
                    cells.Add(e.Node.Text);

                    dt.Rows.Add(cells.ToArray());
                }
                gcGrid.DataSource = dt;
                #endregion
            }
            else if (e.Node.Tag is MoneySends)
            {
                //项目年度列表
                MoneySends moneySendObj = (MoneySends)e.Node.Tag;

                #region 显示数据
                DataTable dt = getTempDataTable("row", 9);
                foreach (TreeNode tns in e.Node.Nodes)
                {
                    Subject subjectObj = (Subject)tns.Tag;

                    //显示节点经费
                    List<Contact_Table5> moneyss = ConnectionManager.Context.table("Contact_Table5").where("NodeID='" + moneySendObj.MSID + "' and SubjectID = '" + subjectObj.SubjectID + "'").select("*").getList<Contact_Table5>(new Contact_Table5());
                    foreach (Contact_Table5 mObj in moneyss)
                    {
                        List<object> cells = new List<object>();

                        cells.Add(subjectObj.SubjectName);
                        cells.Add(mObj.SubjectWorkUnit);
                        cells.Add(mObj.SubjectTotalMoney);
                        cells.Add(mObj.SubjectSendMoney);
                        cells.Add(mObj.SubjectSendTime);
                        cells.Add(mObj.SubjectSendedMoney);
                        cells.Add(mObj.SubjectUseMoney);
                        cells.Add(mObj.SubjectNoSendMoney);
                        cells.Add(e.Node.Text);

                        dt.Rows.Add(cells.ToArray());
                    }
                    gcGrid.DataSource = dt;
                }
                #endregion
            }
        }
    }
}