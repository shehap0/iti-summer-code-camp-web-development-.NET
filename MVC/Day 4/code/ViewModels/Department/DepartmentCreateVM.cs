using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotNetSumMVCD04.ViewModels.Department
{
    public class DepartmentCreateVM
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        //[DisplayName("Hamada")]
        public string? Name { get; set; }
    }
}
