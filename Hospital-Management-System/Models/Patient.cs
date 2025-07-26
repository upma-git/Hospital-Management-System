using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{  
    public class Patient
    {
        [Key]
        public int Patient_id { get; set; }
        [Required(ErrorMessage = "Patient Name is required")]
        public string Patient_name { get; set; }
        [Required(ErrorMessage ="Add here the illness")]
        public string Illness { get; set; }
        [Required(ErrorMessage ="Patient age is required")]
        public int Patient_age { get; set; }
        [Required(ErrorMessage ="Add your Blood Group")]
        public string Blood_group { get; set; }
    }
}