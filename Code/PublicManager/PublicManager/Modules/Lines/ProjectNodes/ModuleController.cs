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
        public ModuleController()
        {
            InitializeComponent();

            gvDetail.OptionsBehavior.Editable = false;
            //gvDetail.OptionsView.AllowCellMerge = true;
            //cma = new DEGridViewCellMergeAdapter(gvDetail, new string[] { "row3" });
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

            tvProjectList.ContentTreeView.AfterSelect += tvProjectList_AfterSelect;

            this.loadData();
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

                ////课题金额
                //List<Subject> subjectList = ConnectionManager.Context.table("Subject").where("CatalogID='" + catalog.CatalogID + "' and ProjectID='" + catalog.CatalogID + "'").select("*").getList<Subject>(new Subject());
                //foreach (Subject sub in subjectList)
                //{
                //    TreeNode subjectNode = new TreeNode();
                //    subjectNode.Text = sub.SubjectName;
                //    subjectNode.Tag = sub;
                //    parentNode.Nodes.Add(subjectNode);
                //}
            }
        }

        private void tvProjectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<List<object>> objectList = new List<List<object>>();

            if (e.Node.Tag is Catalog)
            {
                //项目年度列表
                Catalog catalogObj = (Catalog)e.Node.Tag;

                List<MoneySends> subList = ConnectionManager.Context.table("MoneySends").where("(CatalogID = '" + catalogObj.CatalogID + "' and ProjectID = '" + catalogObj.CatalogID + "')").select("*").getList<MoneySends>(new MoneySends());
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

                    objectList.Add(cells);
                }
            }

            DataTable dt = getTempDataTable("row", 6);
            foreach (List<object> lxItem in objectList)
            {
                dt.Rows.Add(lxItem.ToArray());
            }
            gcGrid.DataSource = dt;
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
    }
}