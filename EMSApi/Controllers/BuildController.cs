using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMSApi.Entity;
using EMSApi.Entity.PlainClass;
using EMSApi.Service.IService;
using EMSApi.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMSApi.REST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildController : ControllerBase
    {
        private IBuildService _service;
        public BuildController(IBuildService service)
        {
            this._service = service;
        }
        // GET: api/Build
        [HttpGet]
        public IEnumerable<BuildInfo> Get()
        {
            return _service.GetAllBuilds();
        }

        [HttpGet]
        [Route("simple")]
        public IEnumerable<BuildSimpleInfo> GetSimple()
        {
            return _service.GetAllSimpleBuild();
        }

        [HttpGet]
        [Route("{userName}")]
        public IEnumerable<UserBuildRelationship> Get(string userName)
        {
            return _service.GetBuildsByUser(userName);
        }


    }
}
