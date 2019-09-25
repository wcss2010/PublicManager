﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Localization;

namespace PublicManager.Modules.Reporter
{
    public partial class MainView : XtraUserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CustomButtonText(gridView1, SetGridLocalizer());

            DataTable dt = new DataTable();
            dt.Columns.Add("A", typeof(string));
            dt.Columns.Add("B", typeof(string));
            dt.Columns.Add("C", typeof(string));

            for (int kk = 1; kk <= 10; kk++)
            {
                dt.Rows.Add(new object[] { "数据D-" + kk, "数据E-" + kk, "数据F-" + kk });
            }
            gridControl1.DataSource = dt;
        }

        /// <summary>
        /// 自定义GridControl按钮文字
        /// </summary>
        /// <param name="girdview">GridView</param>
        /// <param name="cusLocalizedKeyValue">需要转移的GridStringId，其对应的文字描述</param>
        public void CustomButtonText(GridView girdview, Dictionary<GridStringId, string> cusLocalizedKeyValue)
        {
            BuilderGridLocalizer _bGridLocalizer = new BuilderGridLocalizer(cusLocalizedKeyValue);
            GridLocalizer.Active = _bGridLocalizer;            
        }
        private Dictionary<GridStringId, string> SetGridLocalizer()
        {
            Dictionary<GridStringId, string> _gridLocalizer = new Dictionary<GridStringId, string>();
            _gridLocalizer.Add(GridStringId.FindControlFindButton, "查找");
            _gridLocalizer.Add(GridStringId.FindControlClearButton, "清空");
            return _gridLocalizer;
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }
    }
}