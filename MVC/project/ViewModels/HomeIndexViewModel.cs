namespace Project.ViewModels;

public class HomeIndexViewModel
{
    public List<CategoryViewModel> Categories { get; set; } = new();
    public List<ProductViewModel> FeaturedProducts { get; set; } = new();
}
