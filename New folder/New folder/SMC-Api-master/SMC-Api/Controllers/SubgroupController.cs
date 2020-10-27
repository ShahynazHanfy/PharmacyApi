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
    public class SubgroupController : ApiController
    {
        SubgroupService service = new SubgroupService();

        public IEnumerable<SubgroupDTO> GetSubgroups()
        {
            return service.GetAllSubgroups();
        }

        [ResponseType(typeof(SubgroupDTO))]
        public IHttpActionResult PostSubgroup(SubgroupDTO model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = service.AddSubgroup(model);

            return CreatedAtRoute("DefaultApi", new { id = model.ID }, model);
        }

        // GET: api/Subgroup/5
        [ResponseType(typeof(SubgroupDTO))]
        public IHttpActionResult GetSubgroup(int id)
        {
            SubgroupDTO store = service.GetSubgroup(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }


        // PUT: api/Subgroup/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubgroup(int id, SubgroupDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ID)
            {
                return BadRequest();
            }

            service.UpdateSubgroup(model);


            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/DeleteSubgroup/{SubgroupId}")]
        public IHttpActionResult DeleteSubgroup(int SubgroupId)
        {
            service.DeleteSubgroup(SubgroupId);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/SubgroupsByGrpId/{groupId}")]
        public IEnumerable<SubgroupDTO> GetSubgroupsByGrpId(int groupId)
        {
            return service.GetSubgroupsByGrpId(groupId);
           
        }

    }
}
