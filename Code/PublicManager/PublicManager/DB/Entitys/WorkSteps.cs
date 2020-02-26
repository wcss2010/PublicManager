using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类WorkSteps。
    /// </summary>
    [Serializable]
    public partial class WorkSteps : IEntity
    {
        public WorkSteps() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("WSID", WSID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("WorkTime", WorkTime);
            query.set("DestAndContent", DestAndContent);
            query.set("ResultMethod", ResultMethod);

            return query;
        }

        public string WSID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public DateTime WorkTime { get; set; }
        public string DestAndContent { get; set; }
        public string ResultMethod { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            WSID = source("WSID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            WorkTime = source("WorkTime").value<DateTime>(DateTime.Now);
            DestAndContent = source("DestAndContent").value<string>("");
            ResultMethod = source("ResultMethod").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new WorkSteps();
        }
    }
}