using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类MoneySends。
    /// </summary>
    [Serializable]
    public partial class MoneySends : IEntity
    {
        public MoneySends() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("MSID", MSID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("NodeIndex", NodeIndex);
            query.set("SendRule", SendRule);
            query.set("WillTime", WillTime);
            query.set("TotalMoney", TotalMoney);
            query.set("MemoText", MemoText);
            query.set("NodeWillTime", NodeWillTime);
            query.set("WillContent", WillContent);
            query.set("WillLevel", WillLevel);
            query.set("WillWorker", WillWorker);

            return query;
        }

        public string MSID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public int NodeIndex { get; set; }
        public string SendRule { get; set; }
        public DateTime WillTime { get; set; }
        public decimal TotalMoney { get; set; }
        public string MemoText { get; set; }
        public DateTime NodeWillTime { get; set; }
        public string WillContent { get; set; }
        public string WillLevel { get; set; }
        public string WillWorker { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            MSID = source("MSID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            NodeIndex = source("NodeIndex").value<int>(0);
            SendRule = source("SendRule").value<string>("");
            WillTime = source("WillTime").value<DateTime>(DateTime.Now);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            MemoText = source("MemoText").value<string>("");
            NodeWillTime = source("NodeWillTime").value<DateTime>(DateTime.Now);
            WillContent = source("WillContent").value<string>("");
            WillLevel = source("WillLevel").value<string>("");
            WillWorker = source("WillWorker").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new MoneySends();
        }
    }
}