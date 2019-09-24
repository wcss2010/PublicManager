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
    }
}