namespace assignment.ViewModels.Product
{
    public class ProductReadVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public string? ImageURL { get; set; }
        public string? Category { get; set; }
    }
}
