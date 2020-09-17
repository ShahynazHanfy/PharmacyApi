using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class PurchasedItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ProductionDate { get; set; }

        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public Drug drug { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
