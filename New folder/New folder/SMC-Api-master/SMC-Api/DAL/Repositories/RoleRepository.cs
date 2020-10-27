using SMC_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.DAL.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(SMC_DBEntities context) : base(context)
        {

        }
    }
}