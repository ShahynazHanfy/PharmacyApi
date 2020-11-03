using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.DTO
{
    public class DrugsDetailsDTO
    {
        public int ID { get; set; }
        public string TradeName { get; set; }
        public string GenericName { get; set; }
        public string Img { get; set; }
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
        public int pharmacyID { get; set; }
    }
}
