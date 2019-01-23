using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_ST_MeterUseInfo")]
    public class Meter
    {
        [Key]
        [Column(name: "F_MeterID")]
        public string MeterId { get; set; }

        [Column(name: "F_BuildID")]
        public string BuildId { get; set; }

        [Column(name: "F_MeterCode", TypeName = "varchar(50)")]
        [StringLength(50)]
        public string MeterCode { get; set; }

        [Column(name: "F_MeterName", TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string MeterName { get; set; }

        [Column(name: "F_MeterProdID", TypeName = "char(12)")]
        public string MeterProdId { get; set; }

        [Column(name: "F_CollectionID")]
        public string CollectionId { get; set; }

        [Column(name: "F_MeterAddr1")]
        public string MeterAddr1 { get; set; }

        [Column(name: "F_MeterAddr2")]
        public string MeterAddr2 { get; set; }

        [Column(name: "F_MeterAddr3")]
        public string MeterAddr3 { get; set; }

        [Column(name: "F_Rate",TypeName ="numeric(18,4)")]
        public decimal Rate { get; set; }

        [Column(name: "F_State",TypeName ="smallint")]
        public short State { get; set; }

        [Column(name: "F_MaxValueOfHour",TypeName = "decimal(12, 2)")]
        public decimal MaxValueOfHour { get; set; }

        [Column(name:"F_DisConnect",TypeName ="bit")]
        public bool DisConnect { get; set; }

        [Column(name:"F_DisConnectTime",TypeName ="datetime")]
        public DateTime DisConnectTime { get; set; }
    }
}
