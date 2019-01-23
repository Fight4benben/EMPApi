using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_ST_CircuitMeterInfo")]
    public class Circuit
    {
        [Key]
        [Column(name: "F_CircuitID")]
        public string CircuitId { get; set; }

        [Column(name: "F_BuildID")]
        public string BuildId { get; set; }

        [Column(name: "F_ParentID")]
        public string ParentId { get; set; }

        [Column(name: "F_MeterID")]
        public string MeterId { get; set; }

        [Column(name: "F_CircuitName",TypeName ="nvarchar(50)")]
        public string CircuitName { get; set; }

        [Column(name: "F_EnergyItemCode", TypeName = "char(5)")]
        public string EnergyItemCode { get; set; }

        [Column(name: "F_EquipmentID", TypeName = "char(4)")]
        public string EquipmentId { get; set; }

        [Column(name: "F_State",TypeName ="smallint")]
        public short F_State { get; set; }

        [Column(name: "F_Number")]
        public string Number { get; set; }

        [Column(name: "F_MainCircuit",TypeName ="bit")]
        public bool MainCircuit { get; set; }

        [Column(name: "F_Solar", TypeName = "bit")]
        public bool Solar { get; set; }

        [Column(name: "F_Maxlimit",TypeName ="numeric(18,4)")]
        public decimal MaxLimit { get; set; }

        [Column(name: "F_Minlimit", TypeName = "numeric(18,4)")]
        public decimal Minlimit { get; set; }

        [Column(name: "F_ItemStatistic", TypeName = "INT")]
        public int ItemStatistic { get; set; }
    }
}
