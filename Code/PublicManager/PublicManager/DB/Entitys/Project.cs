using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类Project。
    /// </summary>
    [Serializable]
    public partial class Project : IEntity
    {
        public Project() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ProjectID", ProjectID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectName", ProjectName);
            query.set("SecretLevel", SecretLevel);
            query.set("TotalMoney", TotalMoney);
            query.set("Keywords", Keywords);
            query.set("Domains", Domains);
            query.set("DutyUnit", DutyUnit);
            query.set("DutyNormalUnit", DutyNormalUnit);
            query.set("DutyUnitOrg", DutyUnitOrg);
            query.set("DutyUnitAddress", DutyUnitAddress);
            query.set("ProjectNumber", ProjectNumber);
            query.set("TotalTime", TotalTime);
            query.set("ProjectRange", ProjectRange);
            query.set("TaskNumber", TaskNumber);
            query.set("OKQuestionMemo", OKQuestionMemo);
            query.set("OKCheckA", OKCheckA);
            query.set("OKCheckB", OKCheckB);
            query.set("ContactCheckLevelA", ContactCheckLevelA);
            query.set("ContactCheckLevelB", ContactCheckLevelB);
            query.set("Memo", Memo);

            return query;
        }

        public string ProjectID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectName { get; set; }
        public string SecretLevel { get; set; }
        public decimal TotalMoney { get; set; }
        public string Keywords { get; set; }
        public string Domains { get; set; }
        public string DutyUnit { get; set; }
        public string DutyNormalUnit { get; set; }
        public string DutyUnitOrg { get; set; }
        public string DutyUnitAddress { get; set; }
        public string ProjectNumber { get; set; }
        public int TotalTime { get; set; }
        public string ProjectRange { get; set; }
        public string TaskNumber { get; set; }
        public string OKQuestionMemo { get; set; }
        public string OKCheckA { get; set; }
        public string OKCheckB { get; set; }
        public string ContactCheckLevelA { get; set; }
        public string ContactCheckLevelB { get; set; }
        public string Memo { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ProjectID = source("ProjectID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectName = source("ProjectName").value<string>("");
            SecretLevel = source("SecretLevel").value<string>("");
            TotalMoney = source("TotalMoney").value<decimal>(0);
            Keywords = source("Keywords").value<string>("");
            Domains = source("Domains").value<string>("");
            DutyUnit = source("DutyUnit").value<string>("");
            DutyNormalUnit = source("DutyNormalUnit").value<string>("");
            DutyUnitOrg = source("DutyUnitOrg").value<string>("");
            DutyUnitAddress = source("DutyUnitAddress").value<string>("");
            ProjectNumber = source("ProjectNumber").value<string>("");
            TotalTime = source("TotalTime").value<int>(0);
            ProjectRange = source("ProjectRange").value<string>("");
            TaskNumber = source("TaskNumber").value<string>("");
            OKQuestionMemo = source("OKQuestionMemo").value<string>("");
            OKCheckA = source("OKCheckA").value<string>("");
            OKCheckB = source("OKCheckB").value<string>("");
            ContactCheckLevelA = source("ContactCheckLevelA").value<string>("");
            ContactCheckLevelB = source("ContactCheckLevelB").value<string>("");
            Memo = source("Memo").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Project();
        }
    }
}