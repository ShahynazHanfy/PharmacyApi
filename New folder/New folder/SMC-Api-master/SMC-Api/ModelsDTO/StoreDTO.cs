using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class StoreDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressAr { get; set; }
        //public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public int Area { get; set; }
        public int Telephone { get; set; }
        public int StorKeeperId { get; set; }
        public string Remarks { get; set; }
        public string image { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}