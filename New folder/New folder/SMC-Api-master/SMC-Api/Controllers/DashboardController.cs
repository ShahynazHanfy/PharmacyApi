using SMC_Api.BLL;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SMC_Api.Controllers
{
    public class DashboardController : ApiController
    {
        DashboardService service = new DashboardService();
        [HttpGet]
        [Route("api/YearBalance")]
        public IEnumerable<MonthBalanceDTO> GetYearBalance()
        {
            return service.GetYearBalance();  
        }

        [HttpGet]
        [Route("api/YearBalancePerQuarter")]
        public IEnumerable<QuarterBalanceDTO> GetYearbalancePerQuarter()
        {
            return service.GetYearBalancePerQuarter();
        }

        [HttpGet]
        [Route("api/QuarterBalancePerMonth/{QuarterNum}")]
        public IEnumerable<MonthBalanceDTO> GetQuarterBalancePerMonth(int QuarterNum)
        {
            return service.GetQuarterBalancePerMonth(QuarterNum);
        }

        [HttpGet]
        [Route("api/QuarterBalance/{QuarterNum}")]
        public QuarterBalanceDTO GetQuarterBalance(int QuarterNum)
        {
            return service.CalculateQuarterBalance(QuarterNum);
        }

        [HttpGet]
        [Route("api/GetLastInOrder")]
        public OrderDTO GetLastInOrder()
        {
            OrderDTO entity = service.GetLastInOrder();
            
            return entity;
        }

        [HttpGet]
        [Route("api/GetLastOutOrder")]
        public OrderDTO GetLastOutOrder()
        {
            OrderDTO entity = service.GetLastOutOrder();

            return entity;
        }

    }
}
