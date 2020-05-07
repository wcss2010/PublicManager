using DevExpress.XtraBars.Ribbon;
using PublicManager.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.DataLoad.NormalUnitDict.Forms
{
    public partial class AddOrUpdateNormalUnit : RibbonForm
    {
        private DB.Entitys.NormalUnitDict DataObj { get; set; }

        public AddOrUpdateNormalUnit(DB.Entitys.NormalUnitDict nuddd)
        {
            InitializeComponent();

            this.DataObj = nuddd;

            if (this.DataObj == null)
            {
                this.DataObj = new DB.Entitys.NormalUnitDict();
            }
            txtUnitName.Text = DataObj.DutyUnit;
            txtNormalUnitName.Text = DataObj.DutyNormalUnit;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataObj.DutyUnit = txtUnitName.Text;
            DataObj.DutyNormalUnit = txtNormalUnitName.Text;

            if (string.IsNullOrEmpty(this.DataObj.DID))
            {
                DataObj.DID = Guid.NewGuid().ToString();
                DataObj.copyTo(ConnectionManager.Context.table("NormalUnitDict")).insert();
            }
            else
            {
                DataObj.copyTo(ConnectionManager.Context.table("NormalUnitDict")).where("DID='" + DataObj.DID + "'").update();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}