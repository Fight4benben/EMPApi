using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_ST_CalcFormula")]
    public class CalcFormula
    {
        [Key]
        [Column(name:"F_FormulaID",TypeName ="char(14)")]
        public string FormulaID { get; set; }

        [Column(name: "F_BuildID")]
        public string BuildId { get; set; }

        [Column(name: "F_EnergyItemCode", TypeName = "char(5)")]
        public string EnergyItemCode { get; set; }

        [Column(name: "F_FormulaName",TypeName ="varchar(48)")]
        public string FormulaName { get; set; }

        [Column("F_FormulaExp")]
        public string FormulaExp { get; set; }

        [Column("F_State")]
        public int F_State { get; set; }
    }
}
