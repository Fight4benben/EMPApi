using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_SYS_Users")]
    public class User
    {
        [Key]
        [Column(name:"F_UserID",TypeName ="int")]
        public int UserID { get; set; }

        [Column(name:"F_UserName",TypeName ="varchar(50)")]
        public string UserName { get; set; }

        [Column(name:"F_Password",TypeName ="varchar(100)")]
        public string Password { get; set; }

        [Column(name:"F_Authorities",TypeName = "smallint")]
        public short? Authorities { get; set; }

        [Column(name:"F_Manager",TypeName ="bit")]
        public bool Manager { get; set; }

        [Column(name:"F_UserGroupID",TypeName ="int")]
        public int UserGroupID { get; set; }

    }
}
