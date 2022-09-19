using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    internal class ClassHoursPerWeekValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double classHoursPerWeek;
            try
            {
                classHoursPerWeek = double.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not a valid number!");
            }
            if (classHoursPerWeek < 0)
            {
                return new ValidationResult(false, "There can not be a negative amount of class hours!");
            }
            if (classHoursPerWeek > 168)
            {
                return new ValidationResult(false, "There are only 168 hours in a week!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
