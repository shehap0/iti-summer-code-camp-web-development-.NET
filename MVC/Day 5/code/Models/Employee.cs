using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreD03.Models
{
    // DB Model
    // Domain Model
    // Arc 
    // DAL BL PL
    public class Employee
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }
        //[MinLength] // Later MVC // Validation VM
        public required string Name { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? ImageURL { get; set; }
        public DateOnly DOB { get; set; }
        /*------------------------------------------------------------------*/
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        /*------------------------------------------------------------------*/
    }
}
