using PROG6212.Models;
using System.Globalization;
using System.Windows.Controls;

namespace PROG6212.Validation
{

    /* This class validates whether the selection of the ComboBox is an actual module
     * and is not null.
     * Implementing ValidationRule allows us to call this class through <Binding.ValidationRules>
     * in a XAML file.
     */
    internal class ComboBoxNotNullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            Module mod = (Module)value;

            if(string.IsNullOrEmpty(mod.moduleCode))
            {
                return new ValidationResult(false, "Please select a module!");
            }

            return ValidationResult.ValidResult;
        }

    }
}
