﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class Firm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
        public string Code { get; set; }
        public List<Drug> Drugs { get; set; }

    }
}
