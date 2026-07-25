using EFDay2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2.Entites
{
    // EF Runtime
    public class MyContext : DbContext
    {
        // Configure EF Runtime to connect to Specific DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         

            optionsBuilder.UseSqlServer("Server=.; Database=EFDay2; Trusted_Connection=true; Encrypt=false;");


        }

        // Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Course Model

            #region Old Technique



            // modelBuilder.Entity<Course>().HasKey(C => C.Crs_Id);  // PK

            // modelBuilder.Entity<Course>().Ignore(C => C.RegisterTime);  // Not Mapped

            //modelBuilder
            //    .Entity<Course>()
            //    .Property(C => C.Name)
            //    .IsRequired()
            //    .HasMaxLength(50)
            //    .IsUnicode();



            #endregion

        //    modelBuilder.Entity<Course>(crsConfig =>
        //    {

        //        crsConfig.HasKey(C => C.Crs_Id);
        //        crsConfig.Property(p => p.Name)
        //                 .IsRequired();
        //        crsConfig.Ignore(C => C.RegisterTime);

        //    });


        //    //Seed data
        //    modelBuilder.Entity<Course>().HasData(
        //        new Course { Crs_Id = 1, Name = "Math 101", RegisterTime = DateTime.Now },
        //        new Course { Crs_Id = 2, Name = "Science 101", RegisterTime = DateTime.Now },
        //        new Course { Crs_Id = 3, Name = "History 101", RegisterTime = DateTime.Now }
        //    );

        //    base.OnModelCreating(modelBuilder);
       }
         

        //Build Containers for classes that will be Entity in Datebase
        // DbSet
        // virtual ==> Lazy Loading  ==> default in EF core
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
      

    }
}
