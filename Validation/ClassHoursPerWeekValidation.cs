using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    /* This class validates whether the inputted value of a TextBox is a valid number
     * of class hours per week. An error message will be displayed if it invalid.
     * Implementing ValidationRule allows us to call this class through <Binding.ValidationRules>
     * in a XAML file.
     */
    internal class ClassHoursPerWeekValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double classHoursPerWeek;
            try
            {
                classHoursPerWeek = double.Parse(value.ToString()); // Test if it is a valid double.
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not a valid number!");
            }
            if (classHoursPerWeek < 0) // Test if it is less than 0.
            {
                return new ValidationResult(false, "There can not be a negative amount of class hours!");
            }
            if (classHoursPerWeek > 168)  // Test if it less than the maximum number of hours in a week.
            {
                return new ValidationResult(false, "There are only 168 hours in a week!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
