using Noear.Weed;
using PublicManager.DB;
using PublicManager.DB.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicManager.Modules
{
    /// <summary>
    /// 和SearchRulePanel控件一起使用，用于根据搜索条件生成SQL的Where条件
    /// </summary>
    public class MakeSQLWithSearchRule
    {
        /// <summary>
        /// 用于记录子表的相关数据ID,用于筛选(Value=表名++Guid(数据ID))
        /// </summary>
        public static List<string> includeSubTableIdList = new List<string>();

        /// <summary>
        /// 获得项目信息列表
        /// </summary>
        /// <param name="srp"></param>
        /// <returns></returns>
        public static List<Project> getProjectList(SearchRulePanel srp)
        {
            //初始化缓存
            includeSubTableIdList = new List<string>();

            //获得搜索选择条件
            Dictionary<string,bool> ruleDict = srp.getRuleCheckedDict();

            //生成的查询条件
            string whereString = string.Empty;

            if (string.IsNullOrEmpty(srp.Key1EditControl.Text))
            {
                whereString = "(1=1)";
            }
            else
            {
                #region 生成关键字条件
                StringBuilder sb = new StringBuilder();

                sb.Append("(");
                foreach (KeyValuePair<string, bool> kvp in ruleDict)
                {
                    if (kvp.Value)
                    {
                        switch (kvp.Key)
                        {
                            case "项目名称":
                                sb.Append(" or ").Append("ProjectName like '%" + srp.Key1EditControl.Text + "%'");
                                break;
                            case "计划批次":
                                sb.Append(" or ").Append("TaskNumber like '%" + srp.Key1EditControl.Text + "%'");
                                break;
                            case "项目关键词":
                                sb.Append(" or ").Append("Keywords like '%" + srp.Key1EditControl.Text + "%'");
                                break;
                            case "项目牵头单位":
                                sb.Append(" or ").Append("DutyUnit like '%" + srp.Key1EditControl.Text + "%'");
                                break;
                            case "项目所属地点":
                                sb.Append(" or ").Append("DutyUnitAddress like '%" + srp.Key1EditControl.Text + "%'");
                                break;
                            case "项目归一化单位":
                                sb.Append(" or ").Append("DutyNormalUnit like '%" + srp.Key1EditControl.Text + "%'");
                                break;
                            case "课题名称":
                                sb.Append(" or ").Append("ProjectID in (select ProjectID from Subject where SubjectName like '%" + srp.Key1EditControl.Text + "%')");
                                getDataIdList("Subject", "SubjectName like '%" + srp.Key1EditControl.Text + "%'", "SubjectID");
                                break;
                            case "课题负责单位":
                                sb.Append(" or ").Append("ProjectID in (select ProjectID from Subject where DutyUnit like '%" + srp.Key1EditControl.Text + "%')");
                                getDataIdList("Subject", "DutyUnit like '%" + srp.Key1EditControl.Text + "%'", "SubjectID");
                                break;
                            case "课题所属地点":
                                sb.Append(" or ").Append("ProjectID in (select ProjectID from Subject where DutyUnitAddress like '%" + srp.Key1EditControl.Text + "%')");
                                getDataIdList("Subject", "DutyUnitAddress like '%" + srp.Key1EditControl.Text + "%'", "SubjectID");
                                break;
                            case "人员名称":
                                sb.Append(" or ").Append("ProjectID in (select ProjectID from Person where PersonName like '%" + srp.Key1EditControl.Text + "%')");
                                getDataIdList("Person", "PersonName like '%" + srp.Key1EditControl.Text + "%'", "PersonID");
                                getDataIdList("Subject", "SubjectID in (select SubjectID from Person where " + ("PersonName like '%" + srp.Key1EditControl.Text + "%'") + ")", "SubjectID");
                                break;
                            case "人员专业":
                                sb.Append(" or ").Append("ProjectID in (select ProjectID from Person where PersonSpecialty like '%" + srp.Key1EditControl.Text + "%')");
                                getDataIdList("Person", "PersonSpecialty like '%" + srp.Key1EditControl.Text + "%'", "PersonID");
                                getDataIdList("Subject", "SubjectID in (select SubjectID from Person where " + ("PersonSpecialty like '%" + srp.Key1EditControl.Text + "%'") + ")", "SubjectID");
                                break;
                            case "人员任务分工":
                                sb.Append(" or ").Append("ProjectID in (select ProjectID from Person where TaskContent like '%" + srp.Key1EditControl.Text + "%')");
                                getDataIdList("Person", "TaskContent like '%" + srp.Key1EditControl.Text + "%'", "PersonID");
                                getDataIdList("Subject", "SubjectID in (select SubjectID from Person where " + ("TaskContent like '%" + srp.Key1EditControl.Text + "%'") + ")", "SubjectID");
                                break;
                        }
                    }
                }
                sb.Append(")");

                if (sb.Length > 6)
                {
                    whereString = sb.ToString().Replace("( or ", "(");
                }
                else
                {
                    whereString = "(1=1)";
                    srp.Key1EditControl.Text = string.Empty;
                }
                #endregion
            }

            //查询数据
            return ConnectionManager.Context.table("Project").where(whereString + srp.CatalogIDFilterString + " and IsNeedHide='0'").select("*").getList<Project>(new Project());
        }

        /// <summary>
        /// 获得ID列表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="whereString"></param>
        /// <param name="idField"></param>
        private static void getDataIdList(string tableName, string whereString, string idField)
        {
            DataList dlIDList = ConnectionManager.Context.table(tableName).where(whereString).select(idField).getDataList();
            if (dlIDList.getRowCount() >= 1)
            {
                foreach (DataItem di in dlIDList.getRows())
                {
                    if (di.exists(idField))
                    {
                        try
                        {
                            includeSubTableIdList.Add(tableName + "++" + di.getString(idField));
                        }
                        catch (Exception ex) { }
                    }
                }
            }
        }

        public static bool isDisplayData(string tableName, string id)
        {
            return includeSubTableIdList.Contains(tableName + "++" + id);
        }
    }
}