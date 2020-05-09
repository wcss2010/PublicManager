using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.Modules
{
    public class DEGridViewCellMergeAdapterWithPT
    {
        private string primaryIdField = string.Empty;

        private DevExpress.XtraGrid.Views.Grid.GridView myGridView;
        private List<string> mergeFieldNameList = new List<string>();
        /// <summary>
        /// 要合并的单元格
        /// </summary>
        public List<string> MergeFieldNameList
        {
            get { return mergeFieldNameList; }
        }

        public DEGridViewCellMergeAdapterWithPT(DevExpress.XtraGrid.Views.Grid.GridView gv, string[] mergeColNames,string idField)
        {
            this.primaryIdField = idField;
            this.myGridView = gv;
            this.myGridView.OptionsView.AllowCellMerge = true;
            this.myGridView.CellMerge += myGridView_CellMerge;
            mergeFieldNameList.AddRange(mergeColNames);
        }

        void myGridView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (!mergeFieldNameList.Contains(e.Column.FieldName))
            {
                //不需要合并的单元格不合并
                e.Merge = false; //值相同的2个单元格是否要合并在一起
                e.Handled = true; //合并单元格是否已经处理过，无需再次进行省缺处理
            }
            else
            {
                //对需要合并的单元格进行检测
                if (string.IsNullOrEmpty(primaryIdField))
                {
                    //没有指定ID字段，按默认流程处理
                    e.Merge = false; //值相同的2个单元格是否要合并在一起
                    e.Handled = true; //合并单元格是否已经处理过，无需再次进行省缺处理
                }
                else
                {
                    //判断是否允许合并
                    object objValue1 = myGridView.GetRowCellValue(e.RowHandle1, primaryIdField);
                    object objValue2 = myGridView.GetRowCellValue(e.RowHandle2, primaryIdField);

                    if (objValue1 == objValue2)
                    {
                        //可以合并
                        return;
                    }
                    else
                    {
                        //不是一个项目，取消合并
                        e.Merge = false; //值相同的2个单元格是否要合并在一起
                        e.Handled = true; //合并单元格是否已经处理过，无需再次进行省缺处理
                    }
                }
            }
        }
    }
}