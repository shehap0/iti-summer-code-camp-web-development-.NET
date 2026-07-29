using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment.ViewModel
{
    public class ProductCreateVM
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
