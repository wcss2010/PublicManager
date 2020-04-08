using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PublicManager.Modules
{
    public delegate void SearchClickDelegate(object sender,EventArgs args);
    public delegate void ResetClickDelegate(object sender, EventArgs args);
    public delegate void ExportToClickDelegate(object sender, EventArgs args);

    public partial class SearchRulePanel : XtraUserControl
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
        public Label Key1Label { get { return lblKey1; } }

        /// <summary>
        /// 搜索条件1内容
        /// </summary>
        public TextEdit Key1EditControl { get { return txtKey1; } }

        /// <summary>
        /// 搜索条件2标签
        /// </summary>
        public Label Key2Label { get { return lblKey2; } }

        /// <summary>
        /// 搜索条件2内容
        /// </summary>
        public System.Windows.Forms.ComboBox Key2EditControl { get { return txtKey2; } }

        public event SearchClickDelegate OnSearchClick;
        public event ResetClickDelegate OnResetClick;
        public event ExportToClickDelegate OnExportToClick;

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
                        CheckEdit ce = new CheckEdit();
                        ce.Name = ss;
                        ce.Checked = true;
                        fplCheckList.Controls.Add(ce);
                    }

                    Key1EditControl.Properties.NullValuePrompt = "请输入" + value.Replace(";", "或") + "！";
                }
            }
        }

        /// <summary>
        /// 是否显示合同书建议书切换面板
        /// </summary>
        public bool IsShowCatalogTypePanel
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

        public SearchRulePanel()
        {
            InitializeComponent();
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
                if (c is CheckEdit)
                {
                    CheckEdit ce = (CheckEdit)c;
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
                if (c is CheckEdit)
                {
                    CheckEdit ce = (CheckEdit)c;
                    ce.Checked = true;
                }
            }
            Key1EditControl.Text = string.Empty;
            if (Key2EditControl.Items.Count >= 1)
            {
                Key2EditControl.SelectedIndex = 0;
            }

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
        public void switchCatalogType(bool isContract, bool isReporter)
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
    }
}