using System;
using System.Globalization;
using Microsoft.Maui.Controls;
namespace Prodactive_App2.Converter;
public class StringToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is string colorString)
        {
            if (Color.TryParse(colorString, out Color color))
                return color;
        }
        return null;

    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}

