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
                TreeNode tn = new TreeNode();
                tn.Text = catalog.CatalogName + "(" + catalog.CatalogVersion + ")";
                tn.Tag = catalog;
                tvProjectList.Nodes.Add(tn);
            }
        }

        private void tvProjectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Catalog catalogObj = (Catalog)e.Node.Tag;

            tcMoneyTables.TabPages.Clear();

            //项目金额
            List<Dicts> projectDicts = ConnectionManager.Context.table("Dicts").where("CatalogID='" + catalogObj.CatalogID + "' and ProjectID='" + catalogObj.CatalogID + "' and (SubjectID is null or SubjectID= '')").select("*").getList<Dicts>(new Dicts());
            addMoneyTablePage(catalogObj.CatalogID, catalogObj.CatalogName, projectDicts);

            //课题金额
            List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalogObj.CatalogID + "' and ProjectID='" + catalogObj.CatalogID + "'").select("*").getList<Subject>(new Subject());
            foreach (Subject sub in subjectList)
            {
                List<Dicts> subjectMoneyList = ConnectionManager.Context.table("Dicts").where("CatalogID='" + catalogObj.CatalogID + "' and ProjectID='" + catalogObj.CatalogID + "' and SubjectID='"+ sub.SubjectID +"'").select("*").getList<Dicts>(new Dicts());
                addMoneyTablePage(catalogObj.CatalogID + "_" + sub.SubjectID, sub.SubjectName, subjectMoneyList);
            }
        }

        /// <summary>
        /// 添加一个金额页
        /// </summary>
        /// <param name="catalogID"></param>
        /// <param name="projectName"></param>
        /// <param name="moneyList"></param>
        public void addMoneyTablePage(string catalogID,string projectName, List<Dicts> moneyList)
        {
            TabPage tp = new TabPage();
            tp.Name = catalogID;
            tp.Text = projectName;

            MoneyTableControl mtc = new MoneyTableControl();
            foreach (TextBox tb in mtc.BoxDict.Values)
            {
                tb.ReadOnly = true;
            }

            mtc.loadMoneys(moneyList);

            tp.Controls.Add(mtc);

            tcMoneyTables.TabPages.Add(tp);
        }
    }
}