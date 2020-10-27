using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public string Name { get; set; }
        public string NameAR { get; set; }

        public string Description { get; set; }

        public string DescriptionAR { get; set; }
        public bool IsActive { get; set; }

        public virtual List<SubCategory> subcategory { get; set; }


    }
}
