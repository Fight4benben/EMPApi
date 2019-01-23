using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_BD_BuildBaseInfo")]
    public class Build
    {
        [Key]
        [Column(name:"F_BuildID",TypeName ="VARCHAR(16)")]
        public string BuildId { get; set; }

        [StringLength(48)]
        [Column(name:"F_BuildName",TypeName ="VARCHAR(48)")]
        public string BuildName { get; set; }

        [Column(name: "F_DataCenterID", TypeName = "char(6)")]
        public string DataCenterId { get; set; }

        [StringLength(16)]
        [Column(name: "F_AliasName", TypeName = "VARCHAR(16)")]
        public string AliasName { get; set; }

        [StringLength(80)]
        [Column(name: "F_BuildOwner",TypeName ="VARCHAR(80)")]
        public string BuildOwner { get; set; }

        [Column(name: "F_State", TypeName = "smallint")]
        public short State { get; set; }

        [Column(name: "F_DistrictCode", TypeName = "CHAR(6)")]
        public string DistrictCode { get; set; }

        [StringLength(80)]
        [Column(name: "F_BuildAddr", TypeName = "VARCHAR(80)")]
        public string BuildAddr { get; set; }

        [Column(name: "F_BuildLong", TypeName = "numeric(18, 4)")]
        public decimal? BuildLong { get; set; }

        [Column(name: "F_BuildLat", TypeName = "numeric(18, 4)")]
        public decimal? BuildLat { get; set; }

        [Column(name: "F_BuildYear", TypeName = "int")]
        public int BuildYear { get; set; }

        [Column(name: "F_DownFloor", TypeName = "int")]
        public int DownFloor { get; set; }

        [Column(name: "F_UpFloor", TypeName = "int")]
        public int UpFloor { get; set; }

        [Column(name: "F_BuildFunc",TypeName = "char(1)")]
        public string BuildFunc { get; set; }

        [Column(name: "F_TotalArea", TypeName = "numeric(18, 4)")]
        public decimal TotalArea { get; set; }

        [Column(name: "F_AirArea", TypeName = "numeric(18, 4)")]
        public decimal AirArea { get; set; }

        [Column(name: "F_HeatArea", TypeName = "numeric(18, 4)")]
        public decimal HeatArea { get; set; }

        //[Column(name: "F_AirType", TypeName = "char(1)")]
        //public string AirType { get; set; }

        //[Column(name: "F_HeatType", TypeName = "char(1)")]
        //public string HeatType { get; set; }

        //[Column(name: "F_BodyCoef", TypeName = "numeric(18, 4)")]
        //public decimal BodyCoef { get; set; }

        //[Column(name: "F_StruType", TypeName = "char(1)")]
        //public string StruType { get; set; }

        //[Column(name: "F_WallMatType", TypeName = "char(1)")]
        //public string WallMatType { get; set; }

        //[Column(name: "F_WallWarmType", TypeName = "char(1)")]
        //public string WallWarmType { get; set; }

        //[Column(name: "F_WallWinType", TypeName = "char(1)")]
        //public string WallWinType { get; set; }

        //[Column(name: "GlassType", TypeName = "char(1)")]
        //public string GlassType { get; set; }

        //[Column(name: "F_WinFrameType", TypeName = "char(1)")]
        //public string WinFrameType { get; set; }

        [Column(name: "F_IsStandard", TypeName ="bit")]
        public bool IsStandard { get; set; }

        [Column(name: "F_DesignDept", TypeName = "VARCHAR(64)")]
        public string DesignDept { get; set; }

        [Column(name: "F_WorkDept", TypeName = "VARCHAR(64)")]
        public string WorkDept { get; set; }

        [Column(name: "F_CreateTime",TypeName ="DATETIME")]
        public DateTime CreateTime { get; set; }

        [Column(name: "F_AcceptDate", TypeName = "DATETIME")]
        public DateTime AcceptDate { get; set; }

        [Column(name: "F_NumberOfPeople",TypeName ="int")]
        public int NumberOfPeople { get; set; }

        [Column(name: "F_SPArea", TypeName = "numeric(18, 4)")]
        public decimal SPArea { get; set; }


        [Column(name: "F_TransCount", TypeName = "int")]
        public int TransCount { get; set; }

        [Column(name: "F_InstallCapacity", TypeName = "int")]
        public int InstallCapacity { get; set; }

        [Column(name: "F_OperateCapacity", TypeName = "int")]
        public int OperateCapacity { get; set; }

        [Column(name: "F_DesignMeters", TypeName = "int")]
        public int DesignMeters { get; set; }
    }
}
