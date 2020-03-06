using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB.Entitys;

namespace PublicManager.Modules.Lines.MoneyRequest
{
    public partial class MoneyTableControl : UserControl
    {
        Dictionary<string, TextBox> boxDict = new Dictionary<string, TextBox>();
        /// <summary>
        /// 输入框字典
        /// </summary>
        public Dictionary<string, TextBox> BoxDict
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
                if (c is TextBox)
                {
                    boxDict[c.Name] = (TextBox)c;
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
}