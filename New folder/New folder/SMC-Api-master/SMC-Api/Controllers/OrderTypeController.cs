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
    public class OrderTypeController : ApiController
    {

            OrderTypeService Service = new OrderTypeService();

            public IEnumerable<OrderTypeDTO> GetTypes()
            {
                return Service.GetAllTypes();
            }

            [HttpGet]
            [Route("api/GetActiveTypes")]
            public IEnumerable<OrderTypeDTO> GetActiveTypes()
              {
                     return Service.GetActiveTypes();
              }
        [ResponseType(typeof(OrderTypeDTO))]
            public IHttpActionResult PostType(OrderTypeDTO obj)
            {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = Service.AddType(obj);

                return CreatedAtRoute("DefaultApi", new { id = obj.ID }, obj);
            }

            // GET: api/Group/5
            [ResponseType(typeof(OrderTypeDTO))]
            public IHttpActionResult GetType(int id)
            {
            OrderTypeDTO entity = Service.GetType(id);
                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }


        // PUT: api/OrderType/5
           [ResponseType(typeof(void))]
            public IHttpActionResult PutTransactionType(int id, OrderTypeDTO obj)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != obj.ID)
                {
                    return BadRequest();
                }

                Service.UpdateType(obj);


                return StatusCode(HttpStatusCode.NoContent);
            }

        [HttpGet]
        [Route("api/DeleteType/{TypeId}")]
        public IHttpActionResult DeleteType(int TypeId)
        {
            Service.DeleteType(TypeId);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
