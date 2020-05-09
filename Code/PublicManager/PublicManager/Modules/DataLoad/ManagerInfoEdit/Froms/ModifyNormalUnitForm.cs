using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class ModifyNormalUnitForm : RibbonForm
    {
        private Project proj;
        private DataTable dtSubject;
        private DataTable dtPerson;

        public ModifyNormalUnitForm(Project proj)
        {
            InitializeComponent();

            this.proj = proj;
            txtProjectNormalUnit.Text = proj.DutyNormalUnit;

            loadData();
        }

        /// <summary>
        /// 生成表头
        /// </summary>
        /// <param name="fieldNameBefore"></param>
        /// <param name="nodeFieldCount"></param>
        /// <param name="colNames"></param>
        public void makeColumns(string fieldNameBefore, int nodeFieldCount,string[] colNames)
        {
            gcGrid.DataSource = null;
            gvDetail.Columns.Clear();
            DataTable dtTemp = BaseModuleController.getTempDataTable(fieldNameBefore, nodeFieldCount);

            int colIndexx = 0;
            DevExpress.XtraGrid.Columns.GridColumn colTemp = null;
            foreach (string cName in colNames)
            {
                colIndexx++;
                colTemp = new DevExpress.XtraGrid.Columns.GridColumn();
                colTemp.Caption = cName;
                colTemp.FieldName = fieldNameBefore + colIndexx;
                colTemp.Name = fieldNameBefore + colIndexx;
                colTemp.Visible = true;
                colTemp.VisibleIndex = colIndexx;

                if (cName == "归一化单位")
                {
                    colTemp.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    colTemp.OptionsColumn.AllowEdit = false;
                }

                gvDetail.Columns.Add(colTemp);
            }
        }

        private void loadData()
        {
            Dictionary<string, string> subjectDict = new Dictionary<string, string>();

            dtSubject = BaseModuleController.getTempDataTable("row", 5);
            dtPerson = BaseModuleController.getTempDataTable("row", 6);

            //构造课题数据
            List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("ProjectID='" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
            foreach (Subject subObj in subjectList)
            {
                if (subObj.DutyNormalUnit == "未匹配")
                {
                    List<object> cells = new List<object>();
                    cells.Add(subObj.SubjectName);
                    cells.Add(subObj.DutyUnit);
                    cells.Add(subObj.DutyNormalUnit);
                    cells.Add(subObj.ProjectID);
                    cells.Add(subObj.SubjectID);

                    dtSubject.Rows.Add(cells.ToArray());
                }

                subjectDict[subObj.SubjectID] = subObj.SubjectName;
            }

            //构造人员数据
            List<Person> personList = ConnectionManager.Context.table("Person").where("ProjectID='" + proj.ProjectID + "'").select("*").getList<Person>(new Person());
            foreach (Person perObj in personList)
            {
                if (perObj.WorkNormalUnit == "未匹配")
                {
                    List<object> cells = new List<object>();
                    if (subjectDict.ContainsKey(perObj.SubjectID))
                    {
                        cells.Add(subjectDict[perObj.SubjectID]);
                    }
                    else
                    {
                        cells.Add(string.Empty);
                    }

                    cells.Add(perObj.PersonName);
                    cells.Add(perObj.WorkUnit);
                    cells.Add(perObj.WorkNormalUnit);
                    cells.Add(perObj.ProjectID);
                    cells.Add(perObj.PersonID);

                    dtPerson.Rows.Add(cells.ToArray());
                }
            }

            rbSubjectItems.Checked = true;

            makeColumns("row", 3, new string[] { "课题名称", "负责单位", "归一化单位" });
            gcGrid.DataSource = dtSubject;
        }

        private void rbSubjectItems_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbSubjectItems.Checked)
            {
                makeColumns("row", 3, new string[] { "课题名称", "负责单位", "归一化单位" });
                gcGrid.DataSource = dtSubject;
            }
            else
            {
                makeColumns("row", 4, new string[] { "课题名称", "人员名称", "负责单位", "归一化单位" });
                gcGrid.DataSource = dtPerson;
            }
        }

        private void gvDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            int[] rowIndexxx = gvDetail.GetSelectedRows();
            if (rowIndexxx != null && rowIndexxx.Length == 1)
            {
                //第一行  
                if (e.RowHandle == rowIndexxx[0])
                {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int errorCount = 0;
            #region 更新数据
            proj.DutyNormalUnit = txtProjectNormalUnit.Text;
            proj.copyTo(ConnectionManager.Context.table("Project")).where("ProjectID='" + proj.ProjectID + "'").update();
            if (proj.DutyNormalUnit == "未匹配")
            {
                errorCount++;
            }

            foreach (DataRow dr in dtSubject.Rows)
            {
                string normalUnit = dr["row3"] != null ? dr["row3"].ToString() : string.Empty;
                string projectID = dr["row4"] != null ? dr["row4"].ToString() : string.Empty;
                string subjectID = dr["row5"] != null ? dr["row5"].ToString() : string.Empty;

                Subject subjectObj = ConnectionManager.Context.table("Subject").where("SubjectID='" + subjectID + "' and ProjectID='" + projectID + "'").select("*").getItem<Subject>(new Subject());
                if (string.IsNullOrEmpty(subjectObj.SubjectID))
                {
                    continue;
                }

                subjectObj.DutyNormalUnit = normalUnit;
                subjectObj.copyTo(ConnectionManager.Context.table("Subject")).where("SubjectID='" + subjectID + "' and ProjectID='" + projectID + "'").update();

                if (subjectObj.DutyNormalUnit == "未匹配")
                {
                    errorCount++;
                }
            }

            foreach (DataRow dr in dtPerson.Rows)
            {
                string normalUnit = dr["row4"] != null ? dr["row4"].ToString() : string.Empty;
                string projectID = dr["row5"] != null ? dr["row5"].ToString() : string.Empty;
                string personID = dr["row6"] != null ? dr["row6"].ToString() : string.Empty;

                Person personObj = ConnectionManager.Context.table("Person").where("PersonID='" + personID + "' and ProjectID='" + projectID + "'").select("*").getItem<Person>(new Person());
                if (string.IsNullOrEmpty(personObj.PersonID))
                {
                    continue;
                }

                personObj.WorkNormalUnit = normalUnit;
                personObj.copyTo(ConnectionManager.Context.table("Person")).where("PersonID='" + personID + "' and ProjectID='" + projectID + "'").update();

                if (personObj.WorkNormalUnit == "未匹配")
                {
                    errorCount++;
                }
            }
            #endregion

            Catalog catalog = ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("*").getItem<Catalog>(new Catalog());
            catalog.IsCheckUnitComplete = errorCount == 0 ? "通过" : "不通过";
            proj.IsCheckUnitComplete = errorCount == 0 ? "通过" : "不通过";

            proj.copyTo(ConnectionManager.Context.table("Project")).where("ProjectID='" + proj.ProjectID + "'").update();
            catalog.copyTo(ConnectionManager.Context.table("Catalog")).where("CatalogID='" + catalog.CatalogID + "'").update();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}