using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PublicManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //初始化数据库
            PublicManager.DB.ConnectionManager.Open("main", "Data Source=" + System.IO.Path.Combine(Application.StartupPath, "static.db"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}