using dotNetSumMVCD03.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetSumMVCD03.Data.Context
{
    public class MyDbContext : DbContext
    {
        //public MyDbContext(DbContextOptions options) : base(options)
        //{
        //}

        //protected MyDbContext() : base()
        //{
        //}

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.;DataBase=dotNETSumMVC;Trusted_Connection=true;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeding
            //Enter Data Into Database Creation
            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "MAD" },
                new Department { Id = 2, Name = "UI" },
                new Department { Id = 3, Name = "SD" },
                new Department { Id = 4, Name = "Cloud" },
                new Department { Id = 5, Name = "Network" },
            };

            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Aly Eldean", Age = 25, Salary = 5000, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Abdelrahman", Age = 25, Salary = 5000, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Medhat", Age = 25, Salary = 5000, DepartmentId = 3 },
                new Employee { Id = 4, Name = "Nada", Age = 25, Salary = 5000, DepartmentId = 4 },
                new Employee { Id = 5, Name = "Julia", Age = 25, Salary = 5000, DepartmentId = 5 },
            };

            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Employee>().HasData(employees);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
