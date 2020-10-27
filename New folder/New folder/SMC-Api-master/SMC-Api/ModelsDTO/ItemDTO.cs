using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class ItemDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public int SubgroupId { get; set; }
        public string image { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public int ReorderLevel { get; set; }
        public string BarCode { get; set; }
        public int ExpiryDateReminder { get; set; }
        public string Type { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public SubgroupDTO Subgroup { get; set; }


    }
}