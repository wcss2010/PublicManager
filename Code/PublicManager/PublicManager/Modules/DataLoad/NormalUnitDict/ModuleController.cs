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
using PublicManager.Modules.Lines.ProjectLines.Froms;
using System.IO;
using System.Diagnostics;
using PublicManager.Modules.DataLoad.NormalUnitDict.Forms;

namespace PublicManager.Modules.DataLoad.NormalUnitDict
{
    public partial class ModuleController : BaseModuleController
    {
        public ModuleController()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;            
        }

        public override void start()
        {
            base.start();

            this.DisplayControl.Controls.Clear();
            this.Dock = DockStyle.Fill;
            this.DisplayControl.Controls.Add(this);

            this.loadData();
        }

        public override DevExpress.XtraBars.Ribbon.RibbonPage[] getTopBarPages()
        {
            return new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpMaster };
        }

        private void loadData()
        {
            DataTable dt = getTempDataTable("row", 5);
            List<DB.Entitys.NormalUnitDict> normalList = ConnectionManager.Context.table("NormalUnitDict").select("*").getList<DB.Entitys.NormalUnitDict>(new DB.Entitys.NormalUnitDict());
            foreach (DB.Entitys.NormalUnitDict nud in normalList)
            {
                List<object> cells = new List<object>();
                cells.Add(nud.DutyUnit);
                cells.Add(nud.DutyNormalUnit);
                cells.Add(nud.DID);
                cells.Add("删除");
                cells.Add("编辑");

                dt.Rows.Add(cells.ToArray());
            }

            gcGrid.DataSource = dt;
        }

        private void dgvDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int[] rowIndexxx = dgvDetail.GetSelectedRows();
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

        private void dgvDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "row4")
            {
                object objectDictID = dgvDetail.GetRowCellValue(e.RowHandle, "row3");
                if (objectDictID != null)
                {
                    string dictID = objectDictID.ToString();
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ConnectionManager.Context.table("NormalUnitDict").where("DID='" + dictID + "'").delete();
                        loadData();
                    }
                }
            }
            else if (e.Column.FieldName == "row5")
            {
                object objectDictID = dgvDetail.GetRowCellValue(e.RowHandle, "row3");
                if (objectDictID != null)
                {
                    string dictID = objectDictID.ToString();
                    //编辑
                    DB.Entitys.NormalUnitDict nuddd = ConnectionManager.Context.table("NormalUnitDict").where("DID='" + dictID + "'").select("*").getItem<DB.Entitys.NormalUnitDict>(new DB.Entitys.NormalUnitDict());
                    if (!string.IsNullOrEmpty(nuddd.DID))
                    {
                        AddOrUpdateNormalUnit unuForm = new AddOrUpdateNormalUnit(nuddd);
                        if (unuForm.ShowDialog() == DialogResult.OK)
                        {
                            loadData();
                        }
                    }
                }
            }            
        }

        private void btnDownloadExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Empty;
            sfd.Filter = "*.xlsx|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //复制模板文件
                    File.Copy(Path.Combine(Application.StartupPath, Path.Combine("Templetes", "UnitImporter.xlsx")), sfd.FileName);

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

        private void btnLoadExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.FileName = string.Empty;
            sfd.Filter = "*.xlsx|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataSet ds = ExcelHelper.ExcelToDataSet(sfd.FileName);
                    if (ds != null && ds.Tables.Count >= 1)
                    {
                        #region 清除数据
                        ConnectionManager.Context.table("NormalUnitDict").delete();
                        #endregion

                        foreach (DataTable dt in ds.Tables)
                        {
                            switch (dt.TableName)
                            {
                                case "Data":
                                    #region Data
                                    foreach (DataRow drr in dt.Rows)
                                    {
                                        string unitName = drr["单位法人名称"] != null ? drr["单位法人名称"].ToString() : string.Empty;
                                        string normalUnitName = drr["归一化名称"] != null ? drr["归一化名称"].ToString() : string.Empty;

                                        DB.Entitys.NormalUnitDict nudd = new DB.Entitys.NormalUnitDict();
                                        nudd.DID = Guid.NewGuid().ToString();
                                        nudd.DutyUnit = unitName;
                                        nudd.DutyNormalUnit = normalUnitName;
                                        nudd.copyTo(ConnectionManager.Context.table("NormalUnitDict")).insert();
                                    }
                                    #endregion
                                    break;
                            }
                        }

                        loadData();

                        MessageBox.Show("导入成功！");
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