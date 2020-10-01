using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string Address    { get; set; }
        public string FieldOfWork { get; set; }
        public string Category { get; set; }
        public string Advantages { get; set; }
        public string TaxCertificate { get; set; }
        public string CommercialRegistration { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}