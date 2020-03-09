using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类UnitMoneys。
    /// </summary>
    [Serializable]
    public partial class UnitMoneys : IEntity
    {
        public UnitMoneys() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("UMID", UMID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("UnitName", UnitName);
            query.set("UMName", UMName);
            query.set("UMValue", UMValue);

            return query;
        }

        public string UMID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public string UnitName { get; set; }
        public string UMName { get; set; }
        public string UMValue { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            UMID = source("UMID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            UnitName = source("UnitName").value<string>("");
            UMName = source("UMName").value<string>("");
            UMValue = source("UMValue").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new UnitMoneys();
        }
    }
}
