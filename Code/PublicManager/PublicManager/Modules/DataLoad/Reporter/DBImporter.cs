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
                Catalog catalog = updateAndClearCatalog(catalogNumber, getValueWithDefault<string>(diProject.get("Name"), string.Empty), "建议书", catalogVersionStr, false, string.Empty, System.IO.Path.GetDirectoryName(sourceFile));
                #endregion

                #region 导入项目及课题信息
                //添加项目信息
                Project proj = new Project();
                proj.ProjectID = catalog.CatalogID;
                proj.CatalogID = catalog.CatalogID;
                proj.ProjectName = catalog.CatalogName;
                proj.SecretLevel = getValueWithDefault<string>(diProject.get("SecretLevel"),string.Empty);
                proj.TotalMoney = diProject.get("TotalMoney") != null ? decimal.Parse(diProject.get("TotalMoney").ToString()) : 0;
                proj.Keywords = getValueWithDefault<string>(diProject.get("Keywords"),string.Empty);
                proj.Domains = getValueWithDefault<string>(diProject.get("Domain"),string.Empty);
                proj.DutyUnit = localContext.table("Unit").where("ID='" + diProject.get("UnitID") + "'").select("UnitName").getValue<string>("未知");
                proj.DutyNormalUnit = localContext.table("Unit").where("ID='" + diProject.get("UnitID") + "'").select("NormalName").getValue<string>("未知");
                //proj.DutyUnitOrg = "未知";
                proj.DutyUnitAddress = localContext.table("Unit").where("ID='" + diProject.get("UnitID") + "'").select("Address").getValue<string>("未知");
                proj.ProjectNumber = string.Empty;
                proj.TotalTime = diProject.getInt("TotalTime");
                proj.IsNeedHide = "0";
                proj.ProjectNumber = catalogNumber;
                proj.copyTo(ConnectionManager.Context.table("Project")).insert();
                
                //处理课题列表
                DataList dlSubject = localContext.table("Project").where("Type = '课题'").select("*").getDataList();
                foreach (DataItem di in dlSubject.getRows())
                {
                    Subject obj = new Subject();
                    obj.SubjectID = getValueWithDefault<string>(di.get("ID"),string.Empty);
                    obj.CatalogID = proj.CatalogID;
                    obj.ProjectID = proj.ProjectID;
                    obj.SubjectName = getValueWithDefault<string>(di.get("Name"),string.Empty);
                    obj.SecretLevel = getValueWithDefault<string>(di.get("SecretLevel"), string.Empty);

                    object objMoney = localContext.table("Task").where("Role='负责人' and Type = '课题' and ProjectID = '" + obj.SubjectID + "'").select("TotalMoney").getValue();
                    obj.TotalMoney = objMoney != null ? decimal.Parse(objMoney.ToString()) : 0;

                    obj.WorkDest = System.IO.Path.Combine(filesDir, "课题详细_" + obj.SubjectName + "_研究目标" + ".doc");
                    obj.WorkContent = System.IO.Path.Combine(filesDir, "课题详细_" + obj.SubjectName + "_研究内容" + ".doc");
                    obj.WorkTask = string.Empty;

                    obj.DutyUnit = localContext.table("Unit").where("ID='" + di.get("UnitID") + "'").select("UnitName").getValue<string>("未知");
                    //obj.DutyUnitOrg = "未知";
                    //obj.DutyUnitAddress = localContext.table("Unit").where("ID='" + di.get("UnitID") + "'").select("Address").getValue<string>("未知");

                    obj.copyTo(ConnectionManager.Context.table("Subject")).insert();
                }
                #endregion

                #region 判断是否需要隐藏建议书-proj.ProjectNumber
                //string contactNumber = proj.ProjectNumber;

                //Catalog catalogReporter = ConnectionManager.Context.table("Catalog").where("CatalogNumber like '%" + contactNumber + "%' and CatalogType = '合同书'").select("*").getItem<Catalog>(new Catalog());
                //if (!string.IsNullOrEmpty(catalogReporter.CatalogID))
                //{
                //    catalog.IsNeedHide = "1";
                //    catalog.copyTo(ConnectionManager.Context.table("Catalog").where("CatalogID='" + catalog.CatalogID + "'")).update();
                                        
                //    if (!string.IsNullOrEmpty(proj.ProjectID))
                //    {
                //        proj.IsNeedHide = "1";
                //        proj.copyTo(ConnectionManager.Context.table("Project").where("CatalogID='" + catalog.CatalogID + "'")).update();
                //    }
                //}
                #endregion

                #region 导入人员信息
                //处理人员信息
                DataList dlTask = localContext.table("Task").orderBy("DisplayOrder").select("*").getDataList();
                foreach (DataItem diTask in dlTask.getRows())
                {
                    DataItem diPerson = localContext.table("Person").where("ID = '" + diTask.get("PersonID") + "'").select("*").getDataItem();
                    if (diPerson != null && diPerson.count() >= 1)
                    {
                        Person obj = new Person();
                        obj.PersonID = Guid.NewGuid().ToString();
                        obj.CatalogID = proj.CatalogID;
                        obj.ProjectID = proj.ProjectID;
                        obj.SubjectID = getValueWithDefault<string>(diTask.get("ProjectID"),string.Empty);
                        obj.PersonName = getValueWithDefault<string>(diPerson.get("Name"),string.Empty);
                        obj.PersonIDCard = getValueWithDefault<string>(diPerson.get("IDCard"),string.Empty);
                        obj.PersonSex = getValueWithDefault<string>(diPerson.get("Sex"),string.Empty);
                        obj.PersonJob = getValueWithDefault<string>(diPerson.get("Job"),string.Empty);
                        obj.PersonSpecialty = getValueWithDefault<string>(diPerson.get("Specialty"),string.Empty);
                        obj.TotalTime = diTask.getInt("TotalTime");
                        obj.TaskContent = getValueWithDefault<string>(diTask.get("Content"),string.Empty);
                        obj.Telephone = getValueWithDefault<string>(diPerson.get("Telephone"),string.Empty);
                        obj.Mobilephone = getValueWithDefault<string>(diPerson.get("MobilePhone"),string.Empty);

                        DataItem diUnit = localContext.table("Unit").where("ID='" + diPerson.get("UnitID") + "'").select("*").getDataItem();
                        if (diUnit != null && diUnit.count() >= 1)
                        {
                            obj.WorkUnit = getValueWithDefault<string>(diUnit.get("UnitName"),string.Empty);
                        }
                        else
                        {
                            obj.WorkUnit = "未知";
                        }

                        //设置项目中职务
                        obj.JobInProject = getValueWithDefault<string>(diTask.get("Role"),string.Empty);

                        //是否为项目负责人
                        obj.IsProjectMaster = diTask.get("Type").ToString() == "项目" ? "true" : "false";

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

                #region 导入经费信息表
                DataList dlMoneys = localContext.table("MoneyAndYear").select("*").getDataList();
                if (dlMoneys != null && dlMoneys.getRowCount() >= 1)
                {
                    //关键字映射表
                    Dictionary<string, string> nameDicts = new Dictionary<string, string>();
                    nameDicts["ProjectRFA"] = "Money1";
                    nameDicts["ProjectRFA1"] = "Money2";
                    nameDicts["ProjectRFA1_1"] = "Money3";
                    nameDicts["ProjectRFA1_1_1"] = "Money3_1";
                    nameDicts["ProjectRFA1_1_2"] = "Money3_2";
                    nameDicts["ProjectRFA1_1_3"] = "Money3_3";
                    nameDicts["ProjectRFA1_2"] = "Money4";
                    nameDicts["ProjectRFA1_3"] = "Money5";
                    nameDicts["ProjectRFA1_3_1"] = "Money5_1";
                    nameDicts["ProjectRFA1_3_2"] = "Money5_2";
                    nameDicts["ProjectRFA1_4"] = "Money6";
                    nameDicts["ProjectRFA1_5"] = "Money7";
                    nameDicts["ProjectRFA1_6"] = "Money8";
                    nameDicts["ProjectRFA1_7"] = "Money9";
                    nameDicts["ProjectRFA1_8"] = "Money10";
                    nameDicts["ProjectRFA1_9"] = "Money11";
                    nameDicts["ProjectRFA2"] = "Money12";
                    nameDicts["ProjectRFA2_1"] = "Money12_1";
                    nameDicts["Projectoutlay1"] = "Year1";
                    nameDicts["Projectoutlay2"] = "Year2";
                    nameDicts["Projectoutlay3"] = "Year3";
                    nameDicts["Projectoutlay4"] = "Year4";
                    nameDicts["Projectoutlay5"] = "Year5";
                    nameDicts["ProjectRFArm"] = "Info1";
                    nameDicts["ProjectRFA1rm"] = "Info2";
                    nameDicts["ProjectRFA1_1rm"] = "Info3";
                    nameDicts["ProjectRFA1_1_1rm"] = "Info3_1";
                    nameDicts["ProjectRFA1_1_2rm"] = "Info3_2";
                    nameDicts["ProjectRFA1_1_3rm"] = "Info3_3";
                    nameDicts["ProjectRFA1_2rm"] = "Info4";
                    nameDicts["ProjectRFA1_3rm"] = "Info5";
                    nameDicts["ProjectRFA1_3_1rm"] = "Info5_1";
                    nameDicts["ProjectRFA1_3_2rm"] = "Info5_2";
                    nameDicts["ProjectRFA1_4rm"] = "Info6";
                    nameDicts["ProjectRFA1_5rm"] = "Info7";
                    nameDicts["ProjectRFA1_6rm"] = "Info8";
                    nameDicts["ProjectRFA1_7rm"] = "Info9";
                    nameDicts["ProjectRFA1_8rm"] = "Info10";
                    nameDicts["ProjectRFA1_9rm"] = "Info11";
                    nameDicts["ProjectRFA2rm"] = "Info12";
                    nameDicts["ProjectRFA2_1rm"] = "Info12_1";

                    foreach (DataItem di in dlMoneys.getRows())
                    {
                        //添加字典
                        addDict(catalog, proj, "Money,Info", nameDicts[getValueWithDefault<string>(di.get("Name"), string.Empty)], getValueWithDefault<string>(di.get("Value"), string.Empty), string.Empty);
                    }
                }
                #endregion

                #region 处理归一化单位列
                proj.DutyNormalUnit = getNormalNameWithDutyUnit(proj.DutyUnit);
                proj.copyTo(ConnectionManager.Context.table("Project")).where("ProjectID='" + proj.ProjectID + "'").update();

                List<Subject> subjectList22 = ConnectionManager.Context.table("Subject").where("ProjectID='" + proj.ProjectID + "'").select("*").getList<Subject>(new Subject());
                foreach (Subject sub22 in subjectList22)
                {
                    sub22.DutyNormalUnit = getNormalNameWithDutyUnit(sub22.DutyUnit);
                    sub22.copyTo(ConnectionManager.Context.table("Subject")).where("SubjectID='" + sub22.SubjectID + "'").update();
                }

                List<Person> personList22 = ConnectionManager.Context.table("Person").where("ProjectID='" + proj.ProjectID + "'").select("*").getList<Person>(new Person());
                foreach (Person per22 in personList22)
                {
                    per22.WorkNormalUnit = getNormalNameWithDutyUnit(per22.WorkUnit);
                    per22.copyTo(ConnectionManager.Context.table("Person")).where("PersonID='" + per22.PersonID + "'").update();
                }
                #endregion

                return catalog.CatalogID;
            }
            else
            {
                return string.Empty;
            }
        }

        private string getNormalNameWithDutyUnit(string dutyUnit)
        {
            object objValue = ConnectionManager.Context.table("NormalUnitDict").where("DutyUnit='" + dutyUnit + "'").select("DutyNormalUnit").getValue();
            if (objValue != null)
            {
                return objValue.ToString();
            }
            else
            {
                return "未匹配";
            }
        }
    }
}