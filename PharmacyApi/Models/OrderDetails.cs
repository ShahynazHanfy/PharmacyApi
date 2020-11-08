using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? drugID { get; set; }
        [ForeignKey("drugID")]
        public Drug drug { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order order { get; set; }

        public int Quentity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime Prod_Date { get; set; }
        public DateTime Exp_Date { get; set; }

   
    }
}
