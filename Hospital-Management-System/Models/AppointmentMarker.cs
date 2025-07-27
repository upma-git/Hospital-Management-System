using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class AppointmentMarker
    {
        [Key]
        public int appointment_marker_id { get; set; }
        public int Appointment_Id { get; set; }
        public int Doctor_Id { get; set; }
        public int Patient_Id { get; set; }
        public string Information { get; set; }
        public DateTime Appointment_Date { get; set; }
        public string status { get; set; }
    }
}