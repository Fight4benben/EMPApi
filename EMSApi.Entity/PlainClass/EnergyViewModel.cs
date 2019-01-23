using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Entity.PlainClass
{
    public class EnergyViewModel
    {

    }

    public class CompareValue
    {
        public string TypeName { get; set; }
        public decimal? NowTimeValue { get; set; }
        public decimal? LastTimeValue { get; set; }
        public decimal? LastSameTimeValue { get; set; }
    }


}
