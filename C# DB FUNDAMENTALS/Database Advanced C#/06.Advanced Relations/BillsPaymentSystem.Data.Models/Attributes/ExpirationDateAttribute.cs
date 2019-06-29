using System;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Data.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var expirationDate = (DateTime) value;
            var currentDateTime = DateTime.Now;

            if (currentDateTime > expirationDate)
            {
                return new ValidationResult("Card is expired!");
            }

            return ValidationResult.Success;
        }
    }
}