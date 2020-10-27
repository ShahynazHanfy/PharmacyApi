using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC_Api.ModelsDTO
{
    public class TransactionReportDTO
    {
        public DateTime FromOrder { set; get; }
        public DateTime ToOrder { set; get; }
        public int StoreId { set; get; }
        public int[] Types { set; get; }

    }
}