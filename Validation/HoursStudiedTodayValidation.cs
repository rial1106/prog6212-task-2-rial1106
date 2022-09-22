using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    /* This class validates whether the inputted value of a TextBox is a valid number
     * of hours studied in one day. An error message will be displayed if it invalid.
     * Implementing ValidationRule allows us to call this class through <Binding.ValidationRules>
     * in a XAML file.
     */
    internal class HoursStudiedTodayValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double hoursStudiedToday;
            try // Test if it is a valid double.
            {
                hoursStudiedToday = double.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not a valid number!");
            }
            if (hoursStudiedToday < 0) // Test if the value is negative.
            {
                return new ValidationResult(false, "You can't study a negative amount of hours!");
            }
            if (hoursStudiedToday > 24) // Test if the value is more than the number of possible hours in a day.
            {
                return new ValidationResult(false, "There are only 24 hours in a day!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
