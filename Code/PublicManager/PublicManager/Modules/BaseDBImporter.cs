using PublicManager.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.Modules
{
    public abstract class BaseDBImporter
    {
        /// <summary>
        /// 根据CatalogID清空本地数据库(除了Catalog表)
        /// </summary>
        /// <param name="catalogID"></param>
        public void clearProjectDataWithCatalogID(string catalogID)
        {
            ConnectionManager.Context.table("Project").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("Subject").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("Person").where("CatalogID='" + catalogID + "'").delete();
        }

        /// <summary>
        /// 删除项目(索引+所有数据)
        /// </summary>
        /// <param name="catalogID"></param>
        public void deleteProject(string catalogID)
        {
            //删除其它表的数据
            clearProjectDataWithCatalogID(catalogID);

            //删除索引数据
            ConnectionManager.Context.table("Catalog").where("CatalogID='" + catalogID + "'").delete();
        }

        /// <summary>
        /// 添加或替换项目
        /// </summary>
        /// <param name="catalogNumber">catalogNumber</param>
        /// <param name="sourceFile">源文件</param>
        /// <returns>CatalogID</returns>
        public string addOrReplaceProject(string catalogNumber, string sourceFile)
        {
            //SQLite数据库工厂
            System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();

            //NDEY数据库连接
            Noear.Weed.DbContext context = new Noear.Weed.DbContext("main", "Data Source = " + sourceFile, factory);
            //是否在执入后执行查询（主要针对Sqlite）
            context.IsSupportInsertAfterSelectIdentity = false;
            //是否在Dispose后执行GC用于解决Dispose后无法删除的问题（主要针对Sqlite）
            context.IsSupportGCAfterDispose = true;

            try
            {
                return importDB(catalogNumber, sourceFile, context);
            }
            finally
            {
                factory.Dispose();
                context.Dispose();
            }
        }

        /// <summary>
        /// 导入数据库
        /// </summary>
        /// <param name="catalogNumber"></param>
        /// <param name="sourceFile"></param>
        /// <param name="localContext"></param>
        /// <returns>CatalogID</returns>
        protected abstract string importDB(string catalogNumber, string sourceFile, Noear.Weed.DbContext localContext);
    }
}