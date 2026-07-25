using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;


namespace EFDay2.Model
{

    // Data AnnoutationS
    
    [Table("iTi_Inst")]
    public class Instructor
    {
        [Key]  // + identity
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Not Identity
        public int  Ins_Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(22, 60)]
        
        public int? Age { get; set; }

        // Not required
        public decimal? Salary { get; set; }
        [StringLength(50)]
        [DisplayName("Instructor Address")]
        public string Address { get; set; }

        [RegularExpression(@"^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        [EmailAddress] 
        [StringLength(50)]
        [MinLength(20)]
        [MaxLength(50)]
        public string Email { get; set; }

        [NotMapped]    // DON'T Mapped to DataBase 
        public DateTime? RegisterTime { get; set; } = DateTime.Now;

        [ForeignKey("Department")]
        public int? DeptId {  get; set; }
        public virtual Department Department { get; set; }

    }
}
