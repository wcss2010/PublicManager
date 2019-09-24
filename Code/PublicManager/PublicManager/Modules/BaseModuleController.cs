using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace PublicManager.Modules
{
    /// <summary>
    /// 模块控制器
    /// </summary>
    public abstract partial class BaseModuleController : UserControl
    {
        public BaseModuleController()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获得用于显示在顶部工具栏的RibbonPage
        /// </summary>
        /// <returns></returns>
        public abstract RibbonPage[] GetTopBarPages();

        /// <summary>
        /// 设置/获得用于显示内容的控件
        /// </summary>
        public virtual ScrollableControl DisplayControl { get; set; }
    }
}