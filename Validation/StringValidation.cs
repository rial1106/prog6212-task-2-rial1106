using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    internal class StringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str;
            try
            {
                str = value.ToString();
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not valid!");
            }
            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "You have not entered any value!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
