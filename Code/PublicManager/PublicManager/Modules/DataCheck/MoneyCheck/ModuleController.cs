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
        Dictionary<string, string> nodeColDict = new Dictionary<string, string>();

        private DEGridViewCellMergeAdapter cmaForSubject;
        private DEGridViewCellMergeAdapter cmaForUnit;
        public ModuleController()
        {
            InitializeComponent();

            makeTableColumns();

            gvDetailForSubject.OptionsBehavior.Editable = false;
            gvDetailForSubject.OptionsView.AllowCellMerge = true;
            cmaForSubject = new DEGridViewCellMergeAdapter(gvDetailForSubject, new string[] { "row1" });

            gvDetailForUnit.OptionsBehavior.Editable = false;
            gvDetailForUnit.OptionsView.AllowCellMerge = true;
            cmaForUnit = new DEGridViewCellMergeAdapter(gvDetailForUnit, new string[] { "row1" });
        }

        private void makeTableColumns()
        {
            gvDetailForSubject.Columns.Clear();
            gvDetailForUnit.Columns.Clear();

            gvDetailForSubject.Columns.Add(getNewColumn("row1", "名称", 1));
            gvDetailForSubject.Columns.Add(getNewColumn("row2", "合计", 2));

            gvDetailForUnit.Columns.Add(getNewColumn("row1", "名称", 1));
            gvDetailForUnit.Columns.Add(getNewColumn("row2", "合计", 2));
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
            DataTable dtSubject = null;
            DataTable dtUnit = null;

            //清理经费显示区域
            tpTag1.Controls.Clear();

            if (e.Node.Tag is Catalog)
            {
                //项目金额
                Catalog catalogObj = (Catalog)e.Node.Tag;
                tpTag1.PageVisible = true;
                xtcData.SelectedTabPage = tpTag1;

                #region 显示经费表
                List<Dicts> projectDicts = ConnectionManager.Context.table("Dicts").where("CatalogID='" + catalogObj.CatalogID + "' and ProjectID='" + catalogObj.CatalogID + "' and (SubjectID is null or SubjectID= '')").select("*").getList<Dicts>(new Dicts());
                addMoneyTablePage(catalogObj.CatalogID, catalogObj.CatalogName, projectDicts);
                #endregion

                List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalogObj.CatalogID + "'").select("*").getList<Subject>(new Subject());

                //生成列
                makeTableColumnsForCatalogID(catalogObj.CatalogID);
                dtSubject = BaseModuleController.getTempDataTable("row", gvDetailForSubject.Columns.Count);
                dtUnit = BaseModuleController.getTempDataTable("row", gvDetailForSubject.Columns.Count);

                #region 组织课题经费数据
                foreach (Subject sObj in subjectList)
                {
                    List<SubjectMoneys> lxSubjects = ConnectionManager.Context.table("SubjectMoneys").where("CatalogID='" + catalogObj.CatalogID + "' and SubjectID='" + sObj.SubjectID + "'").orderBy("CatalogID,SubjectID,SMName").select("*").getList<SubjectMoneys>(new SubjectMoneys());

                    int totalValue = 0;
                    DataRow drr = dtSubject.NewRow();
                    drr[nodeColDict["****名称"]] = sObj.SubjectName;

                    foreach (SubjectMoneys sms in lxSubjects)
                    {
                        MoneySends mss = ConnectionManager.Context.table("MoneySends").where("MSID='" + sms.NodeID + "'").select("*").getItem<MoneySends>(new MoneySends());
                        if (string.IsNullOrEmpty(mss.MSID))
                        {
                            continue;
                        }

                        try
                        {
                            totalValue += int.Parse(sms.SMValue);
                        }
                        catch (Exception ex) { }

                        if (nodeColDict.ContainsKey(mss.SendRule))
                        {
                            drr[nodeColDict[mss.SendRule]] = sms.SMValue;
                        }
                    }

                    drr[nodeColDict["****合计"]] = totalValue.ToString();
                    dtSubject.Rows.Add(drr);
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
                    DataRow drr = dtUnit.NewRow();
                    drr[nodeColDict["****名称"]] = unitName;

                    foreach (UnitMoneys ums in lxUnits)
                    {
                        MoneySends mss = ConnectionManager.Context.table("MoneySends").where("MSID='" + ums.NodeID + "'").select("*").getItem<MoneySends>(new MoneySends());
                        if (string.IsNullOrEmpty(mss.MSID))
                        {
                            continue;
                        }

                        try
                        {
                            totalValue += int.Parse(ums.UMValue);
                        }
                        catch (Exception ex) { }

                        if (nodeColDict.ContainsKey(mss.SendRule))
                        {
                            drr[nodeColDict[mss.SendRule]] = ums.UMValue;
                        }
                    }

                    drr[nodeColDict["****合计"]] = totalValue.ToString();
                    dtUnit.Rows.Add(drr);
                }
                #endregion
            }
            else if (e.Node.Tag is Subject)
            {
                //课题金额
                Subject subectObj = (Subject)e.Node.Tag;
                tpTag1.PageVisible = false;

                //生成列
                makeTableColumnsForCatalogID(subectObj.CatalogID);
                dtSubject = BaseModuleController.getTempDataTable("row", gvDetailForSubject.Columns.Count);
                dtUnit = BaseModuleController.getTempDataTable("row", gvDetailForSubject.Columns.Count);

                #region 组织课题经费数据
                List<SubjectMoneys> lxSubjects = ConnectionManager.Context.table("SubjectMoneys").where("CatalogID='" + subectObj.CatalogID + "' and SubjectID='" + subectObj.SubjectID + "'").orderBy("CatalogID,SubjectID,SMName").select("*").getList<SubjectMoneys>(new SubjectMoneys());
                int totalValue = 0;
                DataRow drr = dtSubject.NewRow();
                drr[nodeColDict["****名称"]] = subectObj.SubjectName;

                foreach (SubjectMoneys sms in lxSubjects)
                {
                    MoneySends mss = ConnectionManager.Context.table("MoneySends").where("MSID='" + sms.NodeID + "'").select("*").getItem<MoneySends>(new MoneySends());
                    if (string.IsNullOrEmpty(mss.MSID))
                    {
                        continue;
                    }

                    try
                    {
                        totalValue += int.Parse(sms.SMValue);
                    }
                    catch (Exception ex) { }

                    if (nodeColDict.ContainsKey(mss.SendRule))
                    {
                        drr[nodeColDict[mss.SendRule]] = sms.SMValue;
                    }
                }

                drr[nodeColDict["****合计"]] = totalValue.ToString();
                dtSubject.Rows.Add(drr);
                #endregion

                #region 组织单位经费数据

                #endregion
            }

            gcGridForSubject.DataSource = dtSubject;
            gcGridForUnit.DataSource = dtUnit;
        }

        private void makeTableColumnsForCatalogID(string catalogID)
        {
            gvDetailForSubject.Columns.Clear();
            gvDetailForUnit.Columns.Clear();

            int colIndex = 0;

            colIndex++;
            gvDetailForSubject.Columns.Add(getNewColumn("row" + colIndex, "名称", colIndex));
            gvDetailForUnit.Columns.Add(getNewColumn("row" + colIndex, "名称", colIndex));
            nodeColDict["****名称"] = "row" + colIndex;

            List<MoneySends> list = ConnectionManager.Context.table("MoneySends").where("CatalogID='" + catalogID + "'").select("*").getList<MoneySends>(new MoneySends());
            foreach (MoneySends ms in list)
            {
                colIndex++;

                gvDetailForSubject.Columns.Add(getNewColumn("row" + colIndex, ms.SendRule, colIndex));
                gvDetailForUnit.Columns.Add(getNewColumn("row" + colIndex, ms.SendRule, colIndex));

                nodeColDict[ms.SendRule] = "row" + colIndex;
            }

            colIndex++;
            gvDetailForSubject.Columns.Add(getNewColumn("row" + colIndex, "合计", colIndex));
            gvDetailForUnit.Columns.Add(getNewColumn("row" + colIndex, "合计", colIndex));
            nodeColDict["****合计"] = "row" + colIndex;
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

        /// <summary>
        /// 生成新的列对象
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="displayName"></param>
        /// <param name="displayIndex"></param>
        /// <returns></returns>
        public DevExpress.XtraGrid.Columns.GridColumn getNewColumn(string fieldName, string displayName, int displayIndex)
        {
            DevExpress.XtraGrid.Columns.GridColumn colTemp = new DevExpress.XtraGrid.Columns.GridColumn();
            colTemp.Caption = displayName;
            colTemp.FieldName = fieldName;
            colTemp.Name = fieldName;
            colTemp.Visible = true;
            colTemp.VisibleIndex = displayIndex;
            return colTemp;
        }
    }
}