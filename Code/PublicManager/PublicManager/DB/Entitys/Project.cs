using System;
using System.Data;
using System.Text;

namespace PublicManager.DB.Entitys 
{
    /// <summary>
    /// 类Project。
    /// </summary>
    [Serializable]
    public partial class Project : IEntity
    {
        public Project() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ProjectID", ProjectID);
            query.set("CatalogID", CatalogID);
            query.set("ProjectName", ProjectName);
            query.set("SecretLevel", SecretLevel);
            query.set("TotalMoney", TotalMoney);

            return query;
        }

        public string ProjectID { get; set; }
        public string CatalogID { get; set; }
        public string ProjectName { get; set; }
        public string SecretLevel { get; set; }
        public decimal TotalMoney { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ProjectID = source("ProjectID").value<string>(Guid.NewGuid().ToString());
            CatalogID = source("CatalogID").value<string>("");
            ProjectName = source("ProjectName").value<string>("");
            SecretLevel = source("SecretLevel").value<string>("");
            TotalMoney = source("TotalMoney").value<decimal>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Project();
        }
    }
}
