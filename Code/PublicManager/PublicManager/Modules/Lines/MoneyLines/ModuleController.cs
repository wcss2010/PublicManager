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
            clearMoneyTable();

            List<List<object>> objectList = new List<List<object>>();
            if (e.Node.Tag is Catalog)
            {
                Catalog catalogObj = (Catalog)e.Node.Tag;

                //显示总的经费
            }
            else if (e.Node.Tag is MoneySends)
            {
                MoneySends moneySendObj = (MoneySends)e.Node.Tag;

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
                                    mlDetail.setCellValue(2, 4+ (int.Parse(tttt[1]) - 1), mObj.ModuleValue);
                                }
                            }
                            else if (mObj.ModuleName.StartsWith("本阶段支出经费"))
                            {
                                string[] tttt = mObj.ModuleName.Split(new string[] { "xxxxx" }, StringSplitOptions.None);
                                if (tttt != null && tttt.Length >= 2)
                                {
                                    mlDetail.setCellValue(3, 4 + (int.Parse(tttt[1]) - 1), mObj.ModuleValue);
                                }
                            }
                            else if (mObj.ModuleName.StartsWith("备注"))
                            {
                                string[] tttt = mObj.ModuleName.Split(new string[] { "xxxxx" }, StringSplitOptions.None);
                                if (tttt != null && tttt.Length >= 2)
                                {
                                    mlDetail.setCellValue(9, 4 + (int.Parse(tttt[1]) - 1), mObj.ModuleValue);
                                }
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
            }
        }

        private void clearMoneyTable()
        {
            #region 设置标题栏
            //合同价款
            mlDetail.setCellValue(1, 1, "0");

            //累计预算经费
            mlDetail.setCellValue(3, 1, "0");

            //累计到位经费
            mlDetail.setCellValue(5, 1, "0");

            //累计支出经费
            mlDetail.setCellValue(7, 1, "0");

            //空,暂时没用到
            mlDetail.setCellValue(8, 1, string.Empty);
            //空,暂时没用到
            mlDetail.setCellValue(9, 1, string.Empty);
            #endregion

            #region 清理经费表
            int defaultX = 2;
            int defaultY = 4;
            for (int sy = 0; sy < 15; sy++)
            {
                for (int sx = 0; sx < 8; sx++)
                {
                    int nowX = defaultX + sx;
                    int nowY = defaultY + sy;

                    if (sx == 7)
                    {
                        mlDetail.setCellValue(nowX, nowY, string.Empty);
                    }
                    else
                    {
                        mlDetail.setCellValue(nowX, nowY, string.Empty);
                    }
                }
            }
            #endregion
        }
    }
}