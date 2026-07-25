using Microsoft.EntityFrameworkCore;

namespace problem_2.Model
{
    [PrimaryKey(nameof(PropertyId), nameof(OwnerId))]
    public class PropertyOwner
    {
        public int PropertyId { get; set; }
        public int OwnerId { get; set; }
        public double PercentOwned { get; set; }

        public virtual Property Property { get; set; }
        public virtual Owner Owner { get; set; }

        public override string ToString() => $"Property {PropertyId}, Owner {OwnerId}, {PercentOwned}%";
    }
}
