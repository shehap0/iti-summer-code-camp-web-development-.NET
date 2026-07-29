using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotNetSumMVCD03.ViewModel
{
    public class EmployeeCreateVM
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }

        public List<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
    }
}
