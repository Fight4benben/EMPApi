using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMSApi.Entity
{
    [Table("T_SYS_User_Buildings")]
    public class UserBuilds
    {

        [Column(name: "F_UserName", TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Column(name: "F_BuildID", TypeName = "VARCHAR(16)")]
        public string BuildId { get; set; }
    }
}
