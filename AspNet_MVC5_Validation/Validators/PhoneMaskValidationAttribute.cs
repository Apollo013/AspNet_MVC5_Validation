using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace AspNet_MVC5_Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PhoneMaskValidationAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _mask;
        private ValidationResult errResult = new ValidationResult("");

        public string Mask { get { return _mask; } }

        public PhoneMaskValidationAttribute(string mask)
        {
            if (String.IsNullOrWhiteSpace(mask))
            {
                throw new ArgumentNullException("Please specifiy a mask for number");
            }
            _mask = mask;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var number = (String)value;
            return String.IsNullOrWhiteSpace(number) ? new ValidationResult("No number supplied") : MatchesMask(number) ? ValidationResult.Success : errResult;
        }


        public override bool IsValid(object value)
        {
            var number = (String)value;
            return String.IsNullOrWhiteSpace(number) ? false : MatchesMask(number);
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ValidationType = "phonemaskvalidation";
            rule.ValidationParameters["mask"] = _mask;
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            yield return rule;
        }


        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _mask);
        }

        private bool MatchesMask(string number)
        {
            // Check Length
            var len = number.Length;
            if (_mask.Length != len)
            {
                errResult.ErrorMessage = "Incorrect Length";
                return false;
            }

            // Check each character
            for (int i = 0; i < len; i++)
            {
                // Check didgits
                if (_mask[i] == 'd' && Char.IsDigit(number[i]) == false)
                {
                    errResult.ErrorMessage = "No digit supplied";
                    return false;
                }

                // Check dashes
                if (_mask[i] == '-' && number[i] != '-')
                {
                    errResult.ErrorMessage = "No dash supplied";
                    return false;
                }
            }
            return true;
        }
    }
}