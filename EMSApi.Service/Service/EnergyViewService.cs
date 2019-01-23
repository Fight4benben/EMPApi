using EMSApi.Domain;
using EMSApi.Entity.PlainClass;
using EMSApi.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EMSApi.Common;

namespace EMSApi.Service.Service
{
    public class EnergyViewService:IEnergyViewService
    {
        private ApplicationDbContext _context;

        public EnergyViewService(ApplicationDbContext context)
        {
            _context = context;
        }


        private List<ReportValue> GetHourTrend(string buildid,string energyCode,string date)
        {

        }

        /// <summary>
        /// 获取同比数据
        /// </summary>
        /// <param name="buildid">建筑Id</param>
        /// <param name="energyCode">能源分类</param>
        /// <param name="typeName">日、月、年类型</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        private CompareValue GetCompareValue(string buildid,string energyCode,string typeName,string date)
        {
            
            DateTime start = DateTimeUtil.ConvertString2DateTime(date, "yyyy-MM-dd");
            DateTime endHour = new DateTime(start.Year, start.Month, start.Day, 23, 0, 0);

            var query = from circuits in _context.Circuits
                        select new ReportValue{
                            
                        }; 
            switch (typeName.ToLower())
            {
                case "day":
                    query = from circuits in _context.Circuits
                            join meters in _context.Meters on circuits.MeterId equals meters.MeterId
                            join hourResult in _context.HourResult on meters.MeterId equals hourResult.MeterId
                            join paramInfo in _context.ParamInfo on hourResult.MeterParamId equals paramInfo.MeterParamId
                            join energyItem in _context.EnergyItem on circuits.EnergyItemCode equals energyItem.EnergyItemCode
                            where circuits.BuildId == buildid
                            where hourResult.StartHour >= start.AddDays(-1) && hourResult.StartHour <= endHour
                            where paramInfo.IsEnergyValue == true
                            where circuits.EnergyItemCode == energyCode
                            where circuits.MainCircuit == true
                            group hourResult.Value by new { energyItem.EnergyItemCode, energyItem.EnergyItemName, hourResult.StartHour } into energy
                            select new ReportValue
                            {
                                Id = energy.Key.EnergyItemCode,
                                Name = energy.Key.EnergyItemName,
                                Time = energy.Key.StartHour,
                                Value = energy.Sum()
                            };
                    break;
                case "month":
                    query = from circuits in _context.Circuits
                            join meters in _context.Meters on circuits.MeterId equals meters.MeterId
                            join result in _context.DayResult on meters.MeterId equals result.MeterId
                            join paramInfo in _context.ParamInfo on result.MeterParamId equals paramInfo.MeterParamId
                            join energyItem in _context.EnergyItem on circuits.EnergyItemCode equals energyItem.EnergyItemCode
                            where circuits.BuildId == buildid
                            where result.StarDay >= new DateTime(start.Year,start.Month,1).AddDays(-1) && result.StarDay <= start
                            where paramInfo.IsEnergyValue == true
                            where circuits.EnergyItemCode == energyCode
                            where circuits.MainCircuit == true
                            group result.Value by new { energyItem.EnergyItemCode, energyItem.EnergyItemName, result.StarDay } into energy
                            select new ReportValue
                            {
                                Id = energy.Key.EnergyItemCode,
                                Name = energy.Key.EnergyItemName,
                                Time = energy.Key.StarDay,
                                Value = energy.Sum()
                            };
                    break;
                case "year":
                    query = from circuits in _context.Circuits
                            join meters in _context.Meters on circuits.MeterId equals meters.MeterId
                            join result in _context.DayResult on meters.MeterId equals result.MeterId
                            join paramInfo in _context.ParamInfo on result.MeterParamId equals paramInfo.MeterParamId
                            join energyItem in _context.EnergyItem on circuits.EnergyItemCode equals energyItem.EnergyItemCode
                            where circuits.BuildId == buildid
                            where result.StarDay >= new DateTime(start.Year, start.Month, 1).AddDays(-1) && result.StarDay <= start
                            where paramInfo.IsEnergyValue == true
                            where circuits.EnergyItemCode == energyCode
                            where circuits.MainCircuit == true
                            group result.Value by new { energyItem.EnergyItemCode, energyItem.EnergyItemName, result.StarDay.Year } into energy
                            select new ReportValue
                            {
                                Id = energy.Key.EnergyItemCode,
                                Name = energy.Key.EnergyItemName,
                                Time = new DateTime(energy.Key.Year,1,1),
                                Value = energy.Sum()
                            };
                    break;
            }
            
            List<ReportValue> list = query.ToList();
            return CalcCompareValue(list, typeName, start);
        }

        private CompareValue CalcCompareValue(List<ReportValue> list, string type,DateTime date)
        {
            CompareValue compareValue = new CompareValue();

            decimal nowTimeValue=0, lastTimeValue=0;
            string typeName="";


            switch (type)
            {
                case "day":
                    typeName = "日";
                    foreach (var item in list)
                    {
                        nowTimeValue += item.Time.Day == date.Day ? item.Value : 0;
                        lastTimeValue += item.Time.Day != date.Day ? item.Value : 0;
                    }
                    break;
                case "month":
                    typeName = "月";
                    foreach (var item in list)
                    {
                        nowTimeValue += item.Time.Month == date.Month ? item.Value : 0;
                        lastTimeValue += item.Time.Month != date.Month ? item.Value : 0;
                    }
                    break;
                case "year":
                    typeName = "年";
                    foreach (var item in list)
                    {
                        nowTimeValue += item.Time.Year == date.Year ? item.Value : 0;
                        lastTimeValue += item.Time.Year != date.Year ? item.Value : 0;
                    }
                    break;
            }

            compareValue.TypeName = typeName;
            compareValue.NowTimeValue = nowTimeValue;
            compareValue.LastTimeValue = lastTimeValue;

            return compareValue;
        }
    }
}
