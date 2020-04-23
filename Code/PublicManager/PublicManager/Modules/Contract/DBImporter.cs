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
            Dictionary<string, Subject> subjectDict = new Dictionary<string, Subject>();

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
                Catalog catalog = updateAndClearCatalog(catalogNumber, getValueWithDefault<string>(diProject.get("HeTongMingCheng"), string.Empty), "合同书", catalogVersionStr);
                #endregion

                #region 导入项目及课题信息
                //处理项目信息
                Project proj = new Project();
                proj.ProjectID = catalog.CatalogID;
                proj.CatalogID = catalog.CatalogID;
                proj.ProjectName = catalog.CatalogName;
                proj.SecretLevel = getValueWithDefault<string>(diProject.get("HeTongMiJi"), string.Empty);
                proj.TotalMoney = diProject.get("HeTongJiaKuan") != null ? decimal.Parse(diProject.get("HeTongJiaKuan").ToString()) : 0;
                proj.ProjectNumber = getValueWithDefault<string>(diProject.get("HeTongBianHao"), string.Empty);

                int totalYear = 0;
                try
                {
                    DateTime startTime = diProject.getDateTime("HeTongKaiShiShiJian");
                    DateTime endTime = diProject.getDateTime("HeTongJieShuShiJian");
                    totalYear = (endTime.Year + 1) - startTime.Year;
                }
                catch (Exception ex) { }
                proj.TotalTime = totalYear;
                proj.DutyNormalUnit = string.Empty;

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
                        proj.Keywords = getValueWithDefault<string>(diProject.get("HeTongGuanJianZi"), string.Empty);
                        proj.Domains = getValueWithDefault<string>(diProject.get("HeTongSuoShuLingYu"), string.Empty);
                        proj.DutyUnit = getValueWithDefault<string>(diProject.get("HeTongFuZeDanWei"), string.Empty);
                        proj.DutyUnitOrg = getValueWithDefault<string>(diProject.get("HeTongSuoShuBuMen"), string.Empty);
                        proj.DutyUnitAddress = getAddress(getValueWithDefault<string>(diProject.get("HeTongSuoShuDiDian"), string.Empty));
                        break;
                    case "v1.5":
                        proj.Keywords = getValueWithDefault<string>(diProject.get("HeTongGuanJianZi"), string.Empty);
                        proj.Domains = getValueWithDefault<string>(diProject.get("HeTongSuoShuLingYu"), string.Empty);
                        proj.DutyUnit = getValueWithDefault<string>(diProject.get("HeTongFuZeDanWei"), string.Empty);
                        proj.DutyUnitOrg = getValueWithDefault<string>(diProject.get("HeTongSuoShuBuMen"), string.Empty);
                        proj.DutyUnitAddress = getAddress(getValueWithDefault<string>(diProject.get("HeTongSuoShuDiDian"), string.Empty));

                        proj.DutyNormalUnit = getValueWithDefault<string>(diProject.get("HeTongFuZeDanWeiChangYongMingCheng"), string.Empty);
                        break;
                }

                proj.copyTo(ConnectionManager.Context.table("Project")).insert();

                //处理课题列表
                DataList dlSubject = localContext.table("KeTiBiao").orderBy("ZhuangTai,ModifyTime").select("*").getDataList();
                foreach (DataItem di in dlSubject.getRows())
                {
                    Subject obj = new Subject();
                    obj.SubjectID = getValueWithDefault<string>(di.get("BianHao"), string.Empty);
                    obj.CatalogID = proj.CatalogID;
                    obj.ProjectID = proj.ProjectID;
                    obj.SubjectName = getValueWithDefault<string>(di.get("KeTiMingCheng"), string.Empty);
                    //obj.TotalMoney = di.get("") != null ? decimal.Parse(di.get("").ToString()) : 0;
                    obj.WorkDest = getValueWithDefault<string>(di.get("KeTiYanJiuMuBiao"), string.Empty);
                    obj.WorkContent = getValueWithDefault<string>(di.get("KeTiYanJiuNeiRong"), string.Empty);
                    obj.WorkTask = getValueWithDefault<string>(di.get("KeTiCanJiaDanWeiFenGong"), string.Empty);
                    obj.SecretLevel = "公开";
                    obj.TotalMoney = 0;

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
                            obj.DutyUnit = getValueWithDefault<string>(di.get("KeTiFuZeDanWei"), string.Empty);
                            obj.DutyUnitOrg = getValueWithDefault<string>(di.get("KeTiSuoShuBuMen"), string.Empty);
                            obj.DutyUnitAddress = getAddress(getValueWithDefault<string>(di.get("KeTiSuoShuDiDian"), string.Empty));

                            //处理参加单位分工
                            StringBuilder sbWorkTask = new StringBuilder();
                            DataList items = localContext.table("RenWuBiao").where("KeTiBianHao='" + getValueWithDefault<string>(di.get("BianHao"), string.Empty) + "'").select("*").getDataList();
                            if (items.getRowCount() >= 1)
                            {
                                sbWorkTask.Append("该课题由").Append(getValueWithDefault<string>(items.getRow(0).get("DanWeiMing"), string.Empty)).Append("单位负责，承担").Append(getValueWithDefault<string>(items.getRow(0).get("RenWuFenGong"), string.Empty)).Append("等任务；").AppendLine();
                            }
                            for (int kk = 1; kk < items.getRowCount(); kk++)
                            {
                                DataItem rwb = items.getRow(kk);
                                sbWorkTask.Append(getValueWithDefault<string>(rwb.get("DanWeiMing"),string.Empty)).Append("单位参加，承担").Append(getValueWithDefault<string>(rwb.get("RenWuFenGong"), string.Empty)).Append("等任务；\n");
                            }
                            if (sbWorkTask.Length >= 1)
                            {
                                sbWorkTask.Remove(sbWorkTask.Length - 1, 1);
                            }
                            obj.WorkTask = sbWorkTask.ToString();
                            break;
                        case "v1.5":
                            obj.DutyUnit = getValueWithDefault<string>(di.get("KeTiFuZeDanWei"), string.Empty);
                            obj.DutyUnitOrg = getValueWithDefault<string>(di.get("KeTiSuoShuBuMen"), string.Empty);
                            obj.DutyUnitAddress = getAddress(getValueWithDefault<string>(di.get("KeTiSuoShuDiDian"), string.Empty));

                            //处理参加单位分工
                            sbWorkTask = new StringBuilder();
                            items = localContext.table("RenWuBiao").where("KeTiBianHao='" + getValueWithDefault<string>(di.get("BianHao"), string.Empty) + "'").select("*").getDataList();
                            if (items.getRowCount() >= 1)
                            {
                                sbWorkTask.Append("该课题由").Append(getValueWithDefault<string>(items.getRow(0).get("DanWeiMing"), string.Empty)).Append("单位负责，承担").Append(getValueWithDefault<string>(items.getRow(0).get("RenWuFenGong"), string.Empty)).Append("等任务；").AppendLine();
                            }
                            for (int kk = 1; kk < items.getRowCount(); kk++)
                            {
                                DataItem rwb = items.getRow(kk);
                                sbWorkTask.Append(getValueWithDefault<string>(rwb.get("DanWeiMing"),string.Empty)).Append("单位参加，承担").Append(getValueWithDefault<string>(rwb.get("RenWuFenGong"), string.Empty)).Append("等任务；\n");
                            }
                            if (sbWorkTask.Length >= 1)
                            {
                                sbWorkTask.Remove(sbWorkTask.Length - 1, 1);
                            }
                            obj.WorkTask = sbWorkTask.ToString();

                            obj.SecretLevel = getValueWithDefault<string>(di.get("KeTiBaoMiDengJi"), string.Empty);
                            break;
                    }

                    obj.copyTo(ConnectionManager.Context.table("Subject")).insert();

                    subjectDict[obj.SubjectID] = obj;
                }
                #endregion

                #region 导入人员信息
                //处理人员信息
                DataList dlPerson = localContext.table("RenYuanBiao").orderBy("ZhuangTai").select("*").getDataList();
                foreach (DataItem di in dlPerson.getRows())
                {
                    Person obj = new Person();
                    obj.PersonID = Guid.NewGuid().ToString();
                    obj.CatalogID = proj.CatalogID;
                    obj.ProjectID = proj.ProjectID;
                    obj.SubjectID = getValueWithDefault<string>(di.get("KeTiBiaoHao"), string.Empty);
                    obj.PersonName = getValueWithDefault<string>(di.get("XingMing"), string.Empty);
                    obj.PersonIDCard = getValueWithDefault<string>(di.get("ShenFenZhengHao"), string.Empty);
                    obj.PersonSex = getValueWithDefault<string>(di.get("XingBie"), string.Empty);
                    obj.PersonJob = getValueWithDefault<string>(di.get("ZhiCheng"), string.Empty);
                    obj.PersonSpecialty = getValueWithDefault<string>(di.get("ZhuanYe"), string.Empty);
                    obj.TotalTime = di.getInt("MeiNianTouRuShiJian");
                    obj.TaskContent = getValueWithDefault<string>(di.get("RenWuFenGong"), string.Empty);
                    obj.WorkUnit = getValueWithDefault<string>(di.get("GongZuoDanWei"), string.Empty);
                    obj.Telephone = di.exists("DianHua") ? getValueWithDefault<string>(di.get("DianHua"), string.Empty) : string.Empty;
                    obj.Mobilephone = di.exists("ShouJi") ? getValueWithDefault<string>(di.get("ShouJi"), string.Empty) : string.Empty;

                    //设置项目中职务
                    obj.JobInProject = getValueWithDefault<string>(di.get("ZhiWu"), string.Empty);

                    //是否为项目负责人
                    switch (getValueWithDefault<string>(di.get("ShiXiangMuFuZeRen"), string.Empty))
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

                #region 写入金额数据
                DataList dlMoneys = localContext.table("YuSuanBiao").select("*").getDataList();
                if (dlMoneys != null && dlMoneys.getRowCount() >= 1)
                {
                    foreach (DataItem di in dlMoneys.getRows())
                    {
                        //添加字典
                        addDict(catalog, proj, "Money,Info", (di.get("MingCheng") != null ? di.get("MingCheng").ToString() : string.Empty), (di.get("ShuJu") != null ? di.get("ShuJu").ToString() : string.Empty), string.Empty);
                    }
                }
                #endregion

                #region 写入研究进度安排
                DataList dlProgress = localContext.table("JinDuBiao").orderBy("ZhuangTai,ModifyTime").select("*").getDataList();
                foreach (DataItem diProgress in dlProgress.getRows())
                {
                    try
                    {
                        WorkSteps ws = new WorkSteps();
                        ws.WSID = Guid.NewGuid().ToString();
                        ws.CatalogID = catalog.CatalogID;
                        ws.ProjectID = proj.ProjectID;
                        ws.WorkTime = DateTime.Parse(diProgress.get("ShiJian") != null ? diProgress.get("ShiJian").ToString() : DateTime.MinValue.ToString());
                        ws.DestAndContent = diProgress.get("JieDuanMuBiao") != null ? diProgress.get("JieDuanMuBiao").ToString() : string.Empty;
                        ws.ResultMethod = diProgress.get("JieDuanChengGuo") != null ? diProgress.get("JieDuanChengGuo").ToString() : string.Empty;
                        ws.copyTo(ConnectionManager.Context.table("WorkSteps")).insert();
                    }
                    catch (Exception ex) { }
                }
                #endregion

                //节点字典(Key=名称,Value=记录ID)
                Dictionary<string, string> nodeDict = new Dictionary<string, string>();

                #region 写入拨付约定
                DataList dlRules = localContext.table("BoFuBiao").orderBy("ZhuangTai,ModifyTime").select("*").getDataList();
                foreach (DataItem diRule in dlRules.getRows())
                {
                    try
                    {
                        MoneySends ms = new MoneySends();
                        ms.MSID = diRule.get("BianHao") != null ? diRule.get("BianHao").ToString() : Guid.NewGuid().ToString();
                        ms.CatalogID = catalog.CatalogID;
                        ms.ProjectID = proj.ProjectID;
                        ms.NodeIndex = int.Parse(diRule.get("ZhuangTai") != null ? diRule.get("ZhuangTai").ToString() : "0");
                        ms.SendRule = diRule.get("BoFuTiaoJian") != null ? diRule.get("BoFuTiaoJian").ToString() : string.Empty;
                        ms.WillTime = DateTime.Parse(diRule.get("YuJiShiJian") != null ? diRule.get("YuJiShiJian").ToString() : DateTime.MinValue.ToString());
                        ms.TotalMoney = decimal.Parse(diRule.get("JingFeiJinQian") != null ? diRule.get("JingFeiJinQian").ToString() : "0");
                        ms.MemoText = diRule.get("BeiZhu") != null ? diRule.get("BeiZhu").ToString() : string.Empty;
                        ms.copyTo(ConnectionManager.Context.table("MoneySends")).insert();

                        if (string.IsNullOrEmpty(ms.SendRule))
                        {
                            continue;
                        }
                        else
                        {
                            nodeDict[ms.SendRule] = ms.MSID;
                        }
                    }
                    catch (Exception ex) { }
                }
                #endregion

                #region 写入课题节点经费
                DataList dlSubjectMoneys = localContext.table("KeTiJieDianJingFeiBiao").orderBy("ZhuangTai,ModifyTime").select("*").getDataList();
                foreach (DataItem di in dlSubjectMoneys.getRows())
                {
                    string oldSubjectId = di.get("KeTiBianHao") != null ? di.get("KeTiBianHao").ToString() : string.Empty;
                    string oldNodeId = di.get("BoFuBianHao") != null ? di.get("BoFuBianHao").ToString() : string.Empty;

                    string moduleName = "current";
                    string moduleValue = di.get("JingFei") != null ? di.get("JingFei").ToString() : string.Empty;

                    string oldSubjectName = localContext.table("KeTiBiao").where("BianHao='" + oldSubjectId + "'").select("KeTiMingCheng").getValue<string>(string.Empty);
                    string newSubjectID = ConnectionManager.Context.table("Subject").where("SubjectName='" + oldSubjectName + "'").select("SubjectID").getValue<string>(string.Empty);

                    string oldNodeName = localContext.table("BoFuBiao").where("BianHao='" + oldNodeId + "'").select("BoFuTiaoJian").getValue<string>(string.Empty);
                    string newNodeID = oldNodeId;
                    if (nodeDict.ContainsKey(oldNodeName))
                    {
                        newNodeID = nodeDict[oldNodeName];

                        SubjectMoneys obj = new SubjectMoneys();
                        obj.SMID = Guid.NewGuid().ToString();
                        obj.CatalogID = catalog.CatalogID;
                        obj.ProjectID = catalog.CatalogID;
                        obj.SubjectID = newSubjectID;
                        obj.NodeID = newNodeID;
                        obj.SMName = moduleName;
                        obj.SMValue = moduleValue;
                        obj.copyTo(ConnectionManager.Context.table("SubjectMoneys")).insert();

                        decimal nodeMoney = 0;
                        try
                        {
                            nodeMoney = decimal.Parse(obj.SMValue);
                        }
                        catch (Exception ex) { }
                        if (subjectDict.ContainsKey(obj.SubjectID))
                        {
                            subjectDict[obj.SubjectID].TotalMoney += nodeMoney;
                        }
                    }
                }
                #endregion

                #region 写入单位节点经费
                DataList dlUnitMoneys = localContext.table("DanWeiJieDianJingFeiBiao").orderBy("ZhuangTai,ModifyTime").select("*").getDataList();
                foreach (DataItem di in dlUnitMoneys.getRows())
                {
                    string unitName = di.get("DanWeiMingCheng") != null ? di.get("DanWeiMingCheng").ToString() : string.Empty;
                    string oldNodeId = di.get("BoFuBianHao") != null ? di.get("BoFuBianHao").ToString() : string.Empty;

                    string moduleName = "current";
                    string moduleValue = di.get("JingFei") != null ? di.get("JingFei").ToString() : string.Empty;

                    string oldNodeName = localContext.table("BoFuBiao").where("BianHao='" + oldNodeId + "'").select("BoFuTiaoJian").getValue<string>(string.Empty);
                    string newNodeID = oldNodeId;
                    if (nodeDict.ContainsKey(oldNodeName))
                    {
                        newNodeID = nodeDict[oldNodeName];

                        UnitMoneys obj = new UnitMoneys();
                        obj.UMID = Guid.NewGuid().ToString();
                        obj.CatalogID = catalog.CatalogID;
                        obj.ProjectID = catalog.CatalogID;
                        obj.NodeID = newNodeID;
                        obj.UnitName = unitName;
                        obj.UMName = moduleName;
                        obj.UMValue = moduleValue;
                        obj.copyTo(ConnectionManager.Context.table("UnitMoneys")).insert();
                    }
                }
                #endregion

                #region 更新课题总经费
                foreach (Subject subObj in subjectDict.Values)
                {
                    subObj.copyTo(ConnectionManager.Context.table("Subject").where("CatalogID = '" + subObj.CatalogID + "' and SubjectID = '" + subObj.SubjectID + "'")).update();
                }
                #endregion
                return catalog.CatalogID;
            }
            else
            {
                return string.Empty;
            }
        }

        private string getAddress(string temp)
        {
            string result = temp;
            if (temp != null && temp.Contains("%|||%"))
            {
                string[] tt = temp.Split(new string[] { "%|||%" }, StringSplitOptions.None);
                if (tt != null && tt.Length >= 3)
                {
                    if (!tt[1].Contains(tt[0]))
                    {
                        result = tt[0] + tt[1] + tt[2];
                    }
                    else
                    {
                        result = tt[1] + tt[2];
                    }
                }
            }
            return result;
        }
    }
}