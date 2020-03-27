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

namespace PublicManager.Modules.Lines.MoneyLines
{
    public partial class ModuleController : BaseModuleController
    {
        public ModuleController()
        {
            InitializeComponent();
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

                ////课题金额
                //List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalog.CatalogID + "' and ProjectID='" + catalog.CatalogID + "'").select("*").getList<Subject>(new Subject());
                //foreach (Subject sub in subjectList)
                //{
                //    TreeNode subjectNode = new TreeNode();
                //    subjectNode.Text = sub.SubjectName;
                //    subjectNode.Tag = sub;
                //    parentNode.Nodes.Add(subjectNode);
                //}

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
                }
            }
        }

        private void tvProjectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<List<object>> objectList = new List<List<object>>();
            if (e.Node.Tag is Catalog)
            {
                Catalog catalogObj = (Catalog)e.Node.Tag;

                //显示总的经费
            }
            else if (e.Node.Tag is MoneySends)
            {
                #region 显示金额表
                MoneySends moneySendObj = (MoneySends)e.Node.Tag;
                DataTable dtData = mlpMoneys.getTempMoneyTable("row", e.Node.Parent.Nodes.Count);
                mlpMoneys.showOrHideTopPanel(false);
                int nodeIndex = e.Node.Parent.Nodes.IndexOf(e.Node);
                mlpMoneys.showOrHideColumn(dtData.Columns.Count - 2, false);
                for (int ttt = 0; ttt < e.Node.Parent.Nodes.Count; ttt++)
                {
                    mlpMoneys.showOrHideColumn(2 + ttt, false);
                }

                //显示节点经费
                List<Contact_Table4> moneyss = ConnectionManager.Context.table("Contact_Table4").where("NodeID='" + moneySendObj.MSID + "'").select("*").getList<Contact_Table4>(new Contact_Table4());
                foreach (Contact_Table4 mObj in moneyss)
                {
                    try
                    {
                        if (mObj.ModuleName != null)
                        {
                            if (mObj.ModuleName.StartsWith("项目合同"))
                            {
                                string[] tttt = mObj.ModuleName.Split(new string[] { "xxxxx" }, StringSplitOptions.None);
                                if (tttt != null && tttt.Length >= 2)
                                {
                                    dtData.Rows[(int.Parse(tttt[1]) - 1)][1] = mObj.ModuleValue;
                                }
                            }
                            else if (mObj.ModuleName.StartsWith("本阶段支出经费"))
                            {
                                string[] tttt = mObj.ModuleName.Split(new string[] { "xxxxx" }, StringSplitOptions.None);
                                if (tttt != null && tttt.Length >= 2)
                                {
                                    mlpMoneys.showOrHideColumn(2 + nodeIndex, true);
                                    dtData.Rows[(int.Parse(tttt[1]) - 1)][2 + nodeIndex] = mObj.ModuleValue;
                                }
                            }
                            else if (mObj.ModuleName.StartsWith("备注"))
                            {
                                string[] tttt = mObj.ModuleName.Split(new string[] { "xxxxx" }, StringSplitOptions.None);
                                if (tttt != null && tttt.Length >= 2)
                                {
                                    dtData.Rows[(int.Parse(tttt[1]) - 1)][dtData.Columns.Count - 1] = mObj.ModuleValue;
                                }
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
                mlpMoneys.setTableDataSource(dtData);
                #endregion
            }
        }
    }
}