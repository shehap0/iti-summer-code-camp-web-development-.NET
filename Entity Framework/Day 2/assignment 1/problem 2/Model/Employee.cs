using System.ComponentModel.DataAnnotations.Schema;

namespace problem_2.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("SalesOffice")]
        public int? SalesOfficeNum { get; set; }
        
        [InverseProperty("Employees")]
        public virtual SalesOffice SalesOffice { get; set; }
        [InverseProperty("Manager")]
        public virtual SalesOffice ManagedSalesOffice { get; set; }

        public override string ToString() => $"{Id}, {Name}";
    }
}
