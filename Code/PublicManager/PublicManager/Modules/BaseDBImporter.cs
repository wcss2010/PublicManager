using PublicManager.DB;
using PublicManager.DB.Entitys;
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
            ConnectionManager.Context.table("Dicts").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("WorkSteps").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("MoneySends").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("SubjectMoneys").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("UnitMoneys").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("Contact_Table1").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("Contact_Table2").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("Contact_Table3").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("Contact_Table4").where("CatalogID='" + catalogID + "'").delete();
            ConnectionManager.Context.table("Contact_Table5").where("CatalogID='" + catalogID + "'").delete();
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
            context.IsSupportSelectIdentityAfterInsert = false;
            //是否在Dispose后执行GC用于解决Dispose后无法删除的问题（主要针对Sqlite）
            context.IsSupportGCAfterDispose = true;

            try
            {
                return importDB(catalogNumber, sourceFile, context);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return string.Empty;
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

        /// <summary>
        /// 更新并且清理Catalog
        /// </summary>
        /// <param name="catalogNumber"></param>
        /// <param name="catalogName"></param>
        /// <param name="catalogType"></param>
        /// <param name="catalogVersion"></param>
        /// <returns></returns>
        protected Catalog updateAndClearCatalog(string catalogNumber, string catalogName, string catalogType, string catalogVersion, bool isHide)
        {
            //删除旧的Catalog
            string catalogID = ConnectionManager.Context.table("Catalog").where("CatalogNumber='" + catalogNumber + "' and CatalogType = '" + catalogType + "'").select("CatalogID").getValue<string>(string.Empty);
            if (!string.IsNullOrEmpty(catalogID))
            {
                deleteProject(catalogID);
            }

            //添加Catalog
            Catalog catalog = new Catalog();
            catalog.CatalogID = Guid.NewGuid().ToString();
            catalog.CatalogNumber = catalogNumber;
            catalog.CatalogName = catalogName;
            catalog.CatalogType = catalogType;
            catalog.CatalogVersion = catalogVersion;
            catalog.IsNeedHide = isHide ? "1" : "0";
            catalog.copyTo(ConnectionManager.Context.table("Catalog")).insert();

            return catalog;
        }

        /// <summary>
        /// 添加字典数据
        /// </summary>
        /// <param name="catalog"></param>
        /// <param name="project"></param>
        /// <param name="subject"></param>
        /// <param name="dType"></param>
        /// <param name="dName"></param>
        /// <param name="dValue"></param>
        /// <param name="parentID"></param>
        protected virtual void addDict(Catalog catalog, Project project, Subject subject,string dType, string dName, string dValue, string parentID)
        {
            //删除相同的项目
            ConnectionManager.Context.table("Dicts").where("ParentDictID = '" + parentID + "'" + (catalog != null ? (" and CatalogID = '" + catalog.CatalogID + "'") : string.Empty) + (project != null ? (" and ProjectID = '" + project.ProjectID + "'") : string.Empty) + (subject != null ? (" and SubjectID = '" + subject.SubjectID + "'") : string.Empty) + " and DictType = '" + dType + "' and DictName = '" + dName + "'").delete();

            Dicts dict = new Dicts();
            dict.DictID = Guid.NewGuid().ToString();
            if (catalog != null)
            {
                dict.CatalogID = catalog.CatalogID;
            }

            if (project != null)
            {
                dict.ProjectID = project.ProjectID;
            }

            if (subject != null)
            {
                dict.SubjectID = subject.SubjectID;
            }

            dict.DictType = dType;
            dict.DictName = dName;
            dict.DictValue = dValue;
            dict.ParentDictID = parentID;
            dict.copyTo(ConnectionManager.Context.table("Dicts")).insert();
        }

        /// <summary>
        /// 添加字典数据
        /// </summary>
        /// <param name="catalog"></param>
        /// <param name="project"></param>
        /// <param name="dType"></param>
        /// <param name="dName"></param>
        /// <param name="dValue"></param>
        /// <param name="parentID"></param>
        protected virtual void addDict(Catalog catalog, Project project, string dType, string dName, string dValue, string parentID)
        {
            addDict(catalog, project, null, dType, dName, dValue, parentID);
        }

        /// <summary>
        /// 执行一条SQL
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected virtual Noear.Weed.DbQuery newSql(Noear.Weed.DbContext context,string sql)
        {
            Noear.Weed.DbQuery query = context.sql(sql, new object[] { });
            return query.onCommandBuilt((cmd) =>
            {
                cmd.tag = "table" + DateTime.Now.Ticks;
                cmd.isLog = true;
            });            
        }

        /// <summary>
        /// 如果值为空，则使用初始值
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultString"></param>
        /// <returns></returns>
        protected virtual T getValueWithDefault<T>(object val, T defaultVal) 
        {
            return val != null ? (T)Convert.ChangeType(val.ToString(), typeof(T)) : defaultVal;
        }
    }
}