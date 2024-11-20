using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TodoApp.Converter
{
    class DeadlineConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3 || !(values[0] is DateTime deadline) || !(values[1] is bool isDone) || !(values[2] is DateTime currentDate))
                return DependencyProperty.UnsetValue;

            if (isDone)
                return Brushes.Transparent;

            if (deadline < currentDate)
            {
                Color color = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFDADA");
                return new SolidColorBrush(color);
            }

            return Brushes.Transparent;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
