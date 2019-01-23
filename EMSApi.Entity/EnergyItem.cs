using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_DT_EnergyItemDict")]
    public class EnergyItem
    {
        [Key]
        [Column(name: "F_EnergyItemCode",TypeName ="char(5)")]
        public string EnergyItemCode { get; set; }

        [Column(name: "F_EnergyItemName", TypeName = "varchar(32)")]
        public string  EnergyItemName { get; set; }

        [Column(name: "F_ParentItemCode", TypeName = "varchar(16)")]
        public string ParentItemCode { get; set; }

        [Column(name: "F_EnergyItemType", TypeName = "char(1)")]
        public string EnergyItemType { get; set; }

        [Column(name: "F_EnergyItemUnit", TypeName = "varchar(16)")]
        public string EnergyItemUnit { get; set; }

        [Column(name: "F_EnergyItemUnitCode", TypeName = "varchar(16)")]
        public string EnergyItemUnitCode { get; set; }

        [Column(name: "F_EnergyItemFml", TypeName = "varchar(16)")]
        public string EnergyItemFml { get; set; }

        [Column(name: "F_EnergyItemState",TypeName ="bit")]
        public bool EnergyItemState { get; set; }

    }
}
