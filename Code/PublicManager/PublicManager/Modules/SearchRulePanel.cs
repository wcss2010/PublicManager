using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace PublicManager.Modules
{
    public delegate void SearchClickDelegate(object sender,EventArgs args);
    public delegate void ResetClickDelegate(object sender, EventArgs args);
    public delegate void ExportToClickDelegate(object sender, EventArgs args);
    public delegate void CustomButtonClickDelegate(object sender,CustomButtonEventArgs args);

    public class CustomButtonEventArgs : EventArgs
    {
        public string ButtonName { get; set; }
    }

    public partial class SearchRulePanel : UserControl
    {
        private string strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
        /// <summary>
        /// 目录表过滤条件
        /// </summary>
        public string CatalogIDFilterString
        {
            get { return strCatalogIDFilterString; }
        }

        /// <summary>
        /// 搜索条件1标签
        /// </summary>
        [Browsable(false)]
        public Label Key1Label { get { return lblKey1; } }

        /// <summary>
        /// 搜索条件1内容
        /// </summary>
        [Browsable(false)]
        public TextEdit Key1EditControl { get { return txtKey1; } }

        /// <summary>
        /// 搜索条件2标签
        /// </summary>
        [Browsable(false)]
        public CheckBox Key2Label { get { return lblKey2; } }

        /// <summary>
        /// 搜索条件2内容
        /// </summary>
        [Browsable(false)]
        public System.Windows.Forms.ComboBox Key2EditControl { get { return txtKey2; } }

        /// <summary>
        /// 搜索条件3标签
        /// </summary>
        [Browsable(false)]
        public CheckBox Key3Label { get { return lblKey3; } }

        /// <summary>
        /// 搜索条件3内容
        /// </summary>
        [Browsable(false)]
        public System.Windows.Forms.DateTimePicker Key3EditControl { get { return txtKey3; } }

        /// <summary>
        /// 搜索条件4标签
        /// </summary>
        [Browsable(false)]
        public CheckBox Key4Label { get { return lblKey4; } }

        /// <summary>
        /// 搜索条件4内容
        /// </summary>
        [Browsable(false)]
        public System.Windows.Forms.DateTimePicker Key4EditControl { get { return txtKey4; } }

        /// <summary>
        /// 是否显示Key3或Key4的面板
        /// </summary>
        public bool IsDisplayKey3OR4Panel
        {
            get { return plKey3And4Panel.Visible; }
            set
            {
                plKey3And4Panel.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示Key2的面板
        /// </summary>
        public bool IsDisplayKey2Panel
        {
            get { return plKey2Panel.Visible; }
            set
            {
                plKey2Panel.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示Key1的面板
        /// </summary>
        public bool IsDisplayKey1Panel
        {
            get { return plKey1Panel.Visible; }
            set
            {
                plKey1Panel.Visible = value;
            }
        }

        /// <summary>
        /// 显示合同书数据
        /// </summary>
        public bool IsDisplayContractData
        {
            get
            {
                return cbDisplayContract.Checked;
            }
            set
            {
                cbDisplayContract.Checked = value;
            }
        }

        /// <summary>
        /// 显示建议书数据
        /// </summary>
        public bool IsDisplayReporterData
        {
            get
            {
                return cbDisplayReporter.Checked;
            }
            set
            {
                cbDisplayReporter.Checked = value;
            }
        }

        /// <summary>
        /// 是否显示Key3的面板
        /// </summary>
        public bool IsDisplayKey3Panel
        {
            get { return plKey3Panel.Visible; }
            set
            {
                plKey3Panel.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示Key4的面板
        /// </summary>
        public bool IsDisplayKey4Panel
        {
            get { return plKey4Panel.Visible; }
            set
            {
                plKey4Panel.Visible = value;
            }
        }

        /// <summary>
        /// 显示自定义按钮对话框
        /// </summary>
        public bool IsDisplayCustomButtonPanel
        {
            get
            {
                return fplCustomButtons.Visible;
            }
            set
            {
                fplCustomButtons.Visible = value;
            }
        }

        private string customButtonsNames = string.Empty;
        /// <summary>
        /// 自定义按钮列表，用";"分割
        /// </summary>
        public string CustomButtonsNames
        {
            get { return customButtonsNames; }
            set
            {
                customButtonsNames = value;

                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                else
                {
                    fplCustomButtons.Controls.Clear();
                    string[] teams = value.Split(new string[] { ";" }, StringSplitOptions.None);
                    foreach (string ss in teams)
                    {
                        SimpleButton bb = new SimpleButton();
                        bb.Name = ss;
                        bb.Text = ss;
                        bb.AutoSize = true;
                        bb.Click += bb_Click;

                        fplCustomButtons.Controls.Add(bb);
                    }
                }
            }
        }

        void bb_Click(object sender, EventArgs e)
        {
            SimpleButton buttonObj = (SimpleButton)sender;

            processCustomButton(buttonObj);

            if (OnCustomButtonClick != null)
            {
                CustomButtonEventArgs args = new CustomButtonEventArgs();
                args.ButtonName = buttonObj.Name;

                OnCustomButtonClick(this, args);
            }
        }

        public event SearchClickDelegate OnSearchClick;
        public event ResetClickDelegate OnResetClick;
        public event ExportToClickDelegate OnExportToClick;
        public event CustomButtonClickDelegate OnCustomButtonClick;

        private string key1FieldString = string.Empty;
        /// <summary>
        /// 搜索条件1的可搜索字段，用";"分割
        /// </summary>
        public string Key1FieldString
        {
            get { return key1FieldString; }
            set
            {
                key1FieldString = value;

                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                else
                {
                    fplCheckList.Controls.Clear();
                    string[] teams = value.Split(new string[] { ";" }, StringSplitOptions.None);
                    foreach (string ss in teams)
                    {
                        CheckBox ce = new CheckBox();
                        ce.Name = ss;
                        ce.Text = ss;
                        ce.AutoSize = true;
                        ce.Checked = true;
                        fplCheckList.Controls.Add(ce);
                    }

                    Key1EditControl.Properties.NullValuePrompt = "请输入" + value.Replace(";", "、") + "的关键字！";
                }
            }
        }

        /// <summary>
        /// 是否显示合同书建议书切换面板
        /// </summary>
        public bool IsDisplayCatalogTypePanel
        {
            get
            {
                return plCatalogType.Visible;
            }
            set
            {
                plCatalogType.Visible = value;
            }
        }

        /// <summary>
        /// 搜索关键字条件是否可编辑
        /// </summary>
        public bool IsDisplayCheckListPanel
        {
            get
            {
                return fplCheckList.Visible;
            }
            set
            {
                fplCheckList.Visible = value;
            }
        }

        public GridControl DisplayGridControl { get; set; }

        public SearchRulePanel()
        {
            InitializeComponent();

            CustomButtonsNames = "结果内容搜索";
        }

        /// <summary>
        /// 获得当前选择的条件
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> getRuleCheckedDict()
        {
            Dictionary<string, bool> results = new Dictionary<string, bool>();
            foreach (Control c in fplCheckList.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ce = (CheckBox)c;
                    if (string.IsNullOrEmpty(ce.Name))
                    {
                        continue;
                    }
                    else
                    {
                        results[ce.Name.Trim()] = ce.Checked;
                    }
                }
            }
            return results;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (OnSearchClick != null)
            {
                OnSearchClick(this, new EventArgs());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control c in fplCheckList.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ce = (CheckBox)c;
                    ce.Checked = true;
                }
            }
            Key1EditControl.Text = string.Empty;
            if (Key2EditControl.Items.Count >= 1)
            {
                Key2EditControl.SelectedIndex = 0;
            }
            Key3Label.Checked = false;
            Key4Label.Checked = false;
            Key3EditControl.Value = DateTime.Now;
            Key4EditControl.Value = DateTime.Now;

            if (OnResetClick != null)
            {
                OnResetClick(this, new EventArgs());
            }
        }

        private void btnExportTo_Click(object sender, EventArgs e)
        {
            if (OnExportToClick != null)
            {
                OnExportToClick(this, new EventArgs());
            }
        }

        private void cbDisplayContract_CheckedChanged(object sender, EventArgs e)
        {
            switchCatalogType(cbDisplayContract.Checked, cbDisplayReporter.Checked);
        }

        /// <summary>
        /// 切换目录类型
        /// </summary>
        /// <param name="isContract"></param>
        /// <param name="isReporter"></param>
        protected void switchCatalogType(bool isContract, bool isReporter)
        {
            if (isContract && isReporter)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
            }
            else if (isContract)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog where CatalogType = '合同书')";
            }
            else if (isReporter)
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog where CatalogType = '建议书')";
            }
            else
            {
                strCatalogIDFilterString = " and CatalogID in (select CatalogID from Catalog)";
            }
        }

        private void txtKey1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        public void search()
        {
            btnSearch.PerformClick();
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void reset()
        {
            btnReset.PerformClick();
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void exportTo()
        {
            btnExportTo.PerformClick();
        }

        /// <summary>
        /// 判断指定名字的选项是否有在使用
        /// </summary>
        /// <param name="ruleNameKey"></param>
        /// <returns></returns>
        public bool isUsingRule(string ruleNameKey)
        {
            Dictionary<string, bool> boolDict = getRuleCheckedDict();

            bool result = false;
            foreach (KeyValuePair<string, bool> kvp in boolDict)
            {
                if (kvp.Key != null && kvp.Key.Contains(ruleNameKey) && kvp.Value)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 获得搜索条件勾选数量
        /// </summary>
        /// <returns></returns>
        public int getUsingRuleCount()
        {
            Dictionary<string, bool> boolDict = getRuleCheckedDict();

            int trueCount = 0;
            foreach (KeyValuePair<string, bool> kvp in boolDict)
            {
                if (kvp.Value)
                {
                    trueCount++;
                }
            }
            return trueCount;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            #region 设置宽度
            if (IsDisplayKey1Panel && IsDisplayKey2Panel && IsDisplayKey3OR4Panel)
            {
                plKey1Panel.Width = plInputPanel.Width / 3;
                plKey2Panel.Width = plInputPanel.Width / 3;
                plKey3And4Panel.Width = plInputPanel.Width / 3;
            }
            else if (IsDisplayKey1Panel && IsDisplayKey2Panel)
            {
                plKey1Panel.Width = (plInputPanel.Width / 3) * 2;
                plKey2Panel.Width = plInputPanel.Width - plKey1Panel.Width;
            }
            else if (IsDisplayKey1Panel && IsDisplayKey3OR4Panel)
            {
                plKey1Panel.Width = plInputPanel.Width / 3;
                plKey3And4Panel.Width = plInputPanel.Width - plKey1Panel.Width;
            }
            else if (IsDisplayKey2Panel && IsDisplayKey3OR4Panel)
            {
                plKey2Panel.Width = plInputPanel.Width / 2;
                plKey3And4Panel.Width = plInputPanel.Width / 2;
            }
            else
            {
                plKey1Panel.Width = plInputPanel.Width - 5;
            }
            #endregion
        }

        protected void processCustomButton(SimpleButton buttonObj)
        {
            if (buttonObj.Text == "结果内容搜索")
            {
                if (DisplayGridControl != null)
                {
                    if (DisplayGridControl.MainView is DevExpress.XtraGrid.Views.Grid.GridView)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)DisplayGridControl.MainView;
                        gv.OptionsFind.AllowFindPanel = false;
                        gv.OptionsFind.ClearFindOnClose = true;
                        gv.OptionsFind.FindNullPrompt = "请输入要搜索的关键字！";
                        gv.ShowFindPanel();
                    }
                }
            }
        }
    }
}