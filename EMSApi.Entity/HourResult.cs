using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_MC_MeterHourResult")]
    public class HourResult
    {
        [Column(name: "F_MeterID")]
        public string MeterId { get; set; }

        [Column(name: "F_MeterParamID")]
        public string MeterParamId { get; set; }

        [Column(name: "F_StartHour", TypeName = "smalldatetime")]
        public DateTime StartHour { get; set; }

        [Column(name: "F_EndHour", TypeName = "smalldatetime")]
        public DateTime EndHour { get; set; }

        [Column(name: "F_Value", TypeName = "numeric(18, 4)")]
        public decimal Value { get; set; }
    }
}
