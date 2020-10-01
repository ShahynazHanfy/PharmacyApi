﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Models
{
    public class Pledge
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string telephone { get; set; }

        public string Email { get; set; }
        public bool IsActive { get; set; }

        public string location { get; set; }
        public List<Order> orders { get; set; }
    }
}