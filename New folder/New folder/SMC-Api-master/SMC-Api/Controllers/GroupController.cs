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
    public class GroupController : ApiController
    {
        GroupService Service = new GroupService();

        public IEnumerable<GroupDTO> GetGroups()
        {
            return Service.GetAllGroups();
        }

        [ResponseType(typeof(GroupDTO))]
        public IHttpActionResult PostGroup(GroupDTO group)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = Service.AddGroup(group);

            return CreatedAtRoute("DefaultApi", new { id = group.ID }, group);
        }

        // GET: api/Group/5
        [ResponseType(typeof(GroupDTO))]
        public IHttpActionResult GetGroup(int id)
        {
            GroupDTO group = Service.GetGroup(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }


        // PUT: api/Group/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroup(int id, GroupDTO group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != group.ID)
            {
                return BadRequest();
            }

            Service.UpdateGroup(group);


            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/DeleteGroup/{GroupId}")]
        public IHttpActionResult DeleteGroup(int GroupId)
        {
            Service.DeleteGroup(GroupId);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
