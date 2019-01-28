using EMSApi.Entity.PlainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Service.IService
{
    public interface IEnergyViewService
    {
        List<ReportValue> GetMonthValueOfYear(string buildid, string energyCode, DateTime date);
    }
}
