using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class DrugInteraction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string SideEffects { get; set; }
        public bool IsActive { get; set; }

        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public Drug Drug { get; set; }

        public int DrugInteractedID { get; set; }
        //[ForeignKey("DrugInteractedID")]
        //public Drug DrugInteracted { get; set; }
    }
}
