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
        /// <summary>
        /// CatalogID筛选条件
        /// </summary>
        string strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
        private DEGridViewCellMergeAdapter cma;

        public ModuleController()
        {
            InitializeComponent();

            gvDetail.OptionsBehavior.Editable = false;
            gvDetail.OptionsView.AllowCellMerge = true;
            cma = new DEGridViewCellMergeAdapter(gvDetail, new string[] { "row7" });
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

        private void btnDownloadExcelA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnImportExcelA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selecteds = gvDetail.GetSelectedRows();
            if (selecteds != null && selecteds.Length >= 1)
            {
                object objValue = gvDetail.GetRowCellValue(selecteds[0], "row6");
                if (objValue != null && !string.IsNullOrEmpty(objValue.ToString()))
                {
                    string nodeId = objValue.ToString();

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
                            DataSet ds = ExcelHelper.ExcelToDataSet(sfd.FileName);
                            if (ds != null && ds.Tables.Count >= 2)
                            {
                                //清除数据
                                ConnectionManager.Context.table("Contact_Table4").where("NodeID='" + nodeId + "'").delete();
                                ConnectionManager.Context.table("Contact_Table5").where("NodeID='" + nodeId + "'").delete();

                                foreach (DataTable dt in ds.Tables)
                                {
                                    switch (dt.TableName)
                                    {
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
                                                    Contact_Table4 ct = new Contact_Table4();
                                                    ct.TID = Guid.NewGuid().ToString();
                                                    ct.CatalogID = mss.CatalogID;
                                                    ct.ProjectID = mss.ProjectID;
                                                    ct.NodeID = mss.MSID;
                                                    ct.ModuleName = dc.ColumnName + "xxxxx" + rowIndexx;
                                                    ct.ModuleValue = valStr;
                                                    ct.copyTo(ConnectionManager.Context.table("Contact_Table4")).insert();
                                                }
                                            }
                                            #endregion
                                            break;
                                        case "课题经费拨付与支出情况":
                                            #region 导入 课题经费拨付与支出情况
                                            foreach (DataRow dr in dt.Rows)
                                            {
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
                                                    continue;
                                                }

                                                Subject subjectObj = ConnectionManager.Context.table("Subject").where("SubjectName='" + value1 + "'").select("*").getItem<Subject>(new Subject());
                                                if (subjectObj != null && string.IsNullOrEmpty(subjectObj.SubjectID))
                                                {
                                                    continue;
                                                }

                                                Contact_Table5 ct = new Contact_Table5();
                                                ct.TID = Guid.NewGuid().ToString();
                                                ct.CatalogID = mss.CatalogID;
                                                ct.ProjectID = mss.ProjectID;
                                                ct.NodeID = mss.MSID;
                                                ct.SubjectID = subjectObj.SubjectID;
                                                ct.SubjectWorkUnit = value2;
                                                ct.SubjectTotalMoney = decimal.Parse(value3);
                                                ct.SubjectSendMoney = decimal.Parse(value4);
                                                ct.SubjectSendTime = DateTime.Parse(value5);
                                                ct.SubjectSendedMoney = decimal.Parse(value6);
                                                ct.SubjectUseMoney = decimal.Parse(value7);
                                                ct.SubjectNoSendMoney = decimal.Parse(value8);
                                                ct.copyTo(ConnectionManager.Context.table("Contact_Table5")).insert();
                                            }
                                            #endregion
                                            break;
                                    }
                                }
                                MessageBox.Show("导入完成！");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("对不起，Excel导入失败！Ex:" + ex.ToString());
                        }
                    }
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            exportToExcelWithDevExpress(gvDetail);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = getTempDataTable("row", 7);

            List<Project> projList = ConnectionManager.Context.table("Project").where("(ProjectName like '%" + txtKey.Text + "%')" + strCatalogIDFilterString).select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                List<MoneySends> subList = ConnectionManager.Context.table("MoneySends").where("(CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "')").select("*").getList<MoneySends>(new MoneySends());
                int indexx = 0;
                foreach (MoneySends mss in subList)
                {
                    indexx++;
                    List<object> cells = new List<object>();
                    cells.Add(indexx.ToString());
                    cells.Add(mss.SendRule);
                    cells.Add(mss.WillTime.ToString("yyyy年MM月dd日"));
                    cells.Add(mss.TotalMoney);
                    cells.Add(mss.MemoText);
                    cells.Add(mss.MSID);
                    cells.Add(proj.ProjectName);

                    dt.Rows.Add(cells.ToArray());
                }
            }
            gcGrid.DataSource = dt;
        }

        private void cbDisplayReporter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisplayContract.Checked && cbDisplayReporter.Checked)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
            }
            else if (cbDisplayContract.Checked)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog where CatalogType = '合同书')";
            }
            else if (cbDisplayReporter.Checked)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog where CatalogType = '建议书')";
            }
            else
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
            }
        }
    }
}