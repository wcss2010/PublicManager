using DevExpress.XtraBars.Ribbon;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.DataLoad.ManagerInfoEdit.Froms
{
    public partial class ModifyManagerInfoForm : RibbonForm
    {
        private Project projectObj;
        public ModifyManagerInfoForm(Project proj)
        {
            InitializeComponent();

            projectObj = proj;
            //txtNormalUnit.Text = proj.DutyNormalUnit;
            txtProjectRange.Text = proj.ProjectRange;
            txtTaskNumber.Text = proj.TaskNumber;
            //cbxItemA.Text = proj.OKQuestionMemo;
            //cbxItemB.Text = proj.OKCheckA;
            //cbxItemC.Text = proj.OKCheckB;
            //cbxItemD.Text = proj.ContactCheckLevelA;
            //cbxItemE.Text = proj.ContactCheckLevelB;
            //txtMemo.Text = proj.Memo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //projectObj.DutyNormalUnit = txtNormalUnit.Text;
            projectObj.ProjectRange = txtProjectRange.Text;
            projectObj.TaskNumber = txtTaskNumber.Text;
            //projectObj.OKQuestionMemo = cbxItemA.Text;
            //projectObj.OKCheckA = cbxItemB.Text;
            //projectObj.OKCheckB = cbxItemC.Text;
            //projectObj.ContactCheckLevelA = cbxItemD.Text;
            //projectObj.ContactCheckLevelB = cbxItemE.Text;
            //projectObj.Memo = txtMemo.Text;
            projectObj.copyTo(ConnectionManager.Context.table("Project")).where("ProjectID='" + projectObj.ProjectID + "'").update();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}