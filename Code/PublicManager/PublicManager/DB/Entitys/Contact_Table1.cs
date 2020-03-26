using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类Contact_Table1。
    /// </summary>
    [Serializable]
    public partial class Contact_Table1 : IEntity
    {
        public Contact_Table1() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("TID", TID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("NodeID", NodeID);
            query.set("WorkUnit", WorkUnit);
            query.set("ProjectName", ProjectName);
            query.set("ProjectMaster", ProjectMaster);
            query.set("TotalMoney", TotalMoney);
            query.set("TotalMoneyNow", TotalMoneyNow);

            return query;
        }

        public string TID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public string NodeID { get; set; }
        public string WorkUnit { get; set; }
        public string ProjectName { get; set; }
        public string ProjectMaster { get; set; }
        public decimal TotalMoney { get; set; }
        public decimal TotalMoneyNow { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            TID = source("TID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            NodeID = source("NodeID").value<string>("");
            WorkUnit = source("WorkUnit").value<string>("");
            ProjectName = source("ProjectName").value<string>("");
            ProjectMaster = source("ProjectMaster").value<string>("");
            TotalMoney = source("TotalMoney").value<decimal>(0);
            TotalMoneyNow = source("TotalMoneyNow").value<decimal>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Contact_Table1();
        }
    }
}