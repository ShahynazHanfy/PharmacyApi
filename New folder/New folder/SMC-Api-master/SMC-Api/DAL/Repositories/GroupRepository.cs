﻿using SMC_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.DAL.Repositories
{
    public class GroupRepository : Repository<Group>
    {
        public GroupRepository(SMC_DBEntities context) : base(context)
        {

        }
    }
}