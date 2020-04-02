using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Threading;
using NPOI.HSSF.UserModel;
using System.Diagnostics;

namespace PublicManager
{
    public static class ExcelHelper
    {
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sheetName"></param>
        public static void ExportToExcel(this DataTable data, string sheetName)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel(2007-2013)|*.xlsx";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            
            ExportToExcel(fileDialog.FileName, data, sheetName);
        }

        /// <summary>
        /// 写Excel文件
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="data"></param>
        /// <param name="sheetName"></param>
        public static void ExportToExcel(string excelFile, DataTable data, string sheetName)
        {
            try
            {
                data.TableName = sheetName;
                ExcelBuilder eb = new ExcelBuilder();
                eb.WorkBookObj = new XSSFWorkbook();
                eb.initStyles();
                eb.writeTheSheet(data);
                eb.saveWorkbookToFile(excelFile);

                MessageBox.Show("导出数据成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GC.Collect();

                Process.Start(excelFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出Excel失败！Ex:" + ex.ToString());
            }
        }

        /// <summary>
        /// 将Excel表格转换为DataSet
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="firstRowAsHeader"></param>
        /// <returns></returns>
        public static DataSet ExcelToDataSet(string fileName, bool firstRowAsHeader)
        {
            return ExcelBuilder.excelToDataSet(fileName, firstRowAsHeader);
        }

        /// <summary>
        /// 将Excel表格转换为DataSet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataSet ExcelToDataSet(string fileName)
        {
            return ExcelBuilder.excelToDataSet(fileName);
        }
        
        /// <summary>
        /// 获得日期值
        /// </summary>
        /// <param name="val"></param>
        /// <param name="formatString"></param>
        /// <param name="defaultString"></param>
        /// <returns></returns>
        public static string getDateTimeForString(DateTime val, string formatString, string defaultString)
        {
            if (val != null)
            {
                if (val <= DateTime.MinValue)
                {
                    return defaultString;
                }
                else
                {
                    return val.ToString(formatString);
                }
            }
            else
            {
                return defaultString;
            }
        }
    }
}