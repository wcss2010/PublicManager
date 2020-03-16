using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.CustomReporter
{
    public partial class ModuleController : BaseModuleController
    {
        public ModuleController()
        {
            InitializeComponent();
        }

        public override DevExpress.XtraBars.Ribbon.RibbonPage[] getTopBarPages()
        {
            return new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpMaster };
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
    }
}