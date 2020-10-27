﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class GroupDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public string image { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}