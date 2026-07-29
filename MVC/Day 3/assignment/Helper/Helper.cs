using assignment.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment.Helper
{
    public static class Helper
    {
        static MyDbContext db = new MyDbContext();
        public static List<SelectListItem> GetCategoriesDropDown()
        {
            return db.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }
    }
}
