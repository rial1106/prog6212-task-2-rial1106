using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    internal class ComboBoxNotNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "A module must be selected!");
            }
            return ValidationResult.ValidResult;
        }

    }
}
