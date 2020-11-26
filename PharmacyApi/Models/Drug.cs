using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class Drug
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string TradeName { get; set; }
        public string GenericName { get; set; }
        public string Img { get; set; }

        public int TheraSubGroupID { get; set; }
        [ForeignKey("TheraSubGroupID")]
        public TheraSubGroup TheraSubGroup { get; set; }

        public int formID { get; set; }
        [ForeignKey("formID")]
        public Form Form { get; set; }

        public int firmID { get; set; }
        [ForeignKey("firmID")]
        public Firm Firm { get; set; }

        public int unitID { get; set; }
        [ForeignKey("unitID")]
        public Unit Unit { get; set; }

        public int rOADID { get; set; }
        [ForeignKey("rOADID")]
        public ROAD ROAD { get; set; }

        public int countryID { get; set; }
        [ForeignKey("countryID")]
        public Country Country { get; set; }
       // public List<DrugDetails> drugDetails { get; set; }

        //public DrugDetails drugDetails { get; set; }

    }
}
