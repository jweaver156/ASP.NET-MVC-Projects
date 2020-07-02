using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmployeeApplication.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeDB")
        { }
        public DbSet<Employee> Employees { get; set; }
    }
}