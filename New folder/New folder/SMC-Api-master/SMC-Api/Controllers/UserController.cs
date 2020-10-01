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
    public class UserController : ApiController
    {
        //private UserService userService = new UserService();

        //// GET: api/User
        //public IEnumerable<RegisterBindingModel> GetUsers()
        //{
        //    return userService.GetUsers();
        //}

        //// GET: api/User/5
        //[ResponseType(typeof(RegisterBindingModel))]
        //public IHttpActionResult GetUser(string id)
        //{
        //    RegisterBindingModel user = userService.GetUser(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}


        //[ResponseType(typeof(RegisterBindingModel))]
        //public IHttpActionResult PostUser(RegisterBindingModel user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    bool result = userService.AddUser(user);

        //    return CreatedAtRoute("DefaultApi", new { id = user.FirstName }, user);
        //}

        //// PUT: api/User/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUser(string id, RegisterBindingModel user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //if (id != user.ID)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    userService.UpdateUser(user);


        //    return StatusCode(HttpStatusCode.NoContent);
        //}


        //[System.Web.Http.HttpGet]
        //[System.Web.Http.Route("api/GetRoles")]
        //public IEnumerable<RoleDTO> GetRoles()
        //{

        //    return userService.GetRoles();
        //}
    }
}
