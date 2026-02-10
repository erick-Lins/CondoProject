using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace CondoProj.DataAnnotation
{
    public class CustomDateValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var dateValue = value as DateTime? ?? new DateTime();

            if (dateValue.Date > DateTime.Now.Date)
            {
                return new ValidationResult("The date cannot be set in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
