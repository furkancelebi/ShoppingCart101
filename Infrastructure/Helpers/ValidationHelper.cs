using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Infrastructure.Helpers
{
    public static class ValidationHelper
    {
        public static void Validate(object validationObject)
        {
            ValidationContext context = new ValidationContext(validationObject, serviceProvider: null, items: null);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(validationObject, context, validationResults, true);

            if (!isValid)
            {
                throw new CustomValidationException(validationResults);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class IsPositiveAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (double)(value ?? -1) >= 0;
        }
    }

    [Serializable]
    public class CustomValidationException : Exception
    {
        public CustomValidationException()
        {

        }

        public CustomValidationException(ICollection<ValidationResult> validationResults)
            : base(validationResults.Select(x => x.ErrorMessage).Aggregate((a, b) => a + ";" + b))
        {

        }
    }
}