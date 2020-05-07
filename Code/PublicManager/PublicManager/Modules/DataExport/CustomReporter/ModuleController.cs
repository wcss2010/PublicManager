using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PublicManager.DB.Entitys;
using PublicManager.DB;
using Noear.Weed;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace PublicManager.Modules.DataExport.CustomReporter
{
    public partial class ModuleController : BaseModuleController
    {
        Dictionary<string, CheckBox> projectColumnDict = new Dictionary<string, CheckBox>();
        Dictionary<string, CheckBox> subjectColumnDict = new Dictionary<string, CheckBox>();

        private DEGridViewCellMergeAdapter cma1;
        private DEGridViewCellMergeAdapter cma2;
        private CheckBox subjectIOCheckBox;
        private DataSet dsAll;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            dgvDetail.OptionsView.AllowCellMerge = true;
            dgvDetail.OptionsDetail.AllowExpandEmptyDetails = true;
            dgvDetail.OptionsDetail.ShowDetailTabs = false;
            cma1 = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3", "row4", "row5", "row6" });

            dgvSub.OptionsBehavior.Editable = false;
            dgvSub.OptionsView.AllowCellMerge = true;
            dgvSub.OptionsView.ShowGroupPanel = false;
            cma2 = new DEGridViewCellMergeAdapter(dgvSub, new string[] { "row1" });

            srpSearch.switchCatalogType(false, false);

            makeColumnList();
        }

        private void makeColumnList()
        {
            //主表
            foreach (GridColumn gcc in dgvDetail.Columns)
            {
                if (gcc.Visible || gcc.OptionsColumn.ShowInCustomizationForm)
                {
                    CheckBox cbb = new CheckBox();
                    cbb.Name = gcc.FieldName + "++" + gcc.Caption;
                    cbb.Text = gcc.Caption;
                    cbb.Checked = true;
                    cbb.AutoSize = true;
                    cbb.Tag = gcc;

                    projectColumnDict[cbb.Name] = cbb;
                    fplProject.Controls.Add(cbb);

                    if (gcc.Caption == "牵头单位地址")
                    {
                        cbb = new CheckBox();
                        cbb.Name = "*****" + "++" + "课题列表";
                        cbb.Text = "课题列表";
                        cbb.Checked = true;
                        cbb.AutoSize = true;
                        cbb.Tag = null;

                        projectColumnDict[cbb.Name] = cbb;
                        fplProject.Controls.Add(cbb);

                        subjectIOCheckBox = cbb;

                        cbb.CheckedChanged += cbb_CheckedChanged;
                    }
                }
            }

            //从表
            foreach (GridColumn gcc in dgvSub.Columns)
            {
                if (gcc.Visible)
                {
                    CheckBox cbbxx = new CheckBox();
                    cbbxx.Name = gcc.FieldName + "++" + gcc.Caption;
                    cbbxx.Text = gcc.Caption;
                    cbbxx.Checked = true;
                    cbbxx.AutoSize = true;
                    cbbxx.Tag = gcc;

                    subjectColumnDict[cbbxx.Name] = cbbxx;
                    fplSubject.Controls.Add(cbbxx);

                    cbbxx.CheckedChanged += cbbxx_CheckedChanged;
                }
            }
        }

        void cbbxx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkObj = ((CheckBox)sender);

            int checkedCount = 0;
            foreach (Control c in checkObj.Parent.Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked)
                    {
                        checkedCount++;
                    }
                }
            }

            if (checkedCount <= 0)
            {
                subjectIOCheckBox.Checked = false;
            }
        }

        void cbb_CheckedChanged(object sender, EventArgs e)
        {
            fplSubject.Visible = ((CheckBox)sender).Checked;
            plDetailHeader.Visible = ((CheckBox)sender).Checked;

            foreach (Control c in fplSubject.Controls)
            {
                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = true;
                }
            }
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
                
        private void dgvDetail_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                object objProjectID = view.GetRowCellValue(e.RowHandle, "row15");
                if (objProjectID != null)
                {
                    string projectID = objProjectID.ToString();

                    GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                    if (detailView != null)
                    {
                        view.ExpandGroupRow(-1);
                    }
                }
            }
        }

        private void plOutputHeaderList_SizeChanged(object sender, EventArgs e)
        {
            plMasterHeader.Width = plOutputHeaderList.Width - 20;
            plDetailHeader.Width = plOutputHeaderList.Width - 20;
        }

        private void srpSearch_OnSearchClick(object sender, EventArgs args)
        {
            dsAll = new DataSet();
            DataTable masterDt = getTempDataTable("row", 33);
            DataTable detailDt = getTempDataTable("row", 9);

            List<Project> projList = MakeSQLWithSearchRule.getProjectList(srpSearch);
            foreach (Project proj in projList)
            {
                #region 主表数据
                List<object> cells = new List<object>();
                cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                cells.Add(proj.Domains);
                cells.Add(proj.TaskNumber);
                cells.Add(proj.ProjectNumber);
                cells.Add(proj.ProjectName);
                cells.Add(proj.TotalMoney);
                cells.Add(proj.TotalTime);
                cells.Add(proj.SecretLevel);
                //显示仅为项目负责人
                Person masterPerson = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '' and IsProjectMaster = 'true'").select("*").getItem<Person>(new Person());
                if (masterPerson != null && masterPerson.PersonID != null && masterPerson.PersonID.Length >= 1)
                {
                    cells.Add(masterPerson.PersonName);
                }
                else
                {
                    cells.Add(string.Empty);
                }
                cells.Add(proj.DutyUnit);
                cells.Add(proj.DutyUnitOrg);
                cells.Add(proj.DutyUnitAddress);
                cells.Add(string.Empty);
                cells.Add(proj.ProjectID);
                cells.Add(proj.Keywords);

                if (masterPerson != null && masterPerson.PersonID != null && masterPerson.PersonID.Length >= 1)
                {
                    cells.Add(masterPerson.Telephone);
                    cells.Add(masterPerson.Mobilephone);
                    cells.Add(masterPerson.PersonJob);
                }
                else
                {
                    cells.Add(string.Empty);
                    cells.Add(string.Empty);
                    cells.Add(string.Empty);
                }

                cells.Add(proj.OKQuestionMemo);
                cells.Add(proj.OKCheckA);
                cells.Add(proj.OKCheckB);
                cells.Add(proj.ContactCheckLevelA);
                cells.Add(proj.ContactCheckLevelB);
                cells.Add(proj.Memo);

                //第一年度经费,第二年度经费,第三年度经费,第四年度经费,第五年度经费
                for (int kkk = 1; kkk <= 5; kkk++)
                {
                    cells.Add(ConnectionManager.Context.table("Dicts").where("CatalogID='" + proj.CatalogID + "' and DictName='Year" + kkk + "'").select("DictValue").getValue<string>(string.Empty));
                }

                //起止时间(拨付时间)
                List<DateTime> dtList = new List<DateTime>();
                DataList dlMoneySendList = ConnectionManager.Context.table("MoneySends").where("CatalogID='" + proj.CatalogID + "'").orderBy("WillTime").select("WillTime").getDataList();
                if (dlMoneySendList.getRowCount() >= 1)
                {
                    foreach (DataItem diiii in dlMoneySendList.getRows())
                    {
                        DateTime willTime = diiii.get("WillTime") != null ? DateTime.Parse(diiii.get("WillTime").ToString()) : DateTime.Now;
                        dtList.Add(willTime);
                    }
                }
                if (dtList.Count >= 2)
                {
                    cells.Add(dtList[0].ToString("yyyy年MM月dd日") + "~" + dtList[dtList.Count - 1].ToString("yyyy年MM月dd日"));
                }
                else if (dtList.Count == 1)
                {
                    cells.Add(dtList[0].ToString("yyyy年MM月dd日") + "~");
                }
                else
                {
                    cells.Add("");
                }

                cells.Add(proj.DutyNormalUnit);

                cells.Add(proj.ProjectRange);

                masterDt.Rows.Add(cells.ToArray());
                #endregion

                #region 生成从表数据
                if (proj != null && !string.IsNullOrEmpty(proj.ProjectID))
                {
                    List<Subject> subList = ConnectionManager.Context.table("Subject").where("CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                    foreach (Subject sub in subList)
                    {
                        cells = new List<object>();
                        cells.Add(sub.SubjectName);
                        Person personObj = ConnectionManager.Context.table("Person").where("CatalogID = '" + proj.CatalogID + "' and SubjectID = '" + sub.SubjectID + "' and JobInProject = '负责人'").select("*").getItem<Person>(new Person());
                        if (string.IsNullOrEmpty(personObj.PersonID))
                        {
                            cells.Add(string.Empty);
                        }
                        else
                        {
                            cells.Add(personObj.PersonName);
                        }
                        cells.Add(sub.DutyUnit);
                        cells.Add(sub.DutyUnitOrg);
                        cells.Add(sub.DutyUnitAddress);
                        cells.Add(proj.ProjectID);

                        if (string.IsNullOrEmpty(personObj.PersonID))
                        {
                            cells.Add(string.Empty);
                            cells.Add(string.Empty);
                        }
                        else
                        {
                            cells.Add(personObj.Telephone);
                            cells.Add(personObj.Mobilephone);
                        }

                        cells.Add(sub.SecretLevel);

                        detailDt.Rows.Add(cells.ToArray());
                    }
                }
                #endregion
            }

            #region 生成从属关系数据
            masterDt.TableName = "MainView";
            detailDt.TableName = "SubjectView";
            dsAll.Tables.Add(masterDt);
            dsAll.Tables.Add(detailDt);

            DataColumn keyColumn = dsAll.Tables[masterDt.TableName].Columns["row15"];         //主键
            DataColumn foreignColumn = dsAll.Tables[detailDt.TableName].Columns["row6"];    //外键
            //
            //对于主从表，层次名至关重要，关系名必须和从表的层次名一致,
            //否则从表显示的是从表的所有字段，而不是所设计的显示字段
            //

            dsAll.Relations.Add(detailDt.TableName, keyColumn, foreignColumn, false);     //从表的层次名
            gcGrid.DataSource = dsAll.Tables[masterDt.TableName];
            #endregion
        }

        private void srpSearch_OnResetClick(object sender, EventArgs args)
        {
            srpSearch.search();
        }

        private void srpSearch_OnExportToClick(object sender, EventArgs args)
        {
            if (dsAll != null && dsAll.Tables.Count >= 2)
            {
                List<KeyValuePair<string, string>> projectTable = new List<KeyValuePair<string, string>>();
                List<KeyValuePair<string, string>> subjectTable = new List<KeyValuePair<string, string>>();

                #region 检查需要输出的列
                //项目
                foreach (Control c in fplProject.Controls)
                {
                    if (c is CheckBox)                    {
                        CheckBox obj = ((CheckBox)c);
                        if (obj.Checked)
                        {
                            if (obj.Text == "课题列表")
                            {
                                projectTable.Add(new KeyValuePair<string, string>(obj.Text, "*****"));
                            }
                            else
                            {
                                projectTable.Add(new KeyValuePair<string, string>(obj.Text, ((GridColumn)obj.Tag).FieldName));
                            }
                        }
                    }
                }
                //课题
                if (fplSubject.Visible)
                {
                    foreach (Control c in fplSubject.Controls)
                    {
                        if (c is CheckBox)
                        {
                            CheckBox obj = ((CheckBox)c);
                            if (obj.Checked)
                            {
                                subjectTable.Add(new KeyValuePair<string, string>(obj.Text, ((GridColumn)obj.Tag).FieldName));
                            }
                        }
                    }
                }
                #endregion

                //创建临时表格
                DataTable dtt = new DataTable();
                List<DataColumn> cList = new List<DataColumn>();
                foreach (KeyValuePair<string, string> kvpp in projectTable)
                {
                    dtt.Columns.Add(kvpp.Key, typeof(string));
                }

                //取数据表
                DataTable mainView = dsAll.Tables["MainView"];
                DataTable subjectView = dsAll.Tables["SubjectView"];

                //构造数据
                for (int rowIndex = 0; rowIndex < mainView.Rows.Count; rowIndex++)
                {
                    List<object> cells = new List<object>();
                    string projectId = mainView.Rows[rowIndex]["row15"] != null ? mainView.Rows[rowIndex]["row15"].ToString() : string.Empty;

                    foreach (KeyValuePair<string, string> kvpp in projectTable)
                    {
                        if (kvpp.Key == "课题列表")
                        {
                            //课题数据
                            StringBuilder sb = new StringBuilder();
                            foreach (DataRow drr in subjectView.Rows)
                            {
                                string foreignId = drr["row6"] != null ? drr["row6"].ToString() : string.Empty;
                                if (projectId == foreignId)
                                {
                                    foreach (KeyValuePair<string, string> subKvp in subjectTable)
                                    {
                                        string val = drr[subKvp.Value] != null ? drr[subKvp.Value].ToString() : string.Empty;
                                        sb.Append(val).Append(",");
                                    }
                                    sb.Remove(sb.Length - 1, 1).AppendLine();
                                }
                            }
                            cells.Add(sb.ToString());
                        }
                        else
                        {
                            //项目数据
                            cells.Add(mainView.Rows[rowIndex][kvpp.Value] != null ? mainView.Rows[rowIndex][kvpp.Value].ToString() : string.Empty);
                        }
                    }
                    dtt.Rows.Add(cells.ToArray());
                }

                //导出
                ExcelHelper.ExportToExcel(dtt, "项目数据");
            }
        }

        private void srpSearch_OnCustomButtonClick(object sender, CustomButtonEventArgs args)
        {
            if (args.ButtonName == "列选择器")
            {
                dgvDetail.ShowCustomization();
            }
        }

        private void dgvDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            int[] rowIndexxx = dgvDetail.GetSelectedRows();
            if (rowIndexxx != null && rowIndexxx.Length == 1)
            {
                //第一行  
                if (e.RowHandle == rowIndexxx[0])
                {
                    if (cma1.MergeFieldNameList.Contains(e.Column.FieldName))
                    {
                        return;
                    }

                    e.Appearance.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    e.Appearance.Reset();
                }
            }
            else
            {
                e.Appearance.Reset();
            }
        }
    }
}