using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class OrderTypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public bool ProcessType { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}