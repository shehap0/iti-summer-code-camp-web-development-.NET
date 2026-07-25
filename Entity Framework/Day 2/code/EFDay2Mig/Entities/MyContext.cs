using EFDay2Mig.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2Mig.Entities
{
    public class MyContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=EFDay2Mig; Trusted_Connection=true; Encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Composite PK

            modelBuilder.Entity<Student_Course>().HasKey(p => new {p.StudentId, p.CourseId});

            #endregion
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student_Course> Student_Courses { get; set; }

        public virtual DbSet<AuthBio> AuthBios { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

    }
}
