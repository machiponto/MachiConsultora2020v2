using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LoginModel
    {
        [Required]
        public string usr { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public string SessionID { get; set; }

    }
}