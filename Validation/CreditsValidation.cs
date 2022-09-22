using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    /* This class validates whether the inputted value of a TextBox is a valid number
     * of credits. An error message will be displayed if it invalid.
     * Implementing ValidationRule allows us to call this class through <Binding.ValidationRules>
     * in a XAML file.
     */
    internal class CreditsValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int credits;
            try // Test if it is a valid integer.
            {
                credits = int.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not a valid number!");
            }
            if (credits < 0) // Test if the number of credits is negative.
            {
                return new ValidationResult(false, "A module can not have a negative number of credits!");
            }
            if (credits == 0) // Test if the number of credits is 0;
            {
                return new ValidationResult(false, "A module can not be worth 0 credits!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
