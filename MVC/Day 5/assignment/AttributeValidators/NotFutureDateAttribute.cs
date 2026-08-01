using System.ComponentModel.DataAnnotations;

namespace assignment.AttributeValidators
{
    public class NotFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Expiry date is required.");
            }

            if (!(value is DateOnly expiryDate))
            {
                return new ValidationResult("Wrong format.");
            }

            var today = DateOnly.FromDateTime(DateTime.Now);

            if (expiryDate > today)
            {
                return new ValidationResult("Expiry date cannot be in the future.");
            }

            return ValidationResult.Success!;
        }
    }
}
