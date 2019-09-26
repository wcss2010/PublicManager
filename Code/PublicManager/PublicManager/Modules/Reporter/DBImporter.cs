using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.Modules.Reporter
{
    public class DBImporter : BaseDBImporter
    {
        /// <summary>
        /// 导入数据库
        /// </summary>
        /// <param name="catalogNumber"></param>
        /// <param name="sourceFile"></param>
        /// <param name="localContext"></param>
        /// <returns></returns>
        protected override string importDB(string catalogNumber, string sourceFile, Noear.Weed.DbContext localContext)
        {
            //处理项目信息

            //处理课题列表

            //处理人员信息

            return null;
        }
    }
}