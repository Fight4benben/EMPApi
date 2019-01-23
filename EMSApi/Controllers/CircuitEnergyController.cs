﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMSApi.Entity.PlainClass;
using EMSApi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMSApi.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitEnergyController : ControllerBase
    {
        private ICircuitEnergyService _service;
        private IEnergyViewService _energyViewService;
        public CircuitEnergyController(ICircuitEnergyService service,IEnergyViewService energyViewService)
        {
            this._service = service;
            this._energyViewService = energyViewService;
        }

        [Route("Month")]
        [HttpGet]
        public IEnumerable<ReportValue> GetReportValueMonth(string ids,string date)
        {
            return _service.GetCircuitReportValueByMonth(ids,date);
        }

        [Route("MainHour")]
        [HttpGet]
        public IEnumerable<ReportValue> GetMainCircuitHourValues(string buildid,string date)
        {
            return _service.GetEnergyValueByHour(buildid,date);
        }

        //[Route("Compare")]
        //[HttpGet]
        //public CompareValue GetCompareValue(string buildid,string energyCode,string typeName)
        //{
        //    string date = DateTime.Now.ToString("yyyy-MM-dd");
        //    return  _energyViewService.GetCompareValue(buildid,energyCode,typeName,date);
        //}
    }
}