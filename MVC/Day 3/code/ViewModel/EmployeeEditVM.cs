using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotNetSumMVCD03.ViewModel
{
    public class EmployeeEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public List<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
    }
}
