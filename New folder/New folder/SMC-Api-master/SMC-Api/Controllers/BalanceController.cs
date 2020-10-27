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
    public class BalanceController : ApiController
    {
       
            BalanceService Service = new BalanceService();

            public IEnumerable<BalanceDTO> GetBalances()
            {
                return Service.GetAllBalances();
            }

        [HttpGet]
        [Route("api/BalanceByStore/{storeId}")]
        public IEnumerable<BalanceDTO> GetStoreBalances(int storeId)
        {
            return Service.GetStoreBalances(storeId);
        }

        [ResponseType(typeof(BalanceDTO))]
        public IHttpActionResult PostBalance(BalanceDTO obj)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = Service.AddBalance(obj);

            return Ok(result);
        }

        // GET: api/Balance/5
        [ResponseType(typeof(BalanceDTO))]
            public IHttpActionResult GetBalance(int id)
            {
                BalanceDTO entity = Service.GetBalance(id);
                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }


            // PUT: api/Balance/5
            [ResponseType(typeof(void))]
            public IHttpActionResult PutBalance(int id, BalanceDTO obj)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != obj.ID)
                {
                    return BadRequest();
                }

                Service.UpdateBalance(obj);


                return StatusCode(HttpStatusCode.NoContent);
            }

        [HttpGet]
        [ResponseType(typeof(BalanceDTO))]
        [Route("api/GetLastBalance/{storeId}")]
        public IHttpActionResult GetLastBalance(int storeId)
        {
            BalanceDTO entity = Service.GetLastBalance(storeId);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet]
        [ResponseType(typeof(BalanceDTO))]
        [Route("api/GetGenericLastBalance")]
        public IHttpActionResult GetGenericLastBalance()
        {
            BalanceDTO entity = Service.GetGenericLastBalance();
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

      

        //[HttpGet]
        //[Route("api/DeleteTransaction/{TransactionId}")]
        //public IHttpActionResult DeleteTransaction(int TransactionId)
        //{
        //    Service.DeleteType(TransactionId);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}



    }
}
