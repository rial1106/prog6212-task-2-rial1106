using System;
using System.Globalization;
using System.Windows.Data;

namespace PROG6212.Converters
{

    /* This class converts a multi binding in a XAML file to an array of objects so that it can be passed
     * to a function that can only take one parameter (AddStudyingDateCommand).
     * Taken from https://www.melodiouscode.net/passing-multiple-parameters-to-an-icommand-in-wpf
     * IMultiValueConverter allows us to get input from a multibinding in a control.
     */
    public class ArrayMultiValueConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone(); // Returns a copy of an array of the paramters.
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // We do not need to convert back as this is a one way conversion.
        }

    }
}
