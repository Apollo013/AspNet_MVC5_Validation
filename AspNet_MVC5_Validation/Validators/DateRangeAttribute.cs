using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace AspNet_MVC5_Validation
{
    public class DateRangeAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DateFormat = "dd/MM/yyyy";

        public DateTime MinDate { get; private set; }
        public DateTime MaxDate { get; private set; }

        public DateRangeAttribute(string minDate, string maxDate)
        {
            MinDate = ParseDate(minDate);
            MaxDate = ParseDate(maxDate);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is DateTime))
            {
                return new ValidationResult("Please provide a valid date");
            }

            DateTime dateValue = (DateTime)value;
            if (!(MinDate <= dateValue && dateValue <= MaxDate))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"'{name}' must be a date between {MinDate:d} and {MaxDate:d}.";
        }

        private static DateTime ParseDate(string dateValue)
        {
            return DateTime.ParseExact(dateValue, DateFormat, CultureInfo.InvariantCulture);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ValidationType = "daterange";
            rule.ValidationParameters["mindate"] = MinDate.ToString("dd/MM/yyyy");
            rule.ValidationParameters["maxdate"] = MaxDate.ToString("dd/MM/yyyy");
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            yield return rule;
        }
    }
}
