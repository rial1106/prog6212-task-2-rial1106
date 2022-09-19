using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    internal class NumberOfWeeksValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int numberOfWeeks;
            try
            {
                numberOfWeeks = int.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not a valid number!");
            }
            if (numberOfWeeks < 0)
            {
                return new ValidationResult(false, "A semester can not last a negative number of weeks!");
            }
            if (numberOfWeeks == 0)
            {
                return new ValidationResult(false, "A semester can not last 0 weeks!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
