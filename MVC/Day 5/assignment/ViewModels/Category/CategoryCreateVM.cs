using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment.ViewModels.Category
{
    public class CategoryCreateVM
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required]
        public string? Name { get; set; }
    }
}
