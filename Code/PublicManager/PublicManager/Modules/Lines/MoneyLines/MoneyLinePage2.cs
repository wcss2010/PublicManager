using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules.Lines.MoneyLines
{
    public partial class MoneyLinePage2 : UserControl
    {
        public MoneyLinePage2()
        {
            InitializeComponent();

            dgvDetail.OptionsBehavior.Editable = false;
        }

        public void setTag1Value(string txt)
        {
            lblTag1.Text = txt;
        }

        public void setTag2Value(string txt)
        {
            lblTag2.Text = txt;
        }

        public void setTag3Value(string txt)
        {
            lblTag3.Text = txt;
        }

        public void setTag4Value(string txt)
        {
            lblTag4.Text = txt;
        }

        public void showOrHideTopPanel(bool isShow)
        {
            plTop.Visible = isShow;
        }

        public DataTable getTempMoneyTable(string fieldNameBefore, int nodeFieldCount)
        {
            #region 生成DataTable和Column
            dgvDetail.Columns.Clear();
            DataTable dtTemp = BaseModuleController.getTempDataTable(fieldNameBefore, 4 + nodeFieldCount);

            int colIndexx = 0;

            colIndexx++;
            DevExpress.XtraGrid.Columns.GridColumn colTemp = new DevExpress.XtraGrid.Columns.GridColumn();
            colTemp.Caption = "科目名称";
            colTemp.FieldName = fieldNameBefore + colIndexx;
            colTemp.Name = fieldNameBefore + colIndexx;
            colTemp.Visible = true;
            colTemp.VisibleIndex = colIndexx;
            dgvDetail.Columns.Add(colTemp);

            colIndexx++;
            colTemp = new DevExpress.XtraGrid.Columns.GridColumn();
            colTemp.Caption = "项目合同总价款";
            colTemp.FieldName = fieldNameBefore + colIndexx;
            colTemp.Name = fieldNameBefore + colIndexx;
            colTemp.Visible = true;
            colTemp.VisibleIndex = colIndexx;
            dgvDetail.Columns.Add(colTemp);

            for (int kkk = 1; kkk <= nodeFieldCount; kkk++)
            {
                colIndexx++;
                colTemp = new DevExpress.XtraGrid.Columns.GridColumn();
                colTemp.Caption = "项目节点" + kkk + "支出经费";
                colTemp.FieldName = fieldNameBefore + colIndexx;
                colTemp.Name = fieldNameBefore + colIndexx;
                colTemp.Visible = true;
                colTemp.VisibleIndex = colIndexx;
                dgvDetail.Columns.Add(colTemp);
            }

            colIndexx++;
            colTemp = new DevExpress.XtraGrid.Columns.GridColumn();
            colTemp.Caption = "项目累计支出经费";
            colTemp.FieldName = fieldNameBefore + colIndexx;
            colTemp.Name = fieldNameBefore + colIndexx;
            colTemp.Visible = true;
            colTemp.VisibleIndex = colIndexx;
            dgvDetail.Columns.Add(colTemp);

            colIndexx++;
            colTemp = new DevExpress.XtraGrid.Columns.GridColumn();
            colTemp.Caption = "备注";
            colTemp.FieldName = fieldNameBefore + colIndexx;
            colTemp.Name = fieldNameBefore + colIndexx;
            colTemp.Visible = true;
            colTemp.VisibleIndex = colIndexx;
            dgvDetail.Columns.Add(colTemp);
            #endregion

            #region 写入第一列的值
            string[] tNames = new string[] { "(一) 直接费用","  1.设备费","    (1)设备购置费","    (2)设备试制费","    (3)其他","  2.材料费","  3.外部协作费","  4.燃料动力费","  5.会议/差旅/国际合作与交流费","  6.出版/文献/信息传播知识产权事务费","  7.劳务费","  8.专家咨询费","  9.其他支出","(二) 间接费用","  10.管理费/科研绩效支出" };
            foreach (string s in tNames)
            {
                List<string> cells = new List<string>();
                cells.Add(s);
                for (int ffff = 0; ffff < dtTemp.Columns.Count - 1; ffff++)
                {
                    cells.Add(string.Empty);
                }
                dtTemp.Rows.Add(cells.ToArray());
            }
            #endregion

            return dtTemp;
        }

        public void setTableDataSource(DataTable dt)
        {
            gcGrid.DataSource = dt;
        }

        public void showOrHideColumn(int colIndex,bool isShow)
        {
            dgvDetail.Columns[colIndex].Visible = isShow;
        }

        public void setNodeName(string nodeName)
        {
            plMain.Text = plMain.Tag + nodeName;
        }
    }
}