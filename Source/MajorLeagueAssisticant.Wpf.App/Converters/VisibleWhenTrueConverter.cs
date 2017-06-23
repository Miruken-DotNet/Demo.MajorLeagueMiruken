using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MajorLeagueAssisticant.Wpf.App.Converters
{
    public class VisibleWhenTrueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Visibility) && targetType != typeof(Visibility?))
                throw new InvalidOperationException("VisibleWhenTrueConverter can only be used with Visibility properties.");

            return ObjectToBoolean(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static bool ObjectToBoolean(object value)
        {
            if (value != null && value is bool)
                return (bool)value;
            return false;
        }
    }
}
