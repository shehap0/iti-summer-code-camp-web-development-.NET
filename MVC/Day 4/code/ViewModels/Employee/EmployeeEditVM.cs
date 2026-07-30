using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotNetSumMVCD04.ViewModels.Employee
{
    public class EmployeeEditVM
    {
        #region
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        #endregion

        #region Send To Form
        public List<SelectListItem>? Departments { get; set; }
        #endregion
    }
}
