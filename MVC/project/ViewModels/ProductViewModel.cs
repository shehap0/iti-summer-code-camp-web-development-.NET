namespace Project.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string? ImagePath { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public bool IsExpired { get; set; }
}
