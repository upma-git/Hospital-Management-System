using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Account
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }
        public string role { get; set; }
    }
}