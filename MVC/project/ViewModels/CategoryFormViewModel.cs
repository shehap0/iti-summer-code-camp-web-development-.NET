using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels;

public class CategoryFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 60 characters.")]
    [Display(Name = "Category Name")]
    public string Name { get; set; } = string.Empty;
}
