using System.IO;

namespace Project.Services;

public static class ImageHandler
{
    private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
    private const long MaxSizeBytes = 5 * 1024 * 1024;

    public static async Task<string?> SaveAsync(IFormFile file, string webRootPath, string subFolder = "products")
    {
        if (file == null || file.Length == 0)
            return null;

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!AllowedExtensions.Contains(extension))
            throw new InvalidOperationException("Only image files (.jpg, .jpeg, .png, .webp, .gif) are allowed.");

        if (file.Length > MaxSizeBytes)
            throw new InvalidOperationException("Image size must not exceed 5 MB.");

        var folder = Path.Combine(webRootPath, "images", subFolder);
        Directory.CreateDirectory(folder);

        var uniqueName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(folder, uniqueName);

        await using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/images/{subFolder}/{uniqueName}";
    }

    public static void Delete(string webRootPath, string? relativePath)
    {
        if (string.IsNullOrEmpty(relativePath))
            return;

        var absolutePath = Path.Combine(webRootPath, relativePath.TrimStart('/'));
        if (File.Exists(absolutePath))
            File.Delete(absolutePath);
    }
}
