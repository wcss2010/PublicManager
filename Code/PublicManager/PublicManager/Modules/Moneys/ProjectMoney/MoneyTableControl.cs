using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB.Entitys;

namespace PublicManager.Modules.Moneys.ProjectMoney
{
    public partial class MoneyTableControl : UserControl
    {
        Dictionary<string, MoneyLabel> boxDict = new Dictionary<string, MoneyLabel>();
        /// <summary>
        /// 输入框字典
        /// </summary>
        public Dictionary<string, MoneyLabel> BoxDict
        {
            get { return boxDict; }
        }

        public MoneyTableControl()
        {
            InitializeComponent();

            //查找所有的TextBox
            GetAllTextBoxObject(this);
        }

        /// <summary>
        /// 遍历所有的TextBox
        /// </summary>
        /// <param name="parent"></param>
        private void GetAllTextBoxObject(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is MoneyLabel)
                {
                    boxDict[c.Name] = (MoneyLabel)c;
                }
                else
                {
                    GetAllTextBoxObject(c);
                }
            }
        }

        private void ibEditMoney1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 载入经费数据
        /// </summary>
        /// <param name="moneys"></param>
        public void loadMoneys(List<Dicts> moneys)
        {
            foreach (Dicts ysb in moneys)
            {
                string ctrlName = "ibEdit" + ysb.DictName;
                if (boxDict.ContainsKey(ctrlName))
                {
                    boxDict[ctrlName].Text = ysb.DictValue;
                }
            }
        }

        /// <summary>
        /// 获得经费数据
        /// </summary>
        /// <returns></returns>
        public List<Dicts> getMoneys()
        {
            List<Dicts> results = new List<Dicts>();

            //foreach (KeyValuePair<string, TextBox> kvp in boxDict)
            //{
            //    Dicts ysb = new Dicts();
            //    ysb.DictID = Guid.NewGuid().ToString();
            //    ysb.DictName = kvp.Key.Replace("ibEdit", string.Empty);
            //    ysb.DictValue = kvp.Value.Text.Trim();
            //    results.Add(ysb);
            //}

            return results;
        }
    }

    public class MoneyLabel : Label
    {
        public MoneyLabel() : base()
        {
            AutoSize = false;
        }

        public bool Multiline { get; set; }

        public bool ReadOnly { get; set; }
    }
}