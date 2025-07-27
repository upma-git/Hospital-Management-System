using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
    }
}