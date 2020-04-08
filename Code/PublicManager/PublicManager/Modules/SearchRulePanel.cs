﻿using System;
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

        private bool isDisplayTimePanel = false;
        /// <summary>
        /// 是否显示最下面时间那一行
        /// </summary>
        public bool IsDisplayDateTimePanel
        {
            get { return isDisplayTimePanel; }
            set
            {
                isDisplayTimePanel = value;

                if (value)
                {
                    plTimePanel.Visible = value;
                    tplControls.RowStyles[tplControls.RowStyles.Count - 1].Height = 33.33f;
                }
                else
                {
                    tplControls.RowStyles[tplControls.RowStyles.Count - 1].Height = 0f;
                }
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

        private bool isDisplayKey2 = false;
        /// <summary>
        /// 是否显示搜索条件2内容
        /// </summary>
        public bool IsDisplayKey2
        {
            get { return isDisplayKey2; }
            set
            {
                isDisplayKey2 = value;

                Key2Label.Visible = value;
                Key2EditControl.Visible = value;
            }
        }

        private bool isDisplayKey3 = false;
        /// <summary>
        /// 是否显示搜索条件3内容
        /// </summary>
        public bool IsDisplayKey3
        {
            get { return isDisplayKey3; }
            set
            {
                isDisplayKey3 = value;
                
                Key3Label.Visible = value;
                Key3EditControl.Visible = value;
            }
        }

        private bool isDisplayKey4 = false;
        /// 是否显示搜索条件4内容
        public bool IsDisplayKey4
        {
            get { return isDisplayKey4; }
            set
            {
                isDisplayKey4 = value;

                Key4Label.Visible = value;
                Key4EditControl.Visible = value;
            }
        }

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
                        ce.Text = ss;
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

        public int CheckListPanelWidth
        {
            get
            {
                return fplCheckList.Width;
            }
            set
            {
                fplCheckList.Width = value;
            }
        }

        /// <summary>
        /// 搜索关键字条件是否可编辑
        /// </summary>
        public bool IsEnabledCheckListPanel
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
    }
}