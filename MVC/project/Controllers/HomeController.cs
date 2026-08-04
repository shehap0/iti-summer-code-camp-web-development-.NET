using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var featured = await _context.Products
            .Include(p => p.Category)
            .OrderByDescending(p => p.Id)
            .Take(8)
            .ToListAsync();

        var viewModel = new HomeIndexViewModel
        {
            Categories = await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count
                })
                .OrderBy(c => c.Name)
                .ToListAsync(),
            FeaturedProducts = featured.Select(p => MapToViewModel(p)).ToList()
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Products(string? category, string? search)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(p => p.Category!.Name == category);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();
            query = query.Where(p =>
                p.Title.Contains(search) ||
                p.Description.Contains(search) ||
                p.Category!.Name.Contains(search));
        }

        var products = await query
            .OrderByDescending(p => p.Id)
            .ToListAsync();

        var viewModel = new ProductListViewModel
        {
            Products = products.Select(p => MapToViewModel(p)).ToList(),
            Categories = await _context.Categories
                .OrderBy(c => c.Name)
                .Select(c => c.Name)
                .ToListAsync(),
            SelectedCategory = category ?? string.Empty,
            SearchTerm = search ?? string.Empty
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound();

        var related = await _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
            .OrderByDescending(p => p.Id)
            .Take(4)
            .ToListAsync();

        var viewModel = new ProductDetailsViewModel
        {
            Product = MapToViewModel(product),
            RelatedProducts = related.Select(p => MapToViewModel(p)).ToList()
        };

        return View(viewModel);
    }

    private static ProductViewModel MapToViewModel(Product p)
    {
        return new ProductViewModel
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Price = p.Price,
            Count = p.Count,
            ExpiryDate = p.ExpiryDate,
            ImagePath = p.ImagePath,
            CategoryId = p.CategoryId,
            CategoryName = p.Category?.Name ?? string.Empty,
            IsExpired = p.ExpiryDate.Date < DateTime.Today
        };
    }
}
