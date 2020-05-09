using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Localization;
using PublicManager.DB;
using PublicManager.DB.Entitys;

namespace PublicManager.Modules.Reporter
{
    public partial class MainView : XtraUserControl
    {
        public MainView()
        {
            InitializeComponent();
            gvDetail.OptionsBehavior.Editable = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            updateCatalogs();
        }

        public void updateCatalogs()
        {
            DataTable dt = BaseModuleController.getTempDataTable("row", 8);

            List<Catalog> list = ConnectionManager.Context.table("Catalog").where("CatalogType='建议书'").select("*").getList<Catalog>(new Catalog());
            int indexx = 0;
            foreach (Catalog catalog in list)
            {
                indexx++;

                List<object> cells = new List<object>();
                cells.Add(indexx);
                cells.Add(catalog.CatalogVersion);
                cells.Add(catalog.CatalogNumber);
                cells.Add(catalog.CatalogName);

                Person p = ConnectionManager.Context.table("Person").where("IsProjectMaster='true' and CatalogID = '" + catalog.CatalogID + "'").select("*").getItem<Person>(new Person());
                if (p != null)
                {
                    cells.Add(p.PersonName);
                    cells.Add(p.WorkUnit);
                }

                cells.Add(catalog.CatalogID);
                cells.Add("删除");

                dt.Rows.Add(cells.ToArray());
            }
            gcGrid.DataSource = dt;
        }

        private void gvDetail_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "row8")
            {
                object objectCatalogID = gvDetail.GetRowCellValue(e.RowHandle, "row7");
                if (objectCatalogID != null)
                {
                    string catalogID = objectCatalogID.ToString();

                    Catalog catalogObj = ConnectionManager.Context.table("Catalog").where("CatalogID='" + catalogID + "'").select("*").getItem<Catalog>(new Catalog());
                    if (string.IsNullOrEmpty(catalogObj.CatalogID))
                    {
                        return;
                    }

                    //获得要删除的项目ID,项目编号
                    string projectId = catalogObj.CatalogID;
                    string projectNumber = catalogObj.CatalogNumber;

                    //显示删除提示框
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //删除项目数据
                        new DBImporter().deleteProject(projectId);

                        //刷新GridView
                        updateCatalogs();

                        //刷新综合查询
                        if (MainForm.ModuleDict.ContainsKey(MainForm.allCheckKey))
                        {
                            ((PublicManager.Modules.DataCheck.AllCheck.ModuleController2)MainForm.ModuleDict[MainForm.allCheckKey]).reloadData();
                        }
                    }
                }
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
    }
}