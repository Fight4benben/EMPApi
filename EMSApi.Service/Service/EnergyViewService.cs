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

        public List<ReportValue> GetMonthValueOfYear(string buildid, string energyCode, DateTime date)
        {
            DateTime startDate = new DateTime(date.Year,1,1);
            DateTime endDate = new DateTime(startDate.Year,12,31);

            var query = from circuits in _context.Circuits
                        join meters in _context.Meters on circuits.MeterId equals meters.MeterId
                        join result in _context.DayResult on meters.MeterId equals result.MeterId
                        join paramInfo in _context.ParamInfo on result.MeterParamId equals paramInfo.MeterParamId
                        join energyItem in _context.EnergyItem on circuits.EnergyItemCode equals energyItem.EnergyItemCode
                        where paramInfo.IsEnergyValue == true
                        where circuits.MainCircuit == true
                        where energyItem.EnergyItemCode == energyCode
                        where result.StarDay >= startDate && result.StarDay <= endDate
                        group result.Value by new { energyItem.EnergyItemCode,energyItem.EnergyItemName,result.StarDay.Month} into energy
                        select new ReportValue
                        {
                            Id = energy.Key.EnergyItemCode,
                            Name = energy.Key.EnergyItemName,
                            Time = new DateTime(startDate.Year,energy.Key.Month,1),
                            Value = energy.Sum()
                        };

            return query.ToList();
        }


        /// <summary>
        /// 获取某个月某建筑某分类的月报
        /// </summary>
        /// <param name="buildid"></param>
        /// <param name="energyCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private List<ReportValue> GetDayValueOfMonth(string buildid, string energyCode, DateTime date)
        {
            DateTime startDate = new DateTime(date.Year,date.Month,1);
            DateTime endDate = startDate.AddDays(1 - startDate.Day).AddMonths(1).AddDays(-1);

            var query = from circuits in _context.Circuits
                        join meters in _context.Meters on circuits.MeterId equals meters.MeterId
                        join result in _context.DayResult on meters.MeterId equals result.MeterId
                        join paramInfo in _context.ParamInfo on result.MeterParamId equals paramInfo.MeterParamId
                        join energyItem in _context.EnergyItem on circuits.EnergyItemCode equals energyItem.EnergyItemCode
                        where paramInfo.IsEnergyValue == true
                        where circuits.MainCircuit == true
                        where circuits.EnergyItemCode == energyCode
                        where result.StarDay >= startDate && result.StarDay <= endDate
                        group result.Value by new { energyItem.EnergyItemCode, energyItem.EnergyItemName, result.StarDay } into energy
                        select new ReportValue
                        {
                            Id = energy.Key.EnergyItemCode,
                            Name = energy.Key.EnergyItemName,
                            Time = energy.Key.StarDay,
                            Value = energy.Sum()
                        };

            return query.ToList();
        }

        /// <summary>
        /// 获取某栋建筑，某天，某个分类每个小时用能值
        /// </summary>
        /// <param name="buildid"></param>
        /// <param name="energyCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private List<ReportValue> GetHourTrend(string buildid, string energyCode, DateTime date)
        {
            DateTime startHour = new DateTime(date.Year,date.Month,date.Day,0,0,0) ;
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
                        where energyItem.EnergyItemCode == energyCode
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
