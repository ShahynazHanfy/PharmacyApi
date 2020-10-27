using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PharmacyApi.Models;

namespace PharmacyApi.Authentication
{
    public class ApplicationUser:IdentityUser
    {
        public int pharmacyID { get; set; }
        [ForeignKey("pharmacyID")]
        public Pharmacy pharmacy { get; set; }
    }
}
