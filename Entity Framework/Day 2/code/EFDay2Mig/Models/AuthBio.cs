using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2Mig.Models
   
{
    //One TO One Relationship
    public class AuthBio //TOT
    {
        public int Id { get; set; }
        public string Biography { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
