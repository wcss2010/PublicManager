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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            updateCatalogs();
        }

        public void updateCatalogs()
        {
            dgvCatalogs.Rows.Clear();

            List<Catalog> list = ConnectionManager.Context.table("Catalog").where("CatalogType='建议书'").select("*").getList<Catalog>(new Catalog());
            int indexx = 0;
            foreach (Catalog catalog in list)
            {
                indexx++;

                List<object> cells = new List<object>();
                cells.Add(indexx);
                cells.Add(catalog.CatalogNumber);
                cells.Add(catalog.CatalogName);

                Person p = ConnectionManager.Context.table("Person").where("IsProjectMaster='true'").select("*").getItem<Person>(new Person());
                if (p != null)
                {
                    cells.Add(p.PersonName);
                    cells.Add(p.WorkUnit);
                }

                cells.Add("");

                dgvCatalogs.Rows.Add(cells.ToArray());
            }
        }
    }
}