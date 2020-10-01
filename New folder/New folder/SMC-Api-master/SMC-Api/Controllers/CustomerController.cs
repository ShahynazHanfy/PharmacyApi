using SMC_Api.BLL;
using SMC_Api.Models;
using SMC_Api.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SMC_Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CustomerController : ApiController
    {
        CustomerService customerService = new CustomerService();

        SMC_DBEntities db = new SMC_DBEntities();

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return customerService.GetAllCustomers();
        }

        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult PostCustomer(CustomerDTO entity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = customerService.AddCustomer(entity);

            return CreatedAtRoute("DefaultApi", new { id = entity.ID }, entity);
        }

        // GET: api/Customer/5
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult GetCustomer(int id)
        {
            CustomerDTO entity = customerService.GetCustomer(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }


        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, CustomerDTO entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.ID)
            {
                return BadRequest();
            }

            customerService.UpdateCustomer(entity);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/DeleteCustomer/{CustomerId}")]
        public IHttpActionResult DeleteCustomer(int CustomerId)
        {
            customerService.DeleteCustomer(CustomerId);
            return StatusCode(HttpStatusCode.NoContent);
        }
        
    }
}
