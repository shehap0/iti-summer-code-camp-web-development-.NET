namespace dotNetSumMVCD03.ViewModel
{
    public class EmployeeReadVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; } = default!;
    }
}
