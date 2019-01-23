using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Entity.PlainClass
{
    public class BuildInfo
    {
        public string BuildId { get; set; }

        public string BuildName { get; set; }

        public string BuildAddr { get; set; }

        public decimal? BuildLong { get; set; }

        public decimal? BuildLat { get; set; }
    }
}
