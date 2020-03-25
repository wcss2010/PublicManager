using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.Lines.MoneyLines
{
    public partial class MoneyLinePage : UserControl
    {
        public MoneyLinePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置单元格的值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="txt"></param>
        public void setCellValue(int x, int y, string txt)
        {
            if (plDetail.ColumnCount > x && plDetail.RowCount > y && x >= 0 && y >= 0)
            {
                Control c = plDetail.GetControlFromPosition(x, y);
                if (c is Label)
                {
                    ((Label)c).Text = txt;
                }
                else if (c is Panel)
                {
                    Panel pp = (Panel)c;
                    foreach (Control sc in pp.Controls)
                    {
                        if (sc is Label)
                        {
                            ((Label)sc).Text = txt;
                        }
                    }
                }
            }
        }
    }
}