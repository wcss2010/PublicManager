using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.Teacher.TeacherManager
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetail_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvDetail.Rows.Count <= 0) return;
            dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = (dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty).ToString();
        }
    }
}