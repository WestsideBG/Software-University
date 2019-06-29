using System;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Data.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string propertyName;

        public XorAttribute(string propertyName)
        {
            this.propertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetAttribute = validationContext.ObjectType.GetProperty(propertyName).GetValue(validationContext.ObjectInstance);

            if ((value == null) ^ (targetAttribute == null))
            {
                return new ValidationResult("The two properties must have opposite values!");
            }

            return ValidationResult.Success;
        }
    }
}