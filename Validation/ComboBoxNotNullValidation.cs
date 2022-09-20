using PROG6212.Models;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{
    internal class ComboBoxNotNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            Module mod = (Module)value;

            if(string.IsNullOrEmpty(mod.ModuleCode))
            {
                return new ValidationResult(false, "Please select a module!");
            }

            return ValidationResult.ValidResult;
        }

    }
}
