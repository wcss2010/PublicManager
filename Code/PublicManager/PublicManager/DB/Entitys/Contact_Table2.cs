using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类Contact_Table2。
    /// </summary>
    [Serializable]
    public partial class Contact_Table2 : IEntity
    {
        public Contact_Table2() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("TID", TID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("NodeID", NodeID);
            query.set("WorkDeskJob", WorkDeskJob);
            query.set("PersonName", PersonName);
            query.set("PersonUnit", PersonUnit);
            query.set("PersonJob", PersonJob);
            query.set("PersonPhone", PersonPhone);

            return query;
        }

        public string TID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public string NodeID { get; set; }
        public string WorkDeskJob { get; set; }
        public string PersonName { get; set; }
        public string PersonUnit { get; set; }
        public string PersonJob { get; set; }
        public string PersonPhone { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            TID = source("TID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            NodeID = source("NodeID").value<string>("");
            WorkDeskJob = source("WorkDeskJob").value<string>("");
            PersonName = source("PersonName").value<string>("");
            PersonUnit = source("PersonUnit").value<string>("");
            PersonJob = source("PersonJob").value<string>("");
            PersonPhone = source("PersonPhone").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Contact_Table2();
        }
    }
}
