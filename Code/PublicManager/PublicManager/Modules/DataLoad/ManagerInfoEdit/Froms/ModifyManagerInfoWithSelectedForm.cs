using DevExpress.XtraBars.Ribbon;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.DataLoad.ManagerInfoEdit.Froms
{
    public partial class ModifyManagerInfoWithSelectedForm : RibbonForm
    {
        private SearchRulePanel srpSearch;
        public ModifyManagerInfoWithSelectedForm(SearchRulePanel srpPanel,string labelText)
        {
            InitializeComponent();

            this.Text = "批量修改" + labelText.Replace(":", string.Empty);
            this.lblTitle.Text = labelText;
            this.srpSearch = srpPanel;
            loadDate();
        }

        private void loadDate()
        {
            #region 加载项目树
            tlTestA.Nodes.Clear();
            List<Catalog> catalogList = ConnectionManager.Context.table("Catalog").where("(1=1)" + srpSearch.CatalogIDFilterString).select("*").getList<Catalog>(new Catalog());
            foreach (Catalog catalog in catalogList)
            {
                Project proj = ConnectionManager.Context.table("Project").where("CatalogID='" + catalog.CatalogID + "'").select("*").getItem<Project>(new Project());

                TreeNode parentNode = new TreeNode();
                parentNode.Text = proj.ProjectName;
                parentNode.Tag = proj;
                tlTestA.Nodes.Add(parentNode);
            }
            #endregion
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in tlTestA.Nodes)
            {
                if (tn.Checked)
                {
                    Project proj = (Project)tn.Tag;
                    switch (lblTitle.Text.Trim())
                    {
                        case "项目领域/技术方向:":
                            proj.ProjectRange = txtContent.Text;
                            break;
                        case "计划批次:":
                            proj.TaskNumber = txtContent.Text;
                            break;
                    }
                    proj.copyTo(ConnectionManager.Context.table("Project")).where("ProjectID='" + proj.ProjectID + "'").update();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}