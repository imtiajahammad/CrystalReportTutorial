using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;










namespace CrystalReportTutorial.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("SqlConnection")
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }
    }
}


















