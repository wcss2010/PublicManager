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
using System.IO;
using System.Diagnostics;

namespace PublicManager.Modules.Lines.ProjectNodes
{
    public partial class ModuleController : BaseModuleController
    {
        private DEGridViewCellMergeAdapter cma;

        public ModuleController()
        {
            InitializeComponent();

            gvDetail.OptionsBehavior.Editable = false;
            gvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(gvDetail, new string[] { "row7" });

            srpSearch.RightButtonPanelWidth = 350;
            srpSearch.Key3PanelWidth = 275;
            srpSearch.Key4PanelWidth = 275;
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

            this.loadData();
        }

        private void loadData()
        {
        }

        private void gvDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.CellValue != null && e.CellValue.ToString() == "从Excel导入数据")
            {
                int[] selecteds = gvDetail.GetSelectedRows();
                if (selecteds != null && selecteds.Length >= 1)
                {
                    object objValue = gvDetail.GetRowCellValue(selecteds[0], "row6");
                    if (objValue != null && !string.IsNullOrEmpty(objValue.ToString()))
                    {
                        string nodeId = objValue.ToString();
                        nodeImport(nodeId);
                    }
                }
            }
        }

        private void nodeImport(string nodeId)
        {
            MoneySends mss = ConnectionManager.Context.table("MoneySends").where("MSID='" + nodeId + "'").select("*").getItem<MoneySends>(new MoneySends());
            if (mss != null && string.IsNullOrEmpty(mss.MSID))
            {
                return;
            }

            OpenFileDialog sfd = new OpenFileDialog();
            sfd.FileName = string.Empty;
            sfd.Filter = "*.xlsx|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int subjectCount = 0;
                    List<string> errorSubjectList = new List<string>();

                    DataSet ds = ExcelHelper.ExcelToDataSet(sfd.FileName);
                    if (ds != null && ds.Tables.Count >= 2)
                    {
                        #region 清除数据
                        ConnectionManager.Context.table("Contact_Table1").where("NodeID='" + nodeId + "'").delete();
                        ConnectionManager.Context.table("Contact_Table2").where("NodeID='" + nodeId + "'").delete();
                        ConnectionManager.Context.table("Contact_Table3").where("NodeID='" + nodeId + "'").delete();
                        ConnectionManager.Context.table("Contact_Table4").where("NodeID='" + nodeId + "'").delete();
                        ConnectionManager.Context.table("Contact_Table5").where("NodeID='" + nodeId + "'").delete();
                        #endregion

                        foreach (DataTable dt in ds.Tables)
                        {
                            switch (dt.TableName)
                            {
                                case "项目基本情况":
                                    #region 项目基本情况

                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        string value1 = dr["项目名称"] != null ? dr["项目名称"].ToString() : string.Empty;
                                        string value2 = dr["项目牵头单位"] != null ? dr["项目牵头单位"].ToString() : string.Empty;
                                        string value3 = dr["项目总负责人"] != null ? dr["项目总负责人"].ToString() : string.Empty;
                                        string value4 = dr["项目总经费"] != null ? dr["项目总经费"].ToString() : string.Empty;
                                        string value5 = dr["项目到位经费"] != null ? dr["项目到位经费"].ToString() : string.Empty;

                                        string value6 = dr["节点评估时间"] != null ? dr["节点评估时间"].ToString() : string.Empty;
                                        string value7 = dr["节点评估意见"] != null ? dr["节点评估意见"].ToString() : string.Empty;
                                        string value8 = dr["节点评估等级"] != null ? dr["节点评估等级"].ToString() : string.Empty;
                                        string value9 = dr["节点评估专家"] != null ? dr["节点评估专家"].ToString() : string.Empty;

                                        //添加节点-项目信息
                                        Contact_Table1 ct1 = new Contact_Table1();
                                        ct1.TID = Guid.NewGuid().ToString();
                                        ct1.CatalogID = mss.CatalogID;
                                        ct1.ProjectID = mss.ProjectID;
                                        ct1.NodeID = mss.MSID;

                                        ct1.ProjectName = value1;
                                        ct1.WorkUnit = value2;
                                        ct1.ProjectMaster = value3;
                                        try
                                        {
                                            ct1.TotalMoney = decimal.Parse(value4);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("对不起，项目(" + value1 + ")的总经费错误！");
                                        }
                                        try
                                        {
                                            ct1.TotalMoneyNow = decimal.Parse(value5);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("对不起，项目(" + value1 + ")的到位错误！");
                                        }

                                        ct1.copyTo(ConnectionManager.Context.table(typeof(Contact_Table1).Name)).insert();

                                        //更新节点信息
                                        try
                                        {
                                            mss.NodeWillTime = DateTime.Parse(value6);
                                        }
                                        catch (Exception ex) { }

                                        mss.WillContent = value7;
                                        mss.WillLevel = value8;
                                        mss.WillWorker = value9;
                                        mss.copyTo(ConnectionManager.Context.table("MoneySends")).where("MSID='" + mss.MSID + "'").update();
                                    }
                                    #endregion
                                    break;
                                case "项目办公室组成":
                                    #region 项目办公室组成
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        string value1 = dr["项目办公室职务"] != null ? dr["项目办公室职务"].ToString() : string.Empty;
                                        string value2 = dr["姓名"] != null ? dr["姓名"].ToString() : string.Empty;
                                        string value3 = dr["单位"] != null ? dr["单位"].ToString() : string.Empty;
                                        string value4 = dr["职务/职称"] != null ? dr["职务/职称"].ToString() : string.Empty;
                                        string value5 = dr["联系电话"] != null ? dr["联系电话"].ToString() : string.Empty;

                                        Contact_Table2 ct2 = new Contact_Table2();
                                        ct2.TID = Guid.NewGuid().ToString();
                                        ct2.CatalogID = mss.CatalogID;
                                        ct2.ProjectID = mss.ProjectID;
                                        ct2.NodeID = mss.MSID;

                                        ct2.WorkDeskJob = value1;
                                        ct2.PersonName = value2;
                                        ct2.PersonUnit = value3;
                                        ct2.PersonJob = value4;
                                        ct2.PersonPhone = value5;

                                        ct2.copyTo(ConnectionManager.Context.table(typeof(Contact_Table2).Name)).insert();
                                    }

                                    #endregion
                                    break;
                                case "项目完成情况":
                                    #region 项目完成情况
                                    foreach (DataColumn dc in dt.Columns)
                                    {
                                        if (string.IsNullOrEmpty(dc.ColumnName))
                                        {
                                            continue;
                                        }

                                        int rowIndexxx = 0;
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            rowIndexxx++;
                                            string valueStr = dr[dc.ColumnName] != null ? dr[dc.ColumnName].ToString() : string.Empty;

                                            Contact_Table3 ct3 = new Contact_Table3();
                                            ct3.TID = Guid.NewGuid().ToString();
                                            ct3.CatalogID = mss.CatalogID;
                                            ct3.ProjectID = mss.ProjectID;
                                            ct3.NodeID = mss.MSID;

                                            ct3.ModuleName = dc.ColumnName + "xxxxx" + rowIndexxx;
                                            ct3.ModuleValue = valueStr;

                                            ct3.copyTo(ConnectionManager.Context.table(typeof(Contact_Table3).Name)).insert();
                                        }
                                    }
                                    #endregion
                                    break;
                                case "项目经费使用情况":
                                    #region 导入 项目经费使用情况
                                    foreach (DataColumn dc in dt.Columns)
                                    {
                                        if (dc.ColumnName == "科目名称")
                                        {
                                            continue;
                                        }

                                        //添数据
                                        int rowIndexx = 0;
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            rowIndexx++;

                                            //取值
                                            string valStr = dr[dc.ColumnName] != null ? dr[dc.ColumnName].ToString() : string.Empty;
                                            Contact_Table4 ct4 = new Contact_Table4();
                                            ct4.TID = Guid.NewGuid().ToString();
                                            ct4.CatalogID = mss.CatalogID;
                                            ct4.ProjectID = mss.ProjectID;
                                            ct4.NodeID = mss.MSID;
                                            ct4.ModuleName = dc.ColumnName + "xxxxx" + rowIndexx;
                                            ct4.ModuleValue = valStr;
                                            ct4.copyTo(ConnectionManager.Context.table("Contact_Table4")).insert();
                                        }
                                    }
                                    #endregion
                                    break;
                                case "课题经费拨付与支出情况":
                                    #region 导入 课题经费拨付与支出情况
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        subjectCount++;

                                        string value1 = dr["课题名称"] != null ? dr["课题名称"].ToString() : string.Empty;
                                        string value2 = dr["课题负责单位"] != null ? dr["课题负责单位"].ToString() : string.Empty;
                                        string value3 = dr["课题合同总价款"] != null ? dr["课题合同总价款"].ToString() : string.Empty;
                                        string value4 = dr["课题应拨经费"] != null ? dr["课题应拨经费"].ToString() : string.Empty;
                                        string value5 = dr["课题经费拨付时间"] != null ? dr["课题经费拨付时间"].ToString() : string.Empty;
                                        string value6 = dr["课题已拨经费"] != null ? dr["课题已拨经费"].ToString() : string.Empty;
                                        string value7 = dr["课题支出经费"] != null ? dr["课题支出经费"].ToString() : string.Empty;
                                        string value8 = dr["课题应拨未拨经费"] != null ? dr["课题应拨未拨经费"].ToString() : string.Empty;

                                        if (string.IsNullOrEmpty(value1))
                                        {
                                            errorSubjectList.Add(value1);
                                            continue;
                                        }

                                        Subject subjectObj = ConnectionManager.Context.table("Subject").where("CatalogID='" + mss.CatalogID + "' and SubjectName='" + value1 + "'").select("*").getItem<Subject>(new Subject());
                                        if (subjectObj != null && string.IsNullOrEmpty(subjectObj.SubjectID))
                                        {
                                            errorSubjectList.Add(value1);
                                            continue;
                                        }

                                        Contact_Table5 ct5 = new Contact_Table5();
                                        ct5.TID = Guid.NewGuid().ToString();
                                        ct5.CatalogID = mss.CatalogID;
                                        ct5.ProjectID = mss.ProjectID;
                                        ct5.NodeID = mss.MSID;
                                        ct5.SubjectID = subjectObj.SubjectID;
                                        ct5.SubjectWorkUnit = value2;
                                        ct5.SubjectTotalMoney = decimal.Parse(value3);
                                        ct5.SubjectSendMoney = decimal.Parse(value4);
                                        ct5.SubjectSendTime = DateTime.Parse(value5);
                                        ct5.SubjectSendedMoney = decimal.Parse(value6);
                                        ct5.SubjectUseMoney = decimal.Parse(value7);
                                        ct5.SubjectNoSendMoney = decimal.Parse(value8);
                                        ct5.copyTo(ConnectionManager.Context.table("Contact_Table5")).insert();
                                    }
                                    #endregion
                                    break;
                            }
                        }

                        //组织文字
                        StringBuilder importResult = new StringBuilder();
                        importResult.Append("导入成功！").Append("共找到课题经费拨付支出情况").Append(subjectCount).Append("条,其中").Append(errorSubjectList.Count).Append("条导入错误！");
                        if (errorSubjectList.Count >= 1)
                        {
                            importResult.Append("分别是(");
                            foreach (string s in errorSubjectList)
                            {
                                importResult.Append("\"").Append(s).Append("\",");
                            }
                            importResult.Remove(importResult.Length - 1, 1);
                            importResult.Append(")");
                        }

                        MessageBox.Show(importResult.ToString());
                    }
                    srpSearch.search();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对不起，Excel导入失败！Ex:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 检查是不是今天的数据
        /// </summary>
        /// <param name="val"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        private bool isCurrentDay(DateTime val, DateTimePicker picker)
        {
            if (val > DateTime.MinValue && picker != null && picker.Value > DateTime.MinValue)
            {
                DateTime startTime = new DateTime(picker.Value.Year, picker.Value.Month, picker.Value.Day, 0, 0, 0);
                DateTime endTime = new DateTime(picker.Value.Year, picker.Value.Month, picker.Value.Day, 23, 59, 59);

                return val >= startTime && val <= endTime;
            }
            else
            {
                return false;
            }
        }

        private void srpSearch_OnSearchClick(object sender, EventArgs args)
        {
            DataTable dt = getTempDataTable("row", 12);

            List<Project> projList = MakeSQLWithSearchRule.getProjectList(srpSearch);
            foreach (Project proj in projList)
            {
                List<MoneySends> subList = ConnectionManager.Context.table("MoneySends").where("(CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "')").orderBy("NodeIndex").select("*").getList<MoneySends>(new MoneySends());
                int indexx = 0;
                foreach (MoneySends mss in subList)
                {
                    if (srpSearch.Key3Label.Checked && isCurrentDay(mss.NodeWillTime, srpSearch.Key3EditControl) == false)
                    {
                        continue;
                    }
                    if (srpSearch.Key4Label.Checked && isCurrentDay(mss.WillTime, srpSearch.Key4EditControl) == false)
                    {
                        continue;
                    }

                    List<object> cells = new List<object>();
                    cells.Add(mss.NodeIndex);
                    cells.Add(mss.SendRule);
                    cells.Add(ExcelHelper.getDateTimeForString(mss.WillTime, "yyyy年MM月dd日", string.Empty));
                    cells.Add(mss.TotalMoney);
                    cells.Add(mss.MemoText);
                    cells.Add(mss.MSID);
                    cells.Add(proj.ProjectName);
                    cells.Add(ExcelHelper.getDateTimeForString(mss.NodeWillTime, "yyyy年MM月dd日", string.Empty));
                    cells.Add(mss.WillContent);
                    cells.Add(mss.WillLevel);
                    cells.Add(mss.WillWorker);

                    cells.Add("从Excel导入数据");

                    dt.Rows.Add(cells.ToArray());
                }
            }
            gcGrid.DataSource = dt;
        }

        private void srpSearch_OnResetClick(object sender, EventArgs args)
        {
            srpSearch.search();
        }

        private void srpSearch_OnExportToClick(object sender, EventArgs args)
        {
            exportToExcelWithDevExpress(gvDetail);
        }

        private void srpSearch_OnCustomButtonClick(object sender, CustomButtonEventArgs args)
        {
        }

        private void htnDownloadTemplete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Empty;
            sfd.Filter = "*.xlsx|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //复制模板文件
                    File.Copy(Path.Combine(Application.StartupPath, Path.Combine("Templetes", "moneyImport.xlsx")), sfd.FileName);

                    //弹出提示
                    MessageBox.Show("Excel导出完成！" + sfd.FileName);

                    //打开文件
                    if (File.Exists(sfd.FileName))
                    {
                        Process.Start(sfd.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对不起，Excel导出失败！Ex:" + ex.ToString());
                }
            }
        }

        private void btnImportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvDetail.GetSelectedRows() != null && gvDetail.GetSelectedRows().Length == 1)
            {
                object objValue = gvDetail.GetRowCellValue(gvDetail.GetSelectedRows()[0], "row6");
                if (objValue != null && !string.IsNullOrEmpty(objValue.ToString()))
                {
                    string nodeId = objValue.ToString();
                    nodeImport(nodeId);
                }
            }
        }

        private void btnImportExcelWithTeams_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}