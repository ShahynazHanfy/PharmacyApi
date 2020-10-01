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
    public class SupplierController : ApiController
    {
        SupplierService supplierService = new SupplierService();

        SMC_DBEntities db = new SMC_DBEntities();

        public IEnumerable<SupplierDTO> GetSuppliers()
        {
            return supplierService.GetAllSuppliers();
        }

        [ResponseType(typeof(SupplierDTO))]
        public IHttpActionResult PostSupplier(SupplierDTO entity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = supplierService.AddSupplier(entity);

            return CreatedAtRoute("DefaultApi", new { id = entity.ID }, entity);
        }

        // GET: api/Supplier/5
        [ResponseType(typeof(SupplierDTO))]
        public IHttpActionResult GetSupplier(int id)
        {
            SupplierDTO entity = supplierService.GetSupplier(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }


        // PUT: api/Supplier/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(int id, SupplierDTO entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.ID)
            {
                return BadRequest();
            }

            supplierService.UpdateSupplier(entity);


            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/DeleteSupplier/{SupplierId}")]
        public IHttpActionResult DeleteSupplier(int SupplierId)
        {
            supplierService.DeleteSupplier(SupplierId);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/topTen/{itemId}")]
        public IEnumerable<GetTopTenSuppliers_Result> TopTen(int itemId)
        {

            var result = db.GetTopTenSuppliers(itemId);
            return result;
            //return supplierService.GetTop10Suppliers();
        }
    }
}
