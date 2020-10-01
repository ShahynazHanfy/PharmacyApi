using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class ItemBalanceDTO
    {
        public int ID { get; set; }
        public int BalanceId { get; set; }
        public int ItemId { get; set; }
        public ItemDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}