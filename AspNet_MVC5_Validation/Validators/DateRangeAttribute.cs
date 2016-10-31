using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Web.Mvc;

namespace AspNet_MVC5_Validation
{
    public class DateRangeAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DateFormat = "dd/MM/yyyy";
        private const string DefaultErrorMessage = "'{0}' must be a date between {1:d} and {2:d}.";

        public DateTime MinDate { get; private set; }
        public DateTime MaxDate { get; private set; }

        public DateRangeAttribute(string minDate, string maxDate) : base(DefaultErrorMessage)
        {
            MinDate = ParseDate(minDate);
            MaxDate = ParseDate(maxDate);
        }

        public override bool IsValid(object value)
        {
            if (value == null || !(value is DateTime))
            {
                return false;
            }
            DateTime dateValue = (DateTime)value;
            Debug.WriteLine($"{dateValue} - {MinDate} - {MaxDate}");
            return MinDate <= dateValue && dateValue <= MaxDate;
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
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());

            //rule.ValidationParameters.Add("datefield", metadata.PropertyName);
            rule.ValidationParameters["mindate"] = MinDate.ToString("dd/MM/yyyy");
            rule.ValidationParameters["maxdate"] = MaxDate.ToString("dd/MM/yyyy");

            rule.ValidationType = "daterange";
            yield return rule;

        }
    }

    /*
     * public string StartDate { get; set; } = DateTime.MinValue.ToShortDateString();
        public string EndDate { get; set; } = DateTime.MaxValue.ToShortDateString();

        public DateRangeAttribute()
        {
            ErrorMessage = $"The date must be in the range {StartDate} - {EndDate}";
        }

        public override bool IsValid(object value)
        {
            if (String.IsNullOrWhiteSpace(StartDate) || String.IsNullOrWhiteSpace(EndDate) || value == null)
            {
                return false;
            }

            var start = Convert.ToDateTime(StartDate);
            var end = Convert.ToDateTime(EndDate);
            var date = Convert.ToDateTime(value);

            if (date >= start && date <= end)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("datefield", metadata.PropertyName);
            rule.ValidationType = "daterangevalidator";
            yield return rule;

    ErrorMessage = errorMessage;
        ValidationType = "rangedate";
 
        ValidationParameters["min"] = minValue.ToString("yyyy/MM/dd");
        ValidationParameters["max"] = maxValue.ToString("yyyy/MM/dd");
        }
     */
}
