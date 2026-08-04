using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services;
using Project.ViewModels;

namespace Project.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public ProductController(ApplicationDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<IActionResult> Index(string? search)
    {
        var query = _context.Products.Include(p => p.Category).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();
            query = query.Where(p => p.Title.Contains(search) || p.Category!.Name.Contains(search));
        }

        var products = await query.OrderByDescending(p => p.Id).ToListAsync();

        var viewModel = new ProductListViewModel
        {
            Products = products.Select(p => new ProductViewModel
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
            }).ToList(),
            SearchTerm = search ?? string.Empty
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var viewModel = new ProductFormViewModel
        {
            ExpiryDate = DateTime.Today.AddMonths(6),
            Categories = await GetCategoriesAsync()
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categories = await GetCategoriesAsync();
            return View(viewModel);
        }

        string? imagePath = null;
        if (viewModel.Image != null)
        {
            try
            {
                imagePath = await ImageHandler.SaveAsync(viewModel.Image, _environment.WebRootPath);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(ProductFormViewModel.Image), ex.Message);
                viewModel.Categories = await GetCategoriesAsync();
                return View(viewModel);
            }
        }

        var product = new Product
        {
            Title = viewModel.Title.Trim(),
            Description = viewModel.Description.Trim(),
            Price = viewModel.Price,
            Count = viewModel.Count,
            ExpiryDate = viewModel.ExpiryDate,
            CategoryId = viewModel.CategoryId,
            ImagePath = imagePath
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        TempData["Success"] = $"Product \"{product.Title}\" was created successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        var viewModel = new ProductFormViewModel
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Count = product.Count,
            ExpiryDate = product.ExpiryDate,
            CategoryId = product.CategoryId,
            ExistingImagePath = product.ImagePath,
            Categories = await GetCategoriesAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductFormViewModel viewModel)
    {
        if (id != viewModel.Id)
            return BadRequest();

        if (!ModelState.IsValid)
        {
            viewModel.Categories = await GetCategoriesAsync();
            return View(viewModel);
        }

        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        string? newImagePath = product.ImagePath;
        if (viewModel.Image != null)
        {
            try
            {
                newImagePath = await ImageHandler.SaveAsync(viewModel.Image, _environment.WebRootPath);
                ImageHandler.Delete(_environment.WebRootPath, product.ImagePath);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(nameof(ProductFormViewModel.Image), ex.Message);
                viewModel.Categories = await GetCategoriesAsync();
                return View(viewModel);
            }
        }

        product.Title = viewModel.Title.Trim();
        product.Description = viewModel.Description.Trim();
        product.Price = viewModel.Price;
        product.Count = viewModel.Count;
        product.ExpiryDate = viewModel.ExpiryDate;
        product.CategoryId = viewModel.CategoryId;
        product.ImagePath = newImagePath;

        await _context.SaveChangesAsync();

        TempData["Success"] = $"Product \"{product.Title}\" was updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound();

        return View(new ProductViewModel
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Count = product.Count,
            ExpiryDate = product.ExpiryDate,
            ImagePath = product.ImagePath,
            CategoryName = product.Category?.Name ?? string.Empty
        });
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        ImageHandler.Delete(_environment.WebRootPath, product.ImagePath);

        TempData["Success"] = $"Product \"{product.Title}\" was deleted successfully.";
        return RedirectToAction(nameof(Index));
    }

    private async Task<List<SelectListItem>> GetCategoriesAsync()
    {
        return await _context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToListAsync();
    }
}
