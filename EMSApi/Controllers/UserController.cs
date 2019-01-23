using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMSApi.Domain;
using EMSApi.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace EMSApi.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private Service.IService.IUserService _service;
        public UserController(Service.IService.IUserService service)
        {
            this._service = service;
        }
        //// GET api/values
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> Get()
        //{
        //    List<User> users;

        //    users = await context.Users.ToListAsync();

        //    return  users;
        //}

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _service.GetAllUsers();
        }
    }
}