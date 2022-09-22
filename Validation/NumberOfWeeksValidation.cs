using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    /* This class validates whether the inputted value of a TextBox is a valid number
     * of weeks in a semester. An error message will be displayed if it invalid.
     * Implementing ValidationRule allows us to call this class through <Binding.ValidationRules>
     * in a XAML file.
     */
    internal class NumberOfWeeksValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int numberOfWeeks; // Test is the value is a valid integer.
            try
            {
                numberOfWeeks = int.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not a valid number!");
            }
            if (numberOfWeeks < 0) // Test if it is less than 0.
            {
                return new ValidationResult(false, "A semester can not last a negative number of weeks!");
            }
            if (numberOfWeeks == 0) // Test if it is equal to 0.
            {
                return new ValidationResult(false, "A semester can not last 0 weeks!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
