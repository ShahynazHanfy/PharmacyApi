using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class SubCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public string Name { get; set; }
        public string NameAR { get; set; }

        public string Description { get; set; }

        public string DescriptionAR { get; set; }

        public int categoryID { get; set; }

        [ForeignKey("categoryID")]
        public Category category { get; set; }

        public int theraSubID { get; set; }

        [ForeignKey("theraSubID")]
        public TheraGroup thera { get; set; }

    }
}
