using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmoothCoffeeRoastersCodeFirst.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SmoothCoffeeRoastersCodeFirst.DataAccessLayer
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext() : base("CoffeeContext")
        {
        }

        public DbSet<MasterRoaster> MasterRoasters { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}