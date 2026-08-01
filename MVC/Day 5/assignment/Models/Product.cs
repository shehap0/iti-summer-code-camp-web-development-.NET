using System.ComponentModel.DataAnnotations;
using assignment.AttributeValidators;

namespace assignment.Models
{
    public class Product
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }
        [DataType(DataType.Date)]
        [NotFutureDate]
        public DateOnly ExpiryDate { get; set; }
        public string? ImageURL { get; set; }
        /*------------------------------------------------------------------*/
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        /*------------------------------------------------------------------*/
    }
}
