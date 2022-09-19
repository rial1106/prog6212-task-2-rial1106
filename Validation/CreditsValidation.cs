using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    internal class CreditsValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int credits;
            try
            {
                credits = int.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "The value entered is not a valid number!");
            }
            if (credits < 0)
            {
                return new ValidationResult(false, "A module can not have a negative number of credits!");
            }
            if (credits == 0)
            {
                return new ValidationResult(false, "A module can not be worth 0 credits!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
