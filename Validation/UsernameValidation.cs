using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    /* This class validates whether the inputted value of in a textbox is a valid username.
     * An error message will be displayed if it invalid.
     * Implementing ValidationRule allows us to call this class through <Binding.ValidationRules>
     * in a XAML file.
     */
    internal class UsernameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str;
            try // Test if is a valid string.
            {
                str = value.ToString();
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not valid!");
            }
            if (string.IsNullOrEmpty(str)) // Test if it is null or empty.
            {
                return new ValidationResult(false, "You have not entered any value!");
            }
            if (str.Length > 100) // Test if it is null or empty.
            {
                return new ValidationResult(false, "You can not have a username over 100 characters!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
