using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Entity.PlainClass
{
    public class UserBuildRelationship
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string BuildId { get; set; }
        public string BuildName { get; set; }
    }
}
