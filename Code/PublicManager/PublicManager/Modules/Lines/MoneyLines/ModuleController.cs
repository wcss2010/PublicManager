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
                    //nodeSub.Text = "节点" + indexxxx + "(" + mss.SendRule + ")";
                    nodeSub.Text = mss.SendRule;
                    nodeSub.Tag = mss;
                    parentNode.Nodes.Add(nodeSub);
                }
            }
        }

        private void tvProjectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Catalog)
            {
                Catalog catalogObj = (Catalog)e.Node.Tag;

                DataTable dtCatalog = mlpMoneys.getTempMoneyTable("row", e.Node.Nodes.Count);
                mlpMoneys.showOrHideTopPanel(true);
                mlpMoneys.setNodeName("");
                mlpMoneys.showOrHideColumn(dtCatalog.Columns.Count - 1, false);
                mlpMoneys.showOrHideColumn(dtCatalog.Columns.Count - 2, true);
                for (int yyy = 0; yyy < e.Node.Nodes.Count; yyy++)
                {
                    mlpMoneys.showOrHideColumn(2 + yyy, true);
                }

                Application.DoEvents();

                #region 显示总表
                int nodeIndex = 0;
                foreach (TreeNode sub in e.Node.Nodes)
                {
                    MoneySends mss = (MoneySends)sub.Tag;

                    List<Contact_Table4> moneyss = ConnectionManager.Context.table("Contact_Table4").where("NodeID='" + mss.MSID + "'").select("*").getList<Contact_Table4>(new Contact_Table4());
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
                                        decimal val = 0;
                                        try
                                        {
                                            val = decimal.Parse(mObj.ModuleValue);
                                        }
                                        catch (Exception ex) { }

                                        decimal total = 0;
                                        try
                                        {
                                            total = decimal.Parse(dtCatalog.Rows[(int.Parse(tttt[1]) - 1)][1].ToString());
                                        }
                                        catch (Exception ex) { }

                                        dtCatalog.Rows[(int.Parse(tttt[1]) - 1)][1] = total + val;
                                    }
                                }
                                else if (mObj.ModuleName.StartsWith("本阶段支出经费"))
                                {
                                    string[] tttt = mObj.ModuleName.Split(new string[] { "xxxxx" }, StringSplitOptions.None);
                                    if (tttt != null && tttt.Length >= 2)
                                    {
                                        decimal val = 0;
                                        try
                                        {
                                            val = decimal.Parse(mObj.ModuleValue);
                                        }
                                        catch (Exception ex) { }

                                        decimal total = 0;
                                        try
                                        {
                                            total = decimal.Parse(dtCatalog.Rows[(int.Parse(tttt[1]) - 1)][dtCatalog.Columns.Count - 2].ToString());
                                        }
                                        catch (Exception ex) { }

                                        mlpMoneys.showOrHideColumn(2 + nodeIndex, true);
                                        dtCatalog.Rows[(int.Parse(tttt[1]) - 1)][2 + nodeIndex] = val;

                                        total += val;
                                        dtCatalog.Rows[(int.Parse(tttt[1]) - 1)][dtCatalog.Columns.Count - 2] = total;
                                    }
                                }
                                //else if (mObj.ModuleName.StartsWith("备注"))
                                //{
                                //    string[] tttt = mObj.ModuleName.Split(new string[] { "xxxxx" }, StringSplitOptions.None);
                                //    if (tttt != null && tttt.Length >= 2)
                                //    {
                                //        dtData.Rows[(int.Parse(tttt[1]) - 1)][dtData.Columns.Count - 1] = mObj.ModuleValue;
                                //    }
                                //}
                            }
                        }
                        catch (Exception ex) { }
                    }

                    nodeIndex++;
                }
                mlpMoneys.setTableDataSource(dtCatalog);
                #endregion

                #region 显示标题栏的值
                //合同金额
                Project proj = ConnectionManager.Context.table("Project").where("ProjectID='" + catalogObj.CatalogID + "'").select("*").getItem<Project>(new Project());
                mlpMoneys.setTag1Value(proj.TotalMoney != null ? proj.TotalMoney.ToString() : string.Empty);

                //累计预算= 项目节点管理中的经费金额
                decimal totalVal = 0;
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    totalVal += ((MoneySends)tn.Tag).TotalMoney;
                }
                mlpMoneys.setTag2Value(totalVal + "");

                //累计到位= 项目基本情况——项目到位经费
                totalVal = 0;
                foreach (TreeNode tn in e.Node.Nodes)
                {
                   List<Contact_Table1> table1sss = ConnectionManager.Context.table("Contact_Table1").where("NodeID='" + ((MoneySends)tn.Tag).MSID + "'").select("*").getList<Contact_Table1>(new Contact_Table1());
                   foreach (Contact_Table1 table1 in table1sss)
                   {
                       if (string.IsNullOrEmpty(table1.TID))
                       {
                           continue;
                       }

                       totalVal += table1.TotalMoneyNow;
                   }
                }
                mlpMoneys.setTag3Value(totalVal + "");

                //累计支出= 项目经费使用情况——本阶段支出经费——合计
                totalVal = 0;
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    Contact_Table4 table1 = ConnectionManager.Context.table("Contact_Table4").where("NodeID='" + ((MoneySends)tn.Tag).MSID + "' and ModuleName = '本阶段支出经费xxxxx16'").select("*").getItem<Contact_Table4>(new Contact_Table4());
                    if (string.IsNullOrEmpty(table1.TID))
                    {
                        continue;
                    }

                    decimal vall = 0;
                    try
                    {
                        vall = decimal.Parse(table1.ModuleValue);
                    }
                    catch (Exception ex) { }

                    totalVal += vall;
                }
                mlpMoneys.setTag4Value(totalVal + "");
                #endregion
            }
            else if (e.Node.Tag is MoneySends)
            {
                MoneySends moneySendObj = (MoneySends)e.Node.Tag;
                DataTable dtData = mlpMoneys.getTempMoneyTable("row", e.Node.Parent.Nodes.Count);
                mlpMoneys.showOrHideTopPanel(false);
                mlpMoneys.setNodeName(e.Node.Text);
                int nodeIndex = e.Node.Parent.Nodes.IndexOf(e.Node);
                mlpMoneys.showOrHideColumn(dtData.Columns.Count - 1, true);
                mlpMoneys.showOrHideColumn(dtData.Columns.Count - 2, false);
                for (int ttt = 0; ttt < e.Node.Parent.Nodes.Count; ttt++)
                {
                    mlpMoneys.showOrHideColumn(2 + ttt, false);
                }

                #region 显示金额表
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