using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using assignment.AttributeValidators;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment.ViewModels.Product
{
    public class ProductEditVM
    {
        public int Id { get; set; }

        [DisplayName("Product Title")]
        [Required]
        public string? Title { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Price")]
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [DisplayName("Count")]
        [Required]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        [DisplayName("Expiry Date")]
        [DataType(DataType.Date)]
        [Required]
        [NotFutureDate]
        public DateOnly ExpiryDate { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public List<SelectListItem>? Categories { get; set; }
    }
}
