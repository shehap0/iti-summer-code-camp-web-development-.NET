namespace dotNetSumMVCD02.ViewModels
{
    public class EmployeeReadVM
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public decimal Score { get; set; }
        public string UniqName { get; set; }
    }
}
