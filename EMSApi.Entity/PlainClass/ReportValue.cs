using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Entity.PlainClass
{
    public class ReportValue
    {
        public string Id { get; set; }

        public string Name { get; set;}

        public DateTime Time { get; set; }

        public decimal Value { get; set; }
    }
}
