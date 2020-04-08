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
        /// 获得项目信息列表
        /// </summary>
        /// <param name="srp"></param>
        /// <returns></returns>
        public List<Project> getProjectList(SearchRulePanel srp)
        {
            //获得搜索选择条件
            Dictionary<string,bool> ruleDict = srp.getRuleCheckedDict();

            //生成的查询条件
            string whereString = string.Empty;

            #region 生成关键字条件
            StringBuilder sb = new StringBuilder();
            bool isIgnoreAll = true;

            //检查是否需要忽略所有选项
            foreach (KeyValuePair<string, bool> kvp in ruleDict)
            {
                if (kvp.Value)
                {
                    isIgnoreAll = false;
                    break;
                }
            }

            sb.Append("(");
            foreach (KeyValuePair<string, bool> kvp in ruleDict)
            {
                if (kvp.Value || isIgnoreAll)
                {
                    switch (kvp.Key)
                    {
                        case "项目名称":
                            sb.Append("or ").Append("ProjectName like '%" + srp.Key1EditControl.Text + "%'");
                            break;
                        case "计划批次":
                            sb.Append("or ").Append("TaskNumber like '%" + srp.Key1EditControl.Text + "%'");
                            break;
                        case "项目关键词":
                            sb.Append("or ").Append("Keywords like '%" + srp.Key1EditControl.Text + "%'");
                            break;
                        case "课题名称":
                            sb.Append("or ").Append("ProjectID in (select ProjectID from Subject where SubjectName like '%" + srp.Key1EditControl.Text + "%')");
                            break;
                        case "课题负责单位":
                            sb.Append("or ").Append("ProjectID in (select ProjectID from Subject where DutyUnit like '%" + srp.Key1EditControl.Text + "%')");
                            break;
                        case "课题所属地点":
                            sb.Append("or ").Append("ProjectID in (select ProjectID from Subject where DutyUnitAddress like '%" + srp.Key1EditControl.Text + "%')");
                            break;
                        case "人员名称":
                            sb.Append("or ").Append("ProjectID in (select ProjectID from Person where PersonName like '%" + srp.Key1EditControl.Text + "%')");
                            break;
                        case "人员专业":
                            sb.Append("or ").Append("ProjectID in (select ProjectID from Person where PersonSpecialty like '%" + srp.Key1EditControl.Text + "%')");
                            break;
                        case "人员任务分工":
                            sb.Append("or ").Append("ProjectID in (select ProjectID from Person where TaskContent like '%" + srp.Key1EditControl.Text + "%')");
                            break;
                    }
                }
            }
            sb.Append(")");
            whereString = sb.ToString().Replace("(or ", "(");
            #endregion

            #region 生成大单位条件
            if (srp.IsDisplayKey2)
            {
                //大单位可用
                whereString += " and ProjectID in (select ProjectID from Subject where DutyUnitOrg = '" + (srp.Key2EditControl.SelectedItem != null && !srp.Key2EditControl.SelectedItem.ToString().Equals("全部") ? srp.Key2EditControl.SelectedItem.ToString() : "1=1") + "')";
            }
            #endregion

            //查询数据
            return ConnectionManager.Context.table("Project").where(whereString + srp.CatalogIDFilterString).select("*").getList<Project>(new Project());
        }
    }
}