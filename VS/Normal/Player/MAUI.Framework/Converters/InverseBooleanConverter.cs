using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Framework.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !((bool)value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !((bool)value);
    }
}
