using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.ViewModel
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public int Number { get; set; }
        public string pharmacySource { get; set; }
        public string pharmacyTarget { get; set; }
        public string PledgeName { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public bool IsDeleted { get; set; }
        public int TotalDrugQuantity { get; set; }
        public int pharmacyTargetId { get; set; }
        public int? pledgeId { get; set; }
        public int? supplierID { get; set; }
        public string SupplierName { get; set; }
        public bool PendingStatus { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
      
        public List<OrderDetailVM> ListDetails { get; set; }




    }

    public class OrderDetailVM
    {

        public int OrderDetailId { get; set; }
        public int? drugID { get; set; }
        public string DrugName { get; set; }
        public int? quentityInEachOrder { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Prod_Date { get; set; }
        public DateTime? Exp_Date { get; set; }
    }
    }
