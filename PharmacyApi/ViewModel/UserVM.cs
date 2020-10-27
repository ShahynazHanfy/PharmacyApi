using PharmacyApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.ViewModels
{
    public class UserVM
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string PharmacyName { get; set; }
        public int pharmacyID { get; set; }
        [ForeignKey("pharmacyID")]
        public Pharmacy pharmacy { get; set; }
    }
}
