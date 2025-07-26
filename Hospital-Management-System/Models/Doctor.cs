using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{

    public class Doctor
    {
        [Key]
        public int doctor_id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string doctor_name { get; set; }
        [Required(ErrorMessage = "Qualification is required")]
        public string doctor_qualification { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int doctor_age { get; set; }
        [Required(ErrorMessage = "Specialization is required")]
        public string specialization { get; set; }
    }
}