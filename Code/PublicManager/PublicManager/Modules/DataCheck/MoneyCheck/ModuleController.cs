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
using PublicManager.Modules.Moneys.ProjectMoney;

namespace PublicManager.Modules.DataCheck.MoneyCheck
{
    public partial class ModuleController : BaseModuleController
    {
        private DEGridViewCellMergeAdapter cmaForSubject;
        private DEGridViewCellMergeAdapter cmaForUnit;
        public ModuleController()
        {
            InitializeComponent();

            gvDetailForSubject.OptionsBehavior.Editable = false;
            gvDetailForSubject.OptionsView.AllowCellMerge = true;
            cmaForSubject = new DEGridViewCellMergeAdapter(gvDetailForSubject, new string[] { "row1" });

            gvDetailForUnit.OptionsBehavior.Editable = false;
            gvDetailForUnit.OptionsView.AllowCellMerge = true;
            cmaForUnit = new DEGridViewCellMergeAdapter(gvDetailForUnit, new string[] { "row1" });
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
            List<List<object>> objectListForSubject = new List<List<object>>();
            List<List<object>> objectListForUnit = new List<List<object>>();

            //清理经费显示区域
            tpTag1.Controls.Clear();

            if (e.Node.Tag is Catalog)
            {
                //项目金额
                Catalog catalogObj = (Catalog)e.Node.Tag;

                #region 显示经费表
                List<Dicts> projectDicts = ConnectionManager.Context.table("Dicts").where("CatalogID='" + catalogObj.CatalogID + "' and ProjectID='" + catalogObj.CatalogID + "' and (SubjectID is null or SubjectID= '')").select("*").getList<Dicts>(new Dicts());
                addMoneyTablePage(catalogObj.CatalogID, catalogObj.CatalogName, projectDicts);
                #endregion

                List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalogObj.CatalogID + "'").select("*").getList<Subject>(new Subject());

                #region 组织课题经费数据
                foreach (Subject sObj in subjectList)
                {
                    List<SubjectMoneys> lxSubjects = ConnectionManager.Context.table("SubjectMoneys").where("CatalogID='" + catalogObj.CatalogID + "' and SubjectID='" + sObj.SubjectID + "'").orderBy("CatalogID,SubjectID,SMName").select("*").getList<SubjectMoneys>(new SubjectMoneys());

                    int totalValue = 0;
                    List<object> cells = new List<object>();
                    cells.Add(sObj.SubjectName);
                    foreach (SubjectMoneys sms in lxSubjects)
                    {
                        try
                        {
                            totalValue += int.Parse(sms.SMValue);
                        }
                        catch (Exception ex) { }

                        cells.Add(sms.SMValue);
                    }
                    for (int kk = 0; kk < 5 - lxSubjects.Count; kk++)
                    {
                        cells.Add("0");
                    }
                    cells.Add(totalValue.ToString());
                    objectListForSubject.Add(cells);
                }
                #endregion
                
                #region 组织单位经费数据
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
                    objectListForUnit.Add(cells);
                }
                #endregion
            }
            else if (e.Node.Tag is Subject)
            {
                //课题金额
                Subject subectObj = (Subject)e.Node.Tag;

                #region 显示经费表
                List<Dicts> subjectMoneyList = ConnectionManager.Context.table("Dicts").where("CatalogID='" + subectObj.CatalogID + "' and ProjectID='" + subectObj.ProjectID + "' and SubjectID='" + subectObj.SubjectID + "'").select("*").getList<Dicts>(new Dicts());
                addMoneyTablePage(subectObj.CatalogID + "_" + subectObj.SubjectID, subectObj.SubjectName, subjectMoneyList);
                #endregion

                #region 组织课题经费数据
                List<SubjectMoneys> lxSubjects = ConnectionManager.Context.table("SubjectMoneys").where("CatalogID='" + subectObj.CatalogID + "' and SubjectID='" + subectObj.SubjectID + "'").orderBy("CatalogID,SubjectID,SMName").select("*").getList<SubjectMoneys>(new SubjectMoneys());
                int totalValue = 0;
                List<object> cells = new List<object>();
                cells.Add(subectObj.SubjectName);
                foreach (SubjectMoneys sms in lxSubjects)
                {
                    try
                    {
                        totalValue += int.Parse(sms.SMValue);
                    }
                    catch (Exception ex) { }

                    cells.Add(sms.SMValue);
                }
                for (int kk = 0; kk < 5 - lxSubjects.Count; kk++)
                {
                    cells.Add("0");
                }
                cells.Add(totalValue.ToString());
                objectListForSubject.Add(cells);
                #endregion

                #region 组织单位经费数据

                #endregion
            }

            #region 显示课题经费数据
            DataTable dtTemp = BaseModuleController.getTempDataTable("row", 7);
            foreach (List<object> lxItem in objectListForSubject)
            {
                dtTemp.Rows.Add(lxItem.ToArray());
            }
            gcGridForSubject.DataSource = dtTemp;
            #endregion

            #region 显示单位经费数据
            DataTable dtTemp22 = BaseModuleController.getTempDataTable("row", 7);
            foreach (List<object> lxItem in objectListForUnit)
            {
                dtTemp22.Rows.Add(lxItem.ToArray());
            }
            gcGridForUnit.DataSource = dtTemp22;
            #endregion
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
            foreach (MoneyLabel tb in mtc.BoxDict.Values)
            {
                tb.ReadOnly = true;
                tb.Margin = new Padding(2);
            }
            mtc.Dock = DockStyle.Fill;
            tpTag1.Controls.Add(mtc);
            mtc.loadMoneys(moneyList);
        }
    }
}