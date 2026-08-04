using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
    [Display(Name = "Product Title")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1,000,000.")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Count is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Count cannot be negative.")]
    [Display(Name = "Available Quantity")]
    public int Count { get; set; }

    [Required(ErrorMessage = "Expiry date is required.")]
    [DataType(DataType.Date)]
    [Display(Name = "Expiry Date")]
    public DateTime ExpiryDate { get; set; }

    [Display(Name = "Image")]
    public string? ImagePath { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    [NotMapped]
    public bool IsExpired => ExpiryDate.Date < DateTime.Today;
}
