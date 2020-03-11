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
            //dgvDetail.Rows.Clear();
            //List<List<object>> objectList = new List<List<object>>();

            //if (e.Node.Tag is Catalog)
            //{
            //    //项目年度列表
            //    Catalog catalogObj = (Catalog)e.Node.Tag;

            //    List<MoneySends> subList = ConnectionManager.Context.table("MoneySends").where("(CatalogID = '" + catalogObj.CatalogID + "' and ProjectID = '" + catalogObj.CatalogID + "')").select("*").getList<MoneySends>(new MoneySends());
            //    int indexx = 0;
            //    foreach (MoneySends mss in subList)
            //    {
            //        indexx++;
            //        List<object> cells = new List<object>();
            //        cells.Add(indexx.ToString());
            //        cells.Add(mss.SendRule);
            //        cells.Add(mss.WillTime.ToString("yyyy年MM月dd日"));
            //        cells.Add(mss.TotalMoney);
            //        cells.Add(mss.MemoText);

            //        objectList.Add(cells);
            //    }
            //}

            //foreach (List<object> lxItem in objectList)
            //{
            //    dgvDetail.Rows.Add(lxItem.ToArray());
            //}
        }
    }
}