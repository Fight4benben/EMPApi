using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMSApi.Entity.PlainClass
{
    public class LoginViewModel
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
