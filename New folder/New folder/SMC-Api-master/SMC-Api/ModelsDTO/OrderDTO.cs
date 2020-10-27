using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreationDate { get; set; }

        public int TypeId { get; set; }
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int StoreId { get; set; }
        public StoreDTO Store { get; set; }
        public OrderTypeDTO Type { get; set; }
        public Nullable<int>  SupplierId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> DeliveredToStore { get; set; }
        public Nullable<int> GettedFromStore { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string Comments { get; set; }
        public string Attachment { get; set; }
        public OrderDetailsDTO[] ItemList { get; set; }


    }
}