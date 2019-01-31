using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_ST_CalcFormulaMeter")]
    public class CalcFormulaMeter
    {
        [Key]
        [Column("F_EntryID")]
        public int EntryID { get; set; }

        [Column("F_FormulaID")]
        public string FormulaID { get; set; }

        [Column("F_MeterID")]
        public string MeterID { get; set; }

        [Column("F_Operator")]
        public string Operator { get; set; }

        [Column("F_Rate")]
        public decimal Rate { get; set; }
    }
}
