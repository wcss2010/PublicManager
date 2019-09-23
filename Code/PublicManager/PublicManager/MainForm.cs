using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublicManager
{
    public partial class MainForm : RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void nbcLeftTree_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {

        }

        private void nbcLeftTree_NavPaneStateChanged(object sender, EventArgs e)
        {

        }

        private void tlTestA_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.GetDisplayText(0) == "111")
            {
               
            }
        }

        private void tlTestA_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {

        }
    }
}