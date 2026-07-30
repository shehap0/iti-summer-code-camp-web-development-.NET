using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment.ViewModels.Category
{
    public class CategoryEditVM
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required]
        public string? Name { get; set; }
    }
}
