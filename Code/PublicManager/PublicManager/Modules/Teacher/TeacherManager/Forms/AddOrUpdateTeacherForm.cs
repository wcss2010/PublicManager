using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.Modules.Teacher.TeacherManager.Forms;
using DevExpress.XtraBars.Ribbon;

namespace PublicManager.Modules.Teacher.TeacherManager.Forms
{
    public partial class AddOrUpdateTeacherForm : RibbonForm
    {
        public DB.Entitys.Teacher TeacherObj { get; set; }

        public string teacherID = string.Empty;

        public AddOrUpdateTeacherForm(DB.Entitys.Teacher teacher)
        {
            InitializeComponent();

            TeacherObj = teacher;

            txtTSex.SelectedIndex = 0;

            dgvDetail.OptionsBehavior.Editable = false;
            //dgvDetail.OptionsView.AllowCellMerge = true;
            //cma = new DEGridViewCellMergeAdapter(dgvDetail, new string[] { "row3" });
        }

        private void updateTeacherComments()
        {
            if (TeacherObj != null)
            {
                DataTable dtTemp = BaseModuleController.getTempDataTable("row", 5);

                List<DB.Entitys.TeacherComment> list = ConnectionManager.Context.table("TeacherComment").where("TeacherID='" + teacherID + "'").select("*").getList<DB.Entitys.TeacherComment>(new DB.Entitys.TeacherComment());
                foreach (DB.Entitys.TeacherComment tc in list)
                {
                    List<object> cells = new List<object>();
                    cells.Add(ExcelHelper.getDateTimeForString(tc.CommentDate, "yyyy年MM月dd日", string.Empty));
                    cells.Add(tc.CommentText);

                    cells.Add(tc.TeacherCommentID);

                    cells.Add("编辑");
                    cells.Add("删除");

                    dtTemp.Rows.Add(cells.ToArray());
                }
                gcGrid.DataSource = dtTemp;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtTName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入专家名称!");
                return;
            }
            if (txtTSex.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入性别!");
                return;
            }
            if (txtTPhone.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入联系方式!");
                return;
            }
            if (txtTJob.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入职务!");
                return;
            }
            if (txtTJobName.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入职称!");
                return;
            }
            if (txtTUnit.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入单位!");
                return;
            }
            if (txtTDirection.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入主要研究方向!");
                return;
            }
            if (txtTSource.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入专家来源!");
                return;
            }
            if (txtTInnerJob.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入内部职务!");
                return;
            }

            TeacherObj.TName = txtTName.Text;
            TeacherObj.TSex = txtTSex.Text;
            TeacherObj.TPhone = txtTPhone.Text;
            TeacherObj.TJob = txtTJob.Text;
            TeacherObj.TJobTopic = txtTJobName.Text;
            TeacherObj.TUnit = txtTUnit.Text;
            TeacherObj.TDirection = txtTDirection.Text;
            TeacherObj.TSource = txtTSource.Text;
            TeacherObj.TInnerJob = txtTInnerJob.Text;

            if (string.IsNullOrEmpty(TeacherObj.TeacherID))
            {
                TeacherObj.TeacherID = teacherID;
                TeacherObj.copyTo(ConnectionManager.Context.table("Teacher")).insert();
            }
            else
            {
                TeacherObj.copyTo(ConnectionManager.Context.table("Teacher")).where("TeacherID='" + TeacherObj.TeacherID + "'").update();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            AddOrUpdateTeacherCommentForm form = new AddOrUpdateTeacherCommentForm(null);
            form.CommentObj.TeacherID = teacherID;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                updateTeacherComments();
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (string.IsNullOrEmpty(teacherID))
            {
                if (TeacherObj != null)
                {
                    teacherID = TeacherObj.TeacherID;

                    txtTName.Text = TeacherObj.TName;
                    txtTSex.Text = TeacherObj.TSex;
                    txtTPhone.Text = TeacherObj.TPhone;
                    txtTJob.Text = TeacherObj.TJob;
                    txtTJobName.Text = TeacherObj.TJobTopic;
                    txtTUnit.Text = TeacherObj.TUnit;
                    txtTDirection.Text = TeacherObj.TDirection;
                    txtTSource.Text = TeacherObj.TSource;
                    txtTInnerJob.Text = TeacherObj.TInnerJob;

                    updateTeacherComments();
                }
                else
                {
                    teacherID = Guid.NewGuid().ToString();
                    TeacherObj = new DB.Entitys.Teacher();
                }
            }
        }

        private void dgvDetail_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            string teacherCommentID = string.Empty;
            object objectTeacherCommentID = dgvDetail.GetRowCellValue(e.RowHandle, "row3");
            if (objectTeacherCommentID != null)
            {
                teacherCommentID = objectTeacherCommentID.ToString();
            }

            DB.Entitys.TeacherComment commentObj = ConnectionManager.Context.table("TeacherComment").where("TeacherCommentID='" + teacherCommentID + "'").select("*").getItem<DB.Entitys.TeacherComment>(new DB.Entitys.TeacherComment());
            if (string.IsNullOrEmpty(commentObj.TeacherCommentID))
            {
                return;
            }
            else
            {
                if (e.Column.FieldName == "row4")
                {
                    //编辑
                    if (new AddOrUpdateTeacherCommentForm(commentObj).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        updateTeacherComments();
                    }
                }
                else if (e.Column.FieldName == "row5")
                {
                    //删除
                    if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ConnectionManager.Context.table("TeacherComment").where("TeacherCommentID='" + commentObj.TeacherCommentID + "'").delete();
                        updateTeacherComments();
                    }
                }
            }
        }
    }
}