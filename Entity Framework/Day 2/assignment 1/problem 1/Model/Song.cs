using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace problem_1.Model
{
    public class Song
    {
        [Key]
        public string Title { get; set; }
        public string Author { get; set; }
        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public virtual HashSet<Musician> Musicians { get; set; } = new HashSet<Musician>();

        public override string ToString() => $"{Title}, {Author}";
    }
}
