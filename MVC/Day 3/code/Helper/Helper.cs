using dotNetSumMVCD03.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotNetSumMVCD03.Helper
{
    public static class Helper
    {
        static MyDbContext db = new MyDbContext();
        public static List<SelectListItem> GetDeptsDropDown()
        {
            return db.Departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
        }
    }
}
