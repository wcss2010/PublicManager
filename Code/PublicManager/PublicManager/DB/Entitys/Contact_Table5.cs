using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类Contact_Table5。
    /// </summary>
    [Serializable]
    public partial class Contact_Table5 : IEntity
    {
        public Contact_Table5() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("TID", TID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("NodeID", NodeID);
            query.set("SubjectID", SubjectID);
            query.set("SubjectWorkUnit", SubjectWorkUnit);
            query.set("SubjectTotalMoney", SubjectTotalMoney);
            query.set("SubjectSendMoney", SubjectSendMoney);
            query.set("SubjectSendTime", SubjectSendTime);
            query.set("SubjectSendedMoney", SubjectSendedMoney);
            query.set("SubjectUseMoney", SubjectUseMoney);
            query.set("SubjectNoSendMoney", SubjectNoSendMoney);

            return query;
        }

        public string TID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public string NodeID { get; set; }
        public string SubjectID { get; set; }
        public string SubjectWorkUnit { get; set; }
        public decimal SubjectTotalMoney { get; set; }
        public decimal SubjectSendMoney { get; set; }
        public DateTime SubjectSendTime { get; set; }
        public decimal SubjectSendedMoney { get; set; }
        public decimal SubjectUseMoney { get; set; }
        public decimal SubjectNoSendMoney { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            TID = source("TID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            NodeID = source("NodeID").value<string>("");
            SubjectID = source("SubjectID").value<string>("");
            SubjectWorkUnit = source("SubjectWorkUnit").value<string>("");
            SubjectTotalMoney = source("SubjectTotalMoney").value<decimal>(0);
            SubjectSendMoney = source("SubjectSendMoney").value<decimal>(0);
            SubjectSendTime = source("SubjectSendTime").value<DateTime>(DateTime.Now);
            SubjectSendedMoney = source("SubjectSendedMoney").value<decimal>(0);
            SubjectUseMoney = source("SubjectUseMoney").value<decimal>(0);
            SubjectNoSendMoney = source("SubjectNoSendMoney").value<decimal>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Contact_Table5();
        }
    }
}
