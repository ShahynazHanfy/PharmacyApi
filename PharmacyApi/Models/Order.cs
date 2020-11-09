using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{

    public class Order
    {
       
        public enum Type
        {
            IN,
            OUT,
            Transfer,
            Lose
        }
            [Key]
         //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
       
        public int? supplierID { get; set; }
        [ForeignKey("supplierID")]
        public Supplier Supplier { get; set; }

        //public int pharmacyID { get; set; }
        //[ForeignKey("pharmacyID")]
        //[NotMapped]
        //public Pharmacy pharmacy { get; set; }

        public int pharmacySourceID { get; set; }
        [ForeignKey("pharmacySourceID")]
        [NotMapped]
        public Pharmacy pharmacySource { get; set; }

        public int pharmacyLoggedInID { get; set; }
        [ForeignKey("pharmacyLoggedInID")]
        [NotMapped]
        public Pharmacy pharmacyLoggedIn { get; set; }

        //public List<PurchasedItem> PurchasedItems { get; set; }

        public int pharmacyTargetID { get; set; }
        [ForeignKey("pharmacyTargetID")]
        [NotMapped]
        public Pharmacy pharmacyTarget { get; set; }

        public int? pledgeID { get; set; }



        //[ForeignKey("pledgeID")]
        //public Pledge Pledge { get; set; }

        public List<OrderDetail> orderDetailList { get; set; }

    }

}
