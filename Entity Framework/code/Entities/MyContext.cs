using EFDay1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay1.Entities
{
    // EF Runtime
    public class MyContext :DbContext
    {
        // Configure EF Runtime to connect to Specific DB

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=EFDay1; Trusted_Connection=true; Encrypt=false;");
        }

        // Fluent Api

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //Build Containers for classes that will be Entity in Datebase
        // DbSet
        // virtual ==> Lazy Loading  ==> default in EF core

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Department> Departments { get; set; }


    }
}
