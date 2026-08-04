using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Categories
            .Include(c => c.Products)
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync();

        var viewModel = categories.Select(c => new CategoryViewModel
        {
            Id = c.Id,
            Name = c.Name,
            ProductCount = c.Products.Count
        }).ToList();

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CategoryFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        if (await _context.Categories.AnyAsync(c => c.Name == viewModel.Name.Trim()))
        {
            ModelState.AddModelError(nameof(CategoryFormViewModel.Name), "A category with this name already exists.");
            return View(viewModel);
        }

        var category = new Category { Name = viewModel.Name.Trim() };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        TempData["Success"] = $"Category \"{category.Name}\" was created successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        return View(new CategoryFormViewModel { Id = category.Id, Name = category.Name });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CategoryFormViewModel viewModel)
    {
        if (id != viewModel.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(viewModel);

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        if (await _context.Categories.AnyAsync(c => c.Id != id && c.Name == viewModel.Name.Trim()))
        {
            ModelState.AddModelError(nameof(CategoryFormViewModel.Name), "A category with this name already exists.");
            return View(viewModel);
        }

        category.Name = viewModel.Name.Trim();
        await _context.SaveChangesAsync();

        TempData["Success"] = $"Category \"{category.Name}\" was updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories
            .Include(c => c.Products)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
            return NotFound();

        return View(new CategoryViewModel
        {
            Id = category.Id,
            Name = category.Name,
            ProductCount = category.Products.Count
        });
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
            return NotFound();

        if (category.Products.Count > 0)
        {
            TempData["Error"] = $"Cannot delete \"{category.Name}\" because it has {category.Products.Count} product(s).";
            return RedirectToAction(nameof(Index));
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        TempData["Success"] = $"Category \"{category.Name}\" was deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
