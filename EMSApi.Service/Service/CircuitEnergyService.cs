using EMSApi.Common;
using EMSApi.Domain;
using EMSApi.Entity.PlainClass;
using EMSApi.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.Sql;

namespace EMSApi.Service.Service
{
    public class CircuitEnergyService : ICircuitEnergyService
    {
        private ApplicationDbContext _context;
        public CircuitEnergyService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<ReportValue> GetCircuitReportValueByMonth(string circuitIds, string date)
        {
            string[] circuitArray = circuitIds.Split(',');
            DateTime startDay = DateTimeUtil.ConvertString2DateTime(date,"yyyy-MM");
            DateTime endDay = DateTimeUtil.GetLastDayOfMonth(startDay);

            var query = from circuits in _context.Circuits
                        join meters in _context.Meters on circuits.MeterId equals meters.MeterId
                        join result in _context.DayResult on meters.MeterId equals result.MeterId
                        join paramInfo in _context.ParamInfo on result.MeterParamId equals paramInfo.MeterParamId
                        where paramInfo.IsEnergyValue == true
                        where result.StarDay >= startDay && result.StarDay <= endDay
                        where circuitArray.Contains(circuits.CircuitId)
                        select new ReportValue
                        {
                            Id = circuits.CircuitId,
                            Name = circuits.CircuitName,
                            Time = result.StarDay,
                            Value = result.Value
                        };
            
            return query.ToList();
        }

        public List<ReportValue> GetEnergyValueByHour(string buildid,string date)
        {
            DateTime startHour = DateTimeUtil.ConvertString2DateTime(date, "yyyy-MM-dd");
            DateTime endHour = new DateTime(startHour.Year, startHour.Month, startHour.Day, 23, 0, 0);
            var query = from circuits in _context.Circuits
                        join meters in _context.Meters on circuits.MeterId equals meters.MeterId
                        join result in _context.HourResult on meters.MeterId equals result.MeterId
                        join paramInfo in _context.ParamInfo on result.MeterParamId equals paramInfo.MeterParamId
                        join energyItem in _context.EnergyItem on circuits.EnergyItemCode equals energyItem.EnergyItemCode
                        where circuits.BuildId == buildid
                        where paramInfo.IsEnergyValue == true
                        where result.StartHour >= startHour && result.StartHour <= endHour
                        where circuits.MainCircuit == true
                        group result.Value by new { energyItem.EnergyItemCode, energyItem.EnergyItemName, result.StartHour } into energy
                        select new ReportValue
                        {
                            Id = energy.Key.EnergyItemCode,
                            Name = energy.Key.EnergyItemName,
                            Time = energy.Key.StartHour,
                            Value = energy.Sum()
                        };

            return query.ToList();
        }

    }
}
