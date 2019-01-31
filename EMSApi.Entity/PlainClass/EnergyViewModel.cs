using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Entity.PlainClass
{
    public class EnergyViewModel
    {
        public ChartValue DayChart { get; set; }
        public ChartValue MonthChart { get; set; }
        public ChartValue YearChart { get; set; }
        public List<CompareValue> Compares { get; set; }
        public List<ReportValue> ItemValue { get; set; }
    }

    public class ChartValue
    {
        public List<ReportValue> Now { get; set; }
        public List<ReportValue> Before { get; set; }
    }

    public class CompareValue
    {
        public string TypeName { get; set; }
        public decimal? NowTimeValue { get; set; }
        public decimal? LastTimeValue { get; set; }
        public decimal? LastSameTimeValue { get; set; }
    }


}
