using System;
using System.Collections.Generic;
using System.Text;

namespace PublicManager.DB.Entitys
{
    /// <summary>
    /// 类NormalUnitDict。
    /// </summary>
    [Serializable]
    public partial class NormalUnitDict : IEntity
    {
        public NormalUnitDict() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("DID", DID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("DutyUnit", DutyUnit);
            query.set("DutyNormalUnit", DutyNormalUnit);

            return query;
        }

        public string DID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public string DutyUnit { get; set; }
        public string DutyNormalUnit { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            DID = source("DID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            DutyUnit = source("DutyUnit").value<string>("");
            DutyNormalUnit = source("DutyNormalUnit").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new NormalUnitDict();
        }
    }
}