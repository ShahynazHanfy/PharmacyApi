using PharmacyApi.Models;
using PharmacyApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Mappers
{
    public static class OrderMaper
    {

        public static OrderVM EditOrderPendingStatus(this Order model)
        {
            var OrderObj = new OrderVM
            {

                PendingStatus = model.PendingStatus
            };
            return OrderObj;
        }
    }
}
