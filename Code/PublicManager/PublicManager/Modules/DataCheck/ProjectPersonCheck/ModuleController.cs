using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.DataCheck.ProjectPersonCheck
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}