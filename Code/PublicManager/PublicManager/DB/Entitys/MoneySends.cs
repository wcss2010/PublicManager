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
            query.set("SendRule", SendRule);
            query.set("WillTime", WillTime);
            query.set("TotalMoney", TotalMoney);
            query.set("MemoText", MemoText);

            return query;
        }

        public string MSID { get; set; }
        public string SendRule { get; set; }
        public DateTime WillTime { get; set; }
        public decimal TotalMoney { get; set; }
        public string MemoText { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            MSID = source("MSID").value<string>("");
            SendRule = source("SendRule").value<string>("");
            WillTime = source("WillTime").value<DateTime>(DateTime.Now);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            MemoText = source("MemoText").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new MoneySends();
        }
    }
}