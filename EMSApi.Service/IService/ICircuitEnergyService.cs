using EMSApi.Entity.PlainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Service.IService
{
    public interface ICircuitEnergyService
    {
        List<ReportValue> GetCircuitReportValueByMonth(string circuits,string date);

        List<ReportValue> GetEnergyValueByHour(string date, string date1);
    }
}
