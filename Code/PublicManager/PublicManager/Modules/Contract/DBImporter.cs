using Noear.Weed;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.Modules.Contract
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
            DataItem diProject = localContext.table("JiBenXinXiBiao").select("*").getDataItem();
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
                Catalog catalog = updateAndClearCatalog(catalogNumber, diProject.getString("HeTongMingCheng"), "合同书", catalogVersionStr);
                #endregion

                #region 导入项目及课题信息
                //处理项目信息
                Project proj = new Project();
                proj.ProjectID = catalog.CatalogID;
                proj.CatalogID = catalog.CatalogID;
                proj.ProjectName = catalog.CatalogName;
                proj.SecretLevel = diProject.getString("HeTongMiJi");
                proj.TotalMoney = diProject.get("HeTongJiaKuan") != null ? decimal.Parse(diProject.get("HeTongJiaKuan").ToString()) : 0;

                //导入1.3版之后版本新添加的字段
                switch (catalogVersionStr)
                {
                    case "v1.1":
                        break;
                    case "v1.2":
                        break;
                    case "v1.3":
                        break;
                    case "v1.4":
                        proj.Keywords = diProject.getString("HeTongGuanJianZi");
                        proj.Domains = diProject.getString("HeTongSuoShuLingYu");
                        proj.DutyUnit = diProject.getString("HeTongFuZeDanWei");
                        proj.DutyUnitOrg = diProject.getString("HeTongSuoShuBuMen");
                        proj.DutyUnitAddress = diProject.getString("HeTongSuoShuDiDian");
                        break;
                }

                proj.copyTo(ConnectionManager.Context.table("Project")).insert();

                //处理课题列表
                DataList dlSubject = localContext.table("KeTiBiao").orderBy("ZhuangTai,ModifyTime").select("*").getDataList();
                foreach (DataItem di in dlSubject.getRows())
                {
                    Subject obj = new Subject();
                    obj.SubjectID = di.getString("BianHao");
                    obj.CatalogID = proj.CatalogID;
                    obj.ProjectID = proj.ProjectID;
                    obj.SubjectName = di.getString("KeTiMingCheng");
                    //obj.TotalMoney = di.get("") != null ? decimal.Parse(di.get("").ToString()) : 0;
                    obj.WorkDest = di.getString("KeTiYanJiuMuBiao");
                    obj.WorkContent = di.getString("KeTiYanJiuNeiRong");
                    obj.WorkTask = di.getString("KeTiCanJiaDanWeiFenGong");

                    //导入1.3版之后版本新添加的字段
                    switch (catalogVersionStr)
                    {
                        case "v1.1":
                            break;
                        case "v1.2":
                            break;
                        case "v1.3":
                            break;
                        case "v1.4":
                            obj.DutyUnit = diProject.getString("KeTiFuZeDanWei");
                            obj.DutyUnitOrg = diProject.getString("KeTiSuoShuBuMen");
                            obj.DutyUnitAddress = diProject.getString("KeTiSuoShuDiDian");
                            break;
                    }

                    obj.copyTo(ConnectionManager.Context.table("Subject")).insert();
                }
                #endregion

                #region 导入人员信息
                //处理人员信息
                DataList dlPerson = localContext.table("RenYuanBiao").select("*").getDataList();
                foreach (DataItem di in dlPerson.getRows())
                {
                    Person obj = new Person();
                    obj.PersonID = Guid.NewGuid().ToString();
                    obj.CatalogID = proj.CatalogID;
                    obj.ProjectID = proj.ProjectID;
                    obj.SubjectID = di.getString("KeTiBiaoHao");
                    obj.PersonName = di.getString("XingMing");
                    obj.PersonIDCard = di.getString("ShenFenZhengHao");
                    obj.PersonSex = di.getString("XingBie");
                    obj.PersonJob = di.getString("ZhiCheng");
                    obj.PersonSpecialty = di.getString("ZhuanYe");
                    obj.TotalTime = di.getInt("MeiNianTouRuShiJian");
                    obj.TaskContent = di.getString("RenWuFenGong");
                    obj.WorkUnit = di.getString("GongZuoDanWei");

                    //设置项目中职务
                    obj.JobInProject = di.getString("ZhiWu");

                    //是否为项目负责人
                    switch (di.getString("ShiXiangMuFuZeRen"))
                    {
                        case "rbIsOnlyProject":
                            obj.PersonID = Guid.NewGuid().ToString();
                            obj.SubjectID = string.Empty;
                            obj.IsProjectMaster = "true";
                            //插入数据
                            obj.copyTo(ConnectionManager.Context.table("Person")).insert();
                            break;
                        case "rbIsProjectAndSubject":
                            string oldSubjectID = obj.SubjectID;

                            //保存项目负责人
                            obj.PersonID = Guid.NewGuid().ToString();
                            obj.SubjectID = string.Empty;
                            obj.IsProjectMaster = "true";
                            //插入数据
                            obj.copyTo(ConnectionManager.Context.table("Person")).insert();

                            //保存课题负责人
                            obj.PersonID = Guid.NewGuid().ToString();
                            obj.SubjectID = oldSubjectID;
                            obj.IsProjectMaster = "false";
                            //插入数据
                            obj.copyTo(ConnectionManager.Context.table("Person")).insert();
                            break;
                        case "rbIsOnlySubject":
                            //保存课题负责人或成员
                            obj.PersonID = Guid.NewGuid().ToString();
                            obj.IsProjectMaster = "false";
                            //插入数据
                            obj.copyTo(ConnectionManager.Context.table("Person")).insert();
                            break;
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