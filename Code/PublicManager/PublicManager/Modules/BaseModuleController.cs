using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

namespace PublicManager.Modules
{
    /// <summary>
    /// 模块控制器
    /// </summary>
    public partial class BaseModuleController : UserControl
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public BaseModuleController()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获得用于显示在顶部工具栏的RibbonPage
        /// </summary>
        /// <returns></returns>
        public virtual RibbonPage[] getTopBarPages() { return null; }

        /// <summary>
        /// 设置/获得用于显示内容的控件
        /// </summary>
        public virtual ScrollableControl DisplayControl { get; set; }

        /// <summary>
        /// 状态提示文本控件
        /// </summary>
        public virtual BarStaticItem StatusLabelControl { get; set; }

        /// <summary>
        /// 开始
        /// </summary>
        public virtual void start() { }

        /// <summary>
        /// 停止
        /// </summary>
        public virtual void stop() { }

        /// <summary>
        /// 输出数据表格
        /// </summary>
        /// <param name="workbook">工作文档</param>
        /// <param name="normalStyle">普通样式(用于表格内容)</param>
        /// <param name="boldStyle">粗体样式(用于表格头部)</param>
        /// <param name="table">表格数据</param>
        public static void writeSheet(NPOI.XSSF.UserModel.XSSFWorkbook workbook, NPOI.SS.UserModel.ICellStyle normalStyle, NPOI.SS.UserModel.ICellStyle boldStyle, DataTable table)
        {
            //创建Sheet页
            NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet();

            //行号
            int rowIndex = 0;

            //是否需要输出表头
            bool isNeedCreateHeader = true;

            //输出数据到Excel
            foreach (DataRow rowData in table.Rows)
            {
                //忽略空数据行
                if (rowData.ItemArray == null || rowData.ItemArray.Length != table.Columns.Count)
                {
                    continue;
                }

                //列号
                int colIndex = 0;

                //Excel行
                NPOI.SS.UserModel.IRow row = null;

                //是否需要输入表头
                if (isNeedCreateHeader)
                {
                    isNeedCreateHeader = false;

                    //创建行
                    row = sheet.CreateRow(rowIndex);
                    //输出列名到Excel
                    colIndex = 0;
                    foreach (DataColumn kvp in table.Columns)
                    {
                        //列名
                        //创建列
                        NPOI.SS.UserModel.ICell cell = row.CreateCell(colIndex);
                        //设置样式
                        cell.CellStyle = boldStyle;
                        //设置数据
                        cell.SetCellValue(kvp.ColumnName);
                        colIndex++;
                    }
                    rowIndex++;
                }

                //创建行
                row = sheet.CreateRow(rowIndex);
                //输出列值到Excel
                colIndex = 0;
                foreach (object val in rowData.ItemArray)
                {
                    //列值
                    //创建列
                    NPOI.SS.UserModel.ICell cell = row.CreateCell(colIndex);
                    //设置样式
                    cell.CellStyle = normalStyle;
                    //设置数据
                    //判断是否为空
                    if (val != null)
                    {
                        //不为空
                        //判断是否为RTF内容
                        if (val.GetType().Name.Equals(typeof(NPOI.XSSF.UserModel.XSSFRichTextString).Name))
                        {
                            //RTF内容
                            cell.SetCellValue((NPOI.XSSF.UserModel.XSSFRichTextString)val);
                        }
                        else
                        {
                            //文本内容
                            cell.SetCellValue(val.ToString());
                        }
                    }
                    else
                    {
                        //为空
                        cell.SetCellValue(string.Empty);
                    }
                    colIndex++;
                }
                rowIndex++;
            }

            //Excel列宽自动适应
            if (table.Rows.Count >= 1 && sheet.GetRow(0) != null)
            {
                for (int k = 0; k < sheet.GetRow(0).Cells.Count; k++)
                {
                    sheet.AutoSizeColumn(k);
                }
            }
        }
    }
}