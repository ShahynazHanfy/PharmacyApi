using SMC_Api.BLL;
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
    public class StoreController : ApiController
    {
        StoreService storeService = new StoreService();

        public IEnumerable<StoreDTO> GetStores()
        {
            return storeService.GetAllStores();
        }

        [ResponseType(typeof(StoreDTO))]
        public IHttpActionResult PostStore(StoreDTO store)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = storeService.AddStore(store);

            return CreatedAtRoute("DefaultApi", new { id = store.ID }, store);
        }

        // GET: api/Store/5
        [ResponseType(typeof(StoreDTO))]
        public IHttpActionResult GetStore(int id)
        {
            StoreDTO store = storeService.GetStore(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }


        // PUT: api/Store/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStore(int id, StoreDTO store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.ID)
            {
                return BadRequest();
            }

            storeService.UpdateStore(store);


            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/DeleteStore/{StoreId}")]
        public IHttpActionResult DeleteStore(int StoreId)
        {
            storeService.DeleteStore(StoreId);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
