using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class TheraSubGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
        public List<Drug> Drugs { get; set; }

        public int TheraGroupID { get; set; }
        [ForeignKey("TheraGroupID")]
        public TheraGroup TheraGroup { get; set; }
    }
}
