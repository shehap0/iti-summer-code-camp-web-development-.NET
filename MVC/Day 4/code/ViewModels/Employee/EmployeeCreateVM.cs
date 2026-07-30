using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using dotNetSumMVCD04.AttributeValidators;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotNetSumMVCD04.ViewModels.Employee
{
    public class EmployeeCreateVM
    {
        #region Get From Form
        [DisplayName("Full Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)] // 3 Chars ~ 40 Chars
        public string? Name { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string? Address { get; set; }
        [Range(15,60)]
        [Required]
        public int Age { get; set; }
        [Range(1000,40000)]
        [Required]
        public decimal Salary { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password Must be Matched")]
        [Required]
        public string? ConfirmPassword { get; set; }
        [DisplayName("Date OF Birth")]
        [DataType(DataType.Date)]
        [MinAge(20)]
        public DateOnly DOB { get; set; }
        public int DepartmentId { get; set; }
        #endregion


        #region Send To Form
        public List<SelectListItem>? Departments { get; set; }
        #endregion
    }
}
