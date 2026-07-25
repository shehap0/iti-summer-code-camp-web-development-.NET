using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace problem_2.Model
{
    public class SalesOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Num { get; set; }
        public string Location { get; set; }

        public virtual HashSet<Property> Properties { get; set; } = new HashSet<Property>();
        [InverseProperty("SalesOffice")]
        public virtual HashSet<Employee> Employees { get; set; } = new HashSet<Employee>();
        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }
        [InverseProperty("ManagedSalesOffice")]
        public virtual Employee Manager { get; set; }

        public override string ToString() => $"{Num}, {Location}";
    }
}
