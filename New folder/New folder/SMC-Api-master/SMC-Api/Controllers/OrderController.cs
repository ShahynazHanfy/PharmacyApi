using SMC_Api.BLL;
using SMC_Api.Models;
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
    public class OrderController : ApiController
    {
        //test clone
            OrderService Service = new OrderService();

        public IEnumerable<OrderDTO> GetOrders()
        {
            return Service.GetAllOrders();
        }

        [HttpGet]
        [Route("api/OrderByStore/{storeId}")]
        public IEnumerable<OrderDTO> GetStoreOrders(int storeId)
            {
                return Service.GetStoreOrders(storeId);
            }

            [ResponseType(typeof(OrderDTO))]
            public IHttpActionResult PostOrder(OrderDTO obj)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool result = Service.AddOrder(obj);

                return CreatedAtRoute("DefaultApi", new { id = obj.ID }, obj);
            }

            // GET: api/Order/5
            [ResponseType(typeof(OrderDTO))]
            public IHttpActionResult GetOrder(int id)
            {
                OrderDTO entity = Service.GetOrder(id);
                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }


            // PUT: api/Order/5
            [ResponseType(typeof(void))]
            public IHttpActionResult PutOrder(int id, OrderDTO obj)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != obj.ID)
                {
                    return BadRequest();
                }

                Service.UpdateOrder(obj);


                return StatusCode(HttpStatusCode.NoContent);
            }

        [HttpPost]
        [Route("api/GetOrdersByType")]
        public IEnumerable<OrderDTO> GetOrdersByType(TransactionReportDTO details)
        {
            
            return Service.GetOrderByTypes(details);
        }

        [HttpGet]
        [Route("api/Employee")]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return Service.GetAllEmployees();
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
