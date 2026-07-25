using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace problem_1.Model
{
    public class Musician
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }


        public virtual HashSet<Instrument> Instruments { get; set; } = new HashSet<Instrument>();

        public virtual HashSet<Song> Songs { get; set; } = new HashSet<Song>();

        public virtual HashSet<Album> Albums { get; set; } = new HashSet<Album>();
        public override string ToString() => $"{Id}, {Name}, {Street}, {City}, {Phone}";
    }
}
