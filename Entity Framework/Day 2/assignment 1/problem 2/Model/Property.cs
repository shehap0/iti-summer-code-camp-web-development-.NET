using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace problem_2.Model
{
    public class Property
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [ForeignKey("SalesOffice")]
        public int? SalesOfficeNum { get; set; }

        public virtual SalesOffice SalesOffice { get; set; }
        public virtual HashSet<PropertyOwner> PropertyOwners { get; set; } = new HashSet<PropertyOwner>();

        public override string ToString() => $"{Id}, {Address}, {City}, {State}, {Zip}";
    }
}
