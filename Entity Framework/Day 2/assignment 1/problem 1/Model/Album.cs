using System;
using System.Collections.Generic;

namespace problem_1.Model
{
    public class Album
    {
        public int Id { get; set; }
        public DateTime CrDate { get; set; }
        public string Title { get; set; }
        public int MusicianId { get; set; }

        public virtual Musician Musician { get; set; }
        public virtual HashSet<Song> Songs { get; set; } = new HashSet<Song>();

        public override string ToString() => $"{Id}, {Title}, {CrDate}";
    }
}
