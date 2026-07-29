using dotNetSumMVCD03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotNetSumMVCD03.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Models.Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(d => d.Department)
                    .WithMany(e => e.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .IsRequired();
        }
    }
}
