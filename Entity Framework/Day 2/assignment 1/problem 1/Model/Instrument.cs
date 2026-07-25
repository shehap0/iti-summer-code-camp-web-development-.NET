using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace problem_1.Model
{
    public class Instrument
    {
        [Key]
        public string Name { get; set; }
        public string Key { get; set; }

        public virtual HashSet<Musician> Musicians { get; set; } = new HashSet<Musician>();

        public override string ToString() => $"{Name}, {Key}";
    }
}
