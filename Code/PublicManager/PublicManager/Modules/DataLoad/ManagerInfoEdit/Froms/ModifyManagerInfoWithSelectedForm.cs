using DevExpress.XtraBars.Ribbon;
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
    public partial class ModifyManagerInfoWithSelectedForm : RibbonForm
    {
        private SearchRulePanel srpSearch;
        public ModifyManagerInfoWithSelectedForm(SearchRulePanel srpPanel)
        {
            InitializeComponent();

            this.srpSearch = srpPanel;
            loadDate();
        }

        private void loadDate()
        {
            
        }
    }
}