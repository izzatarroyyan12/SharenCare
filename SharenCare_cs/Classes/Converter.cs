using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SharenCare_cs.Classes
{
    class MarginProportionalConverter : IValueConverter
    {
        public double Proportion { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double windowSize)
            {
                double marginValue = windowSize * Proportion;
                return new Thickness(marginValue);
            }

            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}