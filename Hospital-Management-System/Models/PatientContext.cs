using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class PatientContext : DbContext
    {
      public DbSet<Patient> Patients { get; set; }
    }
}