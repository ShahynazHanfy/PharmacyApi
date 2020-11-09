using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class DrugDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Strength { get; set; }
        public string Pack { get; set; }
        public string Price { get; set; }
        public string License { get; set; }
        public string Size { get; set; }
        public string ReOrderLevel { get; set; }
        public string BarCode { get; set; }
        public bool IsActive { get; set; }
        public int Quentity { get; set; }
        public DateTime Prod_Date { get; set; }
        public DateTime Exp_Date { get; set; }
        public bool IsChecked { get; set; }
        public string Code { get; set; }
        public int drugID { get; set; }
        [ForeignKey("drugID")]
        public Drug drug { get; set; }

        public int pharmacyLoggedInID { get; set; }
        [ForeignKey("pharmacyLoggedInID")]
        public Pharmacy pharmacyLoggedIn { get; set; }
    }
}

