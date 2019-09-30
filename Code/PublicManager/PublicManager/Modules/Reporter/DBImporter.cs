using Noear.Weed;
using PublicManager.DB;
using PublicManager.DB.Entitys;
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
            //数据库版本号
            string catalogVersionStr = "v1.1";

            //附件目录
            string filesDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(sourceFile), "Files");

            //处理项目信息
            DataItem diProject = localContext.table("Project").where("Type = '项目'").select("*").getDataItem();
            if (diProject != null && diProject.count() >= 1)
            {
                #region 读取版本号并更新Catalog信息
                //读取版本号
                try
                {
                    catalogVersionStr = localContext.table("Version").select("VersionNum").getValue<string>(catalogVersionStr);
                }
                catch (Exception ex) { }

                //更新Catalog
                Catalog catalog = updateAndClearCatalog(catalogNumber, diProject.getString("Name"), "建议书", catalogVersionStr);
                #endregion

                #region 导入项目及课题信息
                //添加项目信息
                Project proj = new Project();
                proj.ProjectID = catalog.CatalogID;
                proj.CatalogID = catalog.CatalogID;
                proj.ProjectName = catalog.CatalogName;
                proj.SecretLevel = diProject.getString("SecretLevel");
                proj.TotalMoney = diProject.get("TotalMoney") != null ? decimal.Parse(diProject.get("TotalMoney").ToString()) : 0;
                proj.copyTo(ConnectionManager.Context.table("Project")).insert();
                
                //处理课题列表
                DataList dlSubject = localContext.table("Project").where("Type = '课题'").select("*").getDataList();
                foreach (DataItem di in dlSubject.getRows())
                {
                    Subject obj = new Subject();
                    obj.SubjectID = di.getString("ID");
                    obj.CatalogID = proj.CatalogID;
                    obj.ProjectID = proj.ProjectID;
                    obj.SubjectName = di.getString("Name");

                    object objMoney = localContext.table("Task").where("Role='负责人' and Type = '课题' and ProjectID = '" + obj.SubjectID + "'").select("TotalMoney").getValue();
                    obj.TotalMoney = objMoney != null ? decimal.Parse(objMoney.ToString()) : 0;

                    obj.WorkDest = System.IO.Path.Combine(filesDir, "课题详细_" + obj.SubjectName + "_研究目标" + ".doc");
                    obj.WorkContent = System.IO.Path.Combine(filesDir, "课题详细_" + obj.SubjectName + "_研究内容" + ".doc");
                    obj.WorkTask = string.Empty;
                    obj.copyTo(ConnectionManager.Context.table("Subject")).insert();
                }
                #endregion

                #region 导入人员信息
                //处理人员信息
                DataList dlTask = localContext.table("Task").select("*").getDataList();
                foreach (DataItem diTask in dlTask.getRows())
                {
                    DataItem diPerson = localContext.table("Person").where("ID = '" + diTask.getString("PersonID") + "'").select("*").getDataItem();
                    if (diPerson != null && diPerson.count() >= 1)
                    {
                        Person obj = new Person();
                        obj.PersonID = Guid.NewGuid().ToString();
                        obj.CatalogID = proj.CatalogID;
                        obj.ProjectID = proj.ProjectID;
                        obj.SubjectID = diTask.getString("ProjectID");
                        obj.PersonName = diPerson.getString("Name");
                        obj.PersonIDCard = diPerson.getString("IDCard");
                        obj.PersonSex = diPerson.getString("Sex");
                        obj.PersonJob = diPerson.getString("Job");
                        obj.PersonSpecialty = diPerson.getString("Specialty");
                        obj.TotalTime = diTask.getInt("TotalTime");
                        obj.TaskContent = diTask.getString("Content");

                        DataItem diUnit = localContext.table("Unit").where("ID='" + diPerson.getString("UnitID") + "'").select("*").getDataItem();
                        if (diUnit != null && diUnit.count() >= 1)
                        {
                            obj.WorkUnit = diUnit.getString("UnitName");
                        }
                        else
                        {
                            obj.WorkUnit = "未知";
                        }

                        //设置项目中职务
                        obj.JobInProject = diTask.getString("Role");

                        //是否为项目负责人
                        obj.IsProjectMaster = diTask.getString("Type") == "项目" ? "true" : "false";

                        //如果是项目负责人就清空课题ID
                        if (obj.IsProjectMaster == "true")
                        {
                            obj.SubjectID = string.Empty;
                        }

                        //插入数据
                        obj.copyTo(ConnectionManager.Context.table("Person")).insert();
                    }
                }
                #endregion
                
                return catalog.CatalogID;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}