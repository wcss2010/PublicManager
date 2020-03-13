using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类Contact_Table4。
    /// </summary>
    [Serializable]
    public partial class Contact_Table4 : IEntity
    {
        public Contact_Table4() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("TID", TID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("ModuleName", ModuleName);
            query.set("ModuleValue", ModuleValue);

            return query;
        }

        public string TID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleValue { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            TID = source("TID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            ModuleName = source("ModuleName").value<string>("");
            ModuleValue = source("ModuleValue").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Contact_Table4();
        }
    }
}
