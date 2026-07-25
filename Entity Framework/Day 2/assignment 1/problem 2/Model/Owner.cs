using System.Collections.Generic;

namespace problem_2.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual HashSet<PropertyOwner> PropertyOwners { get; set; } = new HashSet<PropertyOwner>();

        public override string ToString() => $"{Id}, {Name}";
    }
}
