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

namespace PublicManager.Modules.Lines.MoneySend
{
    public partial class ModuleController : BaseModuleController
    {
        public ModuleController()
        {
            InitializeComponent();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Clear();
            List<Project> projList = ConnectionManager.Context.table("Project").select("*").getList<Project>(new Project());
            foreach (Project proj in projList)
            {
                List<MoneySends> subList = ConnectionManager.Context.table("MoneySends").where("(CatalogID = '" + proj.CatalogID + "' and ProjectID = '" + proj.ProjectID + "')" + (string.IsNullOrEmpty(txtKey.Text) ? string.Empty : " and (SendRule like '%" + txtKey.Text + "%' or MemoText like '%" + txtKey.Text + "%')")).select("*").getList<MoneySends>(new MoneySends());
                foreach (MoneySends mss in subList)
                {
                    List<object> cells = new List<object>();
                    cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogVersion").getValue<string>("未知"));
                    cells.Add(ConnectionManager.Context.table("Catalog").where("CatalogID='" + proj.CatalogID + "'").select("CatalogType").getValue<string>("未知"));
                    cells.Add(mss.SendRule);
                    cells.Add(mss.WillTime.ToString("yyyy年MM月dd日"));
                    cells.Add(mss.TotalMoney);
                    cells.Add(mss.MemoText);

                    dgvDetail.Rows.Add(cells.ToArray());
                }
            }

            dgvDetail.checkCellSize();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            BaseModuleController.exportToExcel(dgvDetail);
        }
    }
}