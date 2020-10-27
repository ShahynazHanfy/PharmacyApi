using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class BalanceDTO
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime BalanceDate { get; set; }
        public int StoreId { get; set; }
        public StoreDTO Store { get; set; }
        public ItemBalanceDTO[] itemList { get; set; }

    }
}