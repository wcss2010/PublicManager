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

namespace PublicManager.Modules.Moneys.UnitMoney
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

            this.tvProjectList.ContentTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProjectList_AfterSelect);

            loadData();
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
            }
        }

        private void tvProjectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dgvDetail.Rows.Clear();
            List<List<object>> objectList = new List<List<object>>();

            if (e.Node.Tag is Catalog)
            {
                //项目年度列表
                Catalog catalogObj = (Catalog)e.Node.Tag;

                List<string> unitList = new List<string>();
                List<UnitMoneys> unitMoneysList = ConnectionManager.Context.table("UnitMoneys").where("CatalogID='" + catalogObj.CatalogID + "'").select("*").getList<UnitMoneys>(new UnitMoneys());
                foreach (UnitMoneys ums in unitMoneysList)
                {
                    if (unitList.Contains(ums.UnitName))
                    {
                        continue;
                    }
                    else
                    {
                        unitList.Add(ums.UnitName);
                    }
                }

                foreach (string unitName in unitList)
                {
                    List<UnitMoneys> lxUnits = ConnectionManager.Context.table("UnitMoneys").where("CatalogID='" + catalogObj.CatalogID + "' and UnitName='" + unitName + "'").orderBy("CatalogID,UnitName,UMName").select("*").getList<UnitMoneys>(new UnitMoneys());

                    int totalValue = 0;
                    List<object> cells = new List<object>();
                    cells.Add(unitName);
                    foreach (UnitMoneys ums in lxUnits)
                    {
                        try
                        {
                            totalValue += int.Parse(ums.UMValue);
                        }
                        catch (Exception ex) { }

                        cells.Add(ums.UMValue);
                    }
                    for (int kk = 0; kk < 5 - lxUnits.Count; kk++)
                    {
                        cells.Add("0");
                    }
                    cells.Add(totalValue.ToString());
                    objectList.Add(cells);
                }
            }

            foreach (List<object> lxItem in objectList)
            {
                dgvDetail.Rows.Add(lxItem.ToArray());
            }
            dgvDetail.checkCellSize();
        }
    }
}