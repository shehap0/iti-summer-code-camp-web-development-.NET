using System.ComponentModel.DataAnnotations;

namespace dotNetSumMVCD04.AttributeValidators
{
    public class MinAgeAttribute : ValidationAttribute
    {
        //WF => Legacy => Still working on MVC
        //CRM => Customer Realtionship Management
        private readonly int _minAge;
        public MinAgeAttribute(int mAge)
        {
            _minAge = mAge;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Age is required.");
            }

            if (!(value is DateOnly dob))
            {
                return new ValidationResult("Wrong Format");
            }

            int age = DateTime.Now.Year - dob.Year;

            if (age < _minAge)
            {
                return new ValidationResult($"Age Must be Greater Than {_minAge}");
            }

            return ValidationResult.Success;
        }
    }
}
