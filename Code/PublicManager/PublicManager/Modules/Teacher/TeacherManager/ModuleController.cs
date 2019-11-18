using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.Modules.Teacher.TeacherManager.Forms;

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
            if (new AddOrUpdateTeacherForm(null).ShowDialog() == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Clear();
            List<DB.Entitys.Teacher> list = ConnectionManager.Context.table("Teacher").where("TName like '%" + txtKey.Text + "%' or TPhone like '%" + txtKey.Text + "%' or TJob like '%" + txtKey.Text + "%' or TUnit like '%" + txtKey.Text + "%' or TRange like '%" + txtKey.Text + "%'").select("*").getList<DB.Entitys.Teacher>(new DB.Entitys.Teacher());
            foreach (DB.Entitys.Teacher tr in list)
            {
                List<object> cells = new List<object>();
                cells.Add(tr.TName);
                cells.Add(tr.TSex);
                cells.Add(tr.TPhone);
                cells.Add(tr.TJob);
                cells.Add(tr.TUnit);
                cells.Add(tr.TRange);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = tr;
            }

            dgvDetail.checkCellSize();
        }

        private void dgvDetail_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvDetail.Rows.Count <= 0) return;
            dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = (dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty).ToString();
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DB.Entitys.Teacher teacherObj = ((DB.Entitys.Teacher)dgvDetail.Rows[e.RowIndex].Tag);

                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ConnectionManager.Context.table("Teacher").where("TeacherID='" + teacherObj.TeacherID + "'").delete();
                        ConnectionManager.Context.table("TeacherComment").where("TeacherID='" + teacherObj.TeacherID + "'").delete();
                        btnSearch.PerformClick();
                    }
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    //编辑
                    if (new AddOrUpdateTeacherForm(teacherObj).ShowDialog() == DialogResult.OK)
                    {
                        btnSearch.PerformClick();
                    }
                }
            }
        }
    }
}