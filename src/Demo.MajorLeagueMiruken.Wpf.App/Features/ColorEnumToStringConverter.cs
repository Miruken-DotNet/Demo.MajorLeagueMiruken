using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Demo.MajorLeagueMiruken.Api;

namespace Demo.MajorLeagueMiruken.Wpf.App.Features
{
    public class ColorEnumToStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) return value.ToString();
            return "Gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color col;
            if (value != null && Enum.TryParse(value.ToString(), true, out col))
            {
                return col;
            }
            return Color.Orange;
        }
    }
}
