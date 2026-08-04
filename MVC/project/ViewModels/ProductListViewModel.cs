namespace Project.ViewModels;

public class ProductListViewModel
{
    public List<ProductViewModel> Products { get; set; } = new();
    public List<string> Categories { get; set; } = new();
    public string SelectedCategory { get; set; } = string.Empty;
    public string SearchTerm { get; set; } = string.Empty;
}
