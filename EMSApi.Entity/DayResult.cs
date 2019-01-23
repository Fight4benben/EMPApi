using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_MC_MeterDayResult")]
    public class DayResult
    {
        [Column(name: "F_MeterID")]
        public string MeterId { get; set; }

        [Column(name: "F_MeterParamID")]
        public string MeterParamId { get; set; }

        [Column(name: "F_StartDay", TypeName = "smalldatetime")]
        public DateTime StarDay { get; set; }

        [Column(name: "F_EndDay", TypeName = "smalldatetime")]
        public DateTime EndDay { get; set; }

        [Column(name: "F_Value",TypeName = "numeric(18, 4)")]
        public decimal Value { get; set; }

        [Column(name: "F_FifteenMaxValue", TypeName = "numeric(18, 4)")]
        public decimal? FifteenMaxValue { get; set; }

        [Column(name: "F_FifteenMaxTime", TypeName = "smalldatetime")]
        public DateTime FifteenMaxTime { get; set; }
    }
}
