using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    internal class HoursStudiedTodayValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double hoursStudiedToday;
            try
            {
                hoursStudiedToday = double.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not a valid number!");
            }
            if (hoursStudiedToday < 0)
            {
                return new ValidationResult(false, "You can't study a negative amount of hours!");
            }
            if (hoursStudiedToday > 24)
            {
                return new ValidationResult(false, "There are only 24 hours in a day!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
