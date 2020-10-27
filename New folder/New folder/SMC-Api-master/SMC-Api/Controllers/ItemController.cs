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
    public class ItemController : ApiController
    {
        ItemService Service = new ItemService();

        public IEnumerable<ItemDTO> GetItems()
        {
            return Service.GetAllItems();
        }

        [ResponseType(typeof(ItemDTO))]
        public IHttpActionResult PostItem(ItemDTO item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = Service.AddItem(item);

            return CreatedAtRoute("DefaultApi", new { id = item.ID }, item);
        }

        // GET: api/Item/5
        [ResponseType(typeof(ItemDTO))]
        public IHttpActionResult GetItem(int id)
        {
            ItemDTO item = Service.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        // PUT: api/Item/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, ItemDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ID)
            {
                return BadRequest();
            }

            Service.UpdateItem(item);


            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/DeleteItem/{ItemId}")]
        public IHttpActionResult DeleteItem(int ItemId)
        {
            Service.DeleteItem(ItemId);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/ExpiredItemsWithinDays/{NumberOfDays}")]
        public IEnumerable<OrderDetailsDTO> ExpiredItemsWithinNumberOfDays(int NumberOfDays)
        {
            return Service.GetExpiredItems(NumberOfDays);
            
        }

        [HttpGet]
        [Route("api/GetItemsWhichNeedToReordered/{StoreId}")]
        public IEnumerable<ItemBalanceDTO> GetItemsReachedReorderLevelForStore(int StoreId)
        {
            return Service.GetItemsNeedToReorderedForStore(StoreId);

        }
        //[HttpGet]
        //[Route("api/GetTopTen")]
        //public IEnumerable<IGrouping<int,OrderDetail>> GetTopTen()
        //{
        //    return Service.GetTopTenBestSelling();

        //}
    }
}
