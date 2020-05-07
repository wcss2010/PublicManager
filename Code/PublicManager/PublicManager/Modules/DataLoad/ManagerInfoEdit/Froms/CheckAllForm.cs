using DevExpress.XtraBars.Ribbon;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.DataLoad.ManagerInfoEdit.Froms
{
    public partial class CheckAllForm : RibbonForm
    {
        private Project proj;

        public CheckAllForm(Project proj)
        {
            InitializeComponent();

            this.proj = proj;
        }
    }
}