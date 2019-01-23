using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_ST_MeterParamInfo")]
    public class ParamInfo
    {
        [Key]
        [Column(name: "F_MeterParamID",TypeName ="varchar(16)")]
        public string MeterParamId { get; set; }

        [Column(name: "F_MeterProdID",TypeName="char(12)")]
        public string MeterProdID { get; set; }

        [Column(name: "F_MeterParaCode",TypeName = "varchar(20)")]
        public string MeterParaCode { get; set; }

        [Column(name: "F_MeterParamName", TypeName = "varchar(48)")]
        public string MeterParamName { get; set; }

        [Column(name: "F_ChangeRate",TypeName = "numeric(18,4)")]
        public decimal ChangeRate { get; set; }

        [StringLength(1)]
        [Column(name: "F_ValueType",TypeName ="char(1)")]
        public string ValueType { get; set; }

        [Column(name:"F_State",TypeName ="smallint")]
        public short State { get; set; }

        [Column(name: "F_IsEnergyValue",TypeName ="bit")]
        public bool IsEnergyValue { get; set; }

        [Column(name: "F_IsTimeBlock", TypeName = "bit")]
        public bool IsTimeBlock { get; set; }

        [Column(name: "F_Price",TypeName ="decimal(10,4)")]
        public decimal Price { get; set; }

        [Column(name: "F_ParamUnit", TypeName = "nvarchar(20)")]
        public string ParamUnit { get; set; }
    }
}
