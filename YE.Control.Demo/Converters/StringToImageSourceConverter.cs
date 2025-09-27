using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace YE.Control.Demo.Converters;

public class StringToImageSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return Binding.DoNothing;

        var path = value.ToString();
        if (string.IsNullOrEmpty(path))
            return Binding.DoNothing;

        var image = new BitmapImage();
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
        image.UriSource = new Uri(path, UriKind.Relative);
        image.EndInit();
        return image;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}

