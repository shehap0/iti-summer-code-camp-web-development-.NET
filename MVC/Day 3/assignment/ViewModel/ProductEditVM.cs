using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment.ViewModel
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
