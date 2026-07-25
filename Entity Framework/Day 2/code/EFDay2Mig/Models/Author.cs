using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2Mig.Models
{
    //One TO One Relationship
    public class Author // PATR
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual AuthBio AuthBio { get; set; }
    }
}
