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

namespace PublicManager.Modules.Lines.MoneyRequest
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

            loadData();
        }

        private void loadData()
        {
            tvProjectList.Nodes.Clear();
            List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").select("*").getList<Catalog>(new Catalog());
            foreach (Catalog catalog in catalogList)
            {
                TreeNode parentNode = new TreeNode();
                parentNode.Text = catalog.CatalogName + "(" + catalog.CatalogVersion + ")";
                parentNode.Tag = catalog;
                tvProjectList.Nodes.Add(parentNode);

                //课题金额
                List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalog.CatalogID + "' and ProjectID='" + catalog.CatalogID + "'").select("*").getList<Subject>(new Subject());
                foreach (Subject sub in subjectList)
                {
                    TreeNode subjectNode = new TreeNode();
                    subjectNode.Text = sub.SubjectName;
                    subjectNode.Tag = sub;
                    parentNode.Nodes.Add(subjectNode);
                }
            }
        }

        private void tvProjectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            plContent.Controls.Clear();

            if (e.Node.Tag is Catalog)
            {
                //项目金额
                Catalog catalogObj = (Catalog)e.Node.Tag;
                List<Dicts> projectDicts = ConnectionManager.Context.table("Dicts").where("CatalogID='" + catalogObj.CatalogID + "' and ProjectID='" + catalogObj.CatalogID + "' and (SubjectID is null or SubjectID= '')").select("*").getList<Dicts>(new Dicts());
                addMoneyTablePage(catalogObj.CatalogID, catalogObj.CatalogName, projectDicts);
            }
            else if (e.Node.Tag is Subject)
            {
                //课题金额
                Subject subectObj = (Subject)e.Node.Tag;
                List<Dicts> subjectMoneyList = ConnectionManager.Context.table("Dicts").where("CatalogID='" + subectObj.CatalogID + "' and ProjectID='" + subectObj.ProjectID + "' and SubjectID='" + subectObj.SubjectID + "'").select("*").getList<Dicts>(new Dicts());
                addMoneyTablePage(subectObj.CatalogID + "_" + subectObj.SubjectID, subectObj.SubjectName, subjectMoneyList);
            }
        }

        /// <summary>
        /// 添加一个金额页
        /// </summary>
        /// <param name="catalogID"></param>
        /// <param name="projectName"></param>
        /// <param name="moneyList"></param>
        public void addMoneyTablePage(string catalogID, string projectName, List<Dicts> moneyList)
        {
            MoneyTableControl mtc = new MoneyTableControl();
            foreach (TextBox tb in mtc.BoxDict.Values)
            {
                tb.ReadOnly = true;
            }
            plContent.Controls.Add(mtc);
            mtc.loadMoneys(moneyList);
        }
    }
}