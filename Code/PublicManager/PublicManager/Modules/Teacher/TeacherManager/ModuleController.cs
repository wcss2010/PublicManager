using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.Modules.Teacher.TeacherManager.Forms;
using System.IO;
using System.Diagnostics;

namespace PublicManager.Modules.Teacher.TeacherManager
{
    public partial class ModuleController : BaseModuleController
    {
        private int currentRowHandle = 0;

        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
            //dgvDetail.OptionsView.AllowCellMerge = true;
            //cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3" });
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);
        }

        private void dgvDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string teacherID = string.Empty;
            object objectTeacherID = dgvDetail.GetRowCellValue(e.RowHandle, "row9");
            if (objectTeacherID != null)
            {
                teacherID = objectTeacherID.ToString();
            }

            DB.Entitys.Teacher teacherObj = ConnectionManager.Context.table("Teacher").where("TeacherID='" + teacherID + "'").select("*").getItem<DB.Entitys.Teacher>(new DB.Entitys.Teacher());

            if (string.IsNullOrEmpty(teacherObj.TeacherID))
            {
                return;
            }
            else
            {
                if (e.Column.FieldName == "row10")
                {
                    //编辑
                    if (new AddOrUpdateTeacherForm(teacherObj).ShowDialog() == DialogResult.OK)
                    {
                        srpSearch.search();
                    }
                }
                else if (e.Column.FieldName == "row11")
                {
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ConnectionManager.Context.table("Teacher").where("TeacherID='" + teacherObj.TeacherID + "'").delete();
                        ConnectionManager.Context.table("TeacherComment").where("TeacherID='" + teacherObj.TeacherID + "'").delete();
                        srpSearch.search();
                    }
                }
            }
        }

        /// <summary>
        /// 获得选择项列表
        /// </summary>
        /// <returns></returns>
        public List<DB.Entitys.Teacher> getCheckedTeacherList()
        {
            List<DB.Entitys.Teacher> result = new List<DB.Entitys.Teacher>();
            int[] rowNumberList = dgvDetail.GetSelectedRows();
            foreach (int rowIndex in rowNumberList)
            {
                string teacherID = string.Empty;
                object objectTeacherID = dgvDetail.GetRowCellValue(rowIndex, "row9");
                if (objectTeacherID != null)
                {
                    teacherID = objectTeacherID.ToString();
                }

                DB.Entitys.Teacher teacherObj = ConnectionManager.Context.table("Teacher").where("TeacherID='" + teacherID + "'").select("*").getItem<DB.Entitys.Teacher>(new DB.Entitys.Teacher());
                if (string.IsNullOrEmpty(teacherObj.TeacherID))
                {
                    continue;
                }
                else
                {
                    result.Add(teacherObj);
                }
            }
            return result;
        }

        private void srpSearch_OnSearchClick(object sender, EventArgs args)
        {
            DataTable dtTemp = getTempDataTable("row", 11);

            List<DB.Entitys.Teacher> list = ConnectionManager.Context.table("Teacher").where("TName like '%" + srpSearch.Key1EditControl.Text + "%'").select("*").getList<DB.Entitys.Teacher>(new DB.Entitys.Teacher());
            foreach (DB.Entitys.Teacher tr in list)
            {
                List<object> cells = new List<object>();
                cells.Add(tr.TName);
                cells.Add(tr.TUnit);
                cells.Add(tr.TJob);
                cells.Add(tr.TJobTopic);
                cells.Add(tr.TDirection);
                cells.Add(tr.TPhone);
                cells.Add(tr.TSource);
                cells.Add(tr.TInnerJob);

                cells.Add(tr.TeacherID);

                cells.Add("编辑");
                cells.Add("删除");

                dtTemp.Rows.Add(cells.ToArray());
            }
            gcGrid.DataSource = dtTemp;
        }

        private void srpSearch_OnResetClick(object sender, EventArgs args)
        {
            srpSearch.search();
        }

        private void srpSearch_OnExportToClick(object sender, EventArgs args)
        {
            List<DB.Entitys.Teacher> selectedTeacherList = getCheckedTeacherList();

            if (selectedTeacherList.Count == 0)
            {
                MessageBox.Show("对不起，请选择要导出的专家！");
                return;
            }

            string sourcePath = Path.Combine(Application.StartupPath, Path.Combine("Templetes", "TeacherColumnExportTempletes.txt"));

            try
            {
                //读取列名称
                string[] colNames = File.ReadAllLines(sourcePath);

                //添加列
                DataTable dt = new DataTable();
                foreach (string col in colNames)
                {
                    if (string.IsNullOrEmpty(col))
                    {
                        continue;
                    }
                    else
                    {
                        dt.Columns.Add(col, typeof(string));
                    }
                }

                //生成数据
                foreach (DB.Entitys.Teacher teacherObj in selectedTeacherList)
                {
                    List<object> cells = new List<object>();
                    cells.Add(teacherObj.TName);
                    cells.Add(teacherObj.TName);
                    cells.Add(new Random((int)DateTime.Now.Ticks + (selectedTeacherList.IndexOf(teacherObj) + 1)).Next(100, 999).ToString());
                    cells.Add(teacherObj.TJob);
                    cells.Add(teacherObj.TJobTopic);
                    cells.Add(teacherObj.TPhone);
                    cells.Add(string.Empty);
                    dt.Rows.Add(cells.ToArray());
                }

                //导出数据
                ExcelHelper.ExportToExcel(dt, "专家信息");

                MessageBox.Show("导出完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败！Ex:" + ex.ToString());
            }
        }

        private void srpSearch_OnCustomButtonClick(object sender, CustomButtonEventArgs args)
        {
            switch (args.ButtonName)
            {
                case "下载导入模板":
                    {
                        string sourcePath = Path.Combine(Application.StartupPath, Path.Combine("Templetes", "teacherList.xlsx"));

                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Excel(2007-2013)|*.xlsx";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                File.Copy(sourcePath, sfd.FileName, true);
                                Process.Start(sfd.FileName);

                                MessageBox.Show("下载完成！");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("下载失败！Ex:" + ex.ToString());
                            }
                        }
                    }
                    break;
                case "新增":
                    {
                        if (new AddOrUpdateTeacherForm(null).ShowDialog() == DialogResult.OK)
                        {
                            srpSearch.search();
                        }
                    }
                    break;
                case "从Excel导入":
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "Excel(2007-2013)|*.xlsx";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                DataSet ds = ExcelHelper.ExcelToDataSet(ofd.FileName, true);
                                if (ds != null && ds.Tables.Count >= 1)
                                {
                                    DataTable dt = ds.Tables[0];

                                    foreach (DataRow drr in dt.Rows)
                                    {
                                        //检查非空
                                        foreach (DataColumn dc in drr.Table.Columns)
                                        {
                                            if (drr[dc.ColumnName] == null || drr[dc.ColumnName].ToString() == string.Empty)
                                            {
                                                throw new Exception("对不起，'" + dc.ColumnName + "'不能为空！");
                                            }
                                        }

                                        string strTag1 = drr["姓名"] != null ? drr["姓名"].ToString().Trim() : string.Empty;
                                        string strTag2 = drr["单位"] != null ? drr["单位"].ToString().Trim() : string.Empty;
                                        string strTag3 = drr["职务"] != null ? drr["职务"].ToString().Trim() : string.Empty;
                                        string strTag4 = drr["职称"] != null ? drr["职称"].ToString().Trim() : string.Empty;
                                        string strTag5 = drr["主要研究方向"] != null ? drr["主要研究方向"].ToString().Trim() : string.Empty;
                                        string strTag6 = drr["联系方式"] != null ? drr["联系方式"].ToString().Trim() : string.Empty;
                                        string strTag7 = drr["专家来源"] != null ? drr["专家来源"].ToString().Trim() : string.Empty;
                                        string strTag8 = drr["内部职务"] != null ? drr["内部职务"].ToString().Trim() : string.Empty;

                                        DB.Entitys.Teacher teacherObj = new DB.Entitys.Teacher();
                                        teacherObj.TeacherID = Guid.NewGuid().ToString();
                                        teacherObj.TName = strTag1;
                                        teacherObj.TUnit = strTag2;
                                        teacherObj.TJob = strTag3;
                                        teacherObj.TJobTopic = strTag4;
                                        teacherObj.TDirection = strTag5;
                                        teacherObj.TPhone = strTag6;
                                        teacherObj.TSource = strTag7;
                                        teacherObj.TInnerJob = strTag8;

                                        object objResult = ConnectionManager.Context.table("Teacher").where("TName='" + teacherObj.TName + "' and TPhone = '" + teacherObj.TPhone + "'").select("TeacherID").getValue();
                                        if (objResult == null || objResult.ToString().Equals(string.Empty))
                                        {
                                            teacherObj.copyTo(ConnectionManager.Context.table("Teacher")).insert();
                                        }
                                        else
                                        {
                                            teacherObj.TeacherID = objResult.ToString();
                                            teacherObj.copyTo(ConnectionManager.Context.table("Teacher")).where("TeacherID='" + teacherObj.TeacherID + "'").update();
                                        }
                                    }
                                }
                                srpSearch.search();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("对不起，导入失败！Ex:" + ex.ToString());
                            }
                        }
                    }
                    break;
            }
        }

        private void dgvDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == currentRowHandle)
            {
                e.Appearance.BackColor = Color.LightSkyBlue;
            }
            else
            {
                e.Appearance.Reset();
            }
        }

        private void dgvDetail_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            currentRowHandle = e.RowHandle;
            dgvDetail.RefreshData();
        }
    }
}