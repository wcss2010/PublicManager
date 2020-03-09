using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类SubjectMoneys。
    /// </summary>
    [Serializable]
    public partial class SubjectMoneys : IEntity
    {
        public SubjectMoneys() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("SMID", SMID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectID", ProjectID);
            query.set("SubjectID", SubjectID);
            query.set("SMName", SMName);
            query.set("SMValue", SMValue);

            return query;
        }

        public string SMID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectID { get; set; }
        public string SubjectID { get; set; }
        public string SMName { get; set; }
        public string SMValue { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            SMID = source("SMID").value<string>("");
            CatalogID = source("CatalogID").value<string>("");
            ProjectID = source("ProjectID").value<string>("");
            SubjectID = source("SubjectID").value<string>("");
            SMName = source("SMName").value<string>("");
            SMValue = source("SMValue").value<string>("");
        }

        public override Noear.Weed.IBinder clone()
        {
            return new SubjectMoneys();
        }
    }
}
