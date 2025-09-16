using System.Globalization;
using CondoSphere.Core.Enums;
using Microsoft.Maui.Graphics;

namespace CondoSphere.Mobile.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is UnitQuotaStatus status)
            {
                return status switch
                {
                    UnitQuotaStatus.Paid => Color.FromArgb("#10B981"), // Success green
                    UnitQuotaStatus.Overdue => Color.FromArgb("#EF4444"), // Error red
                    UnitQuotaStatus.PendingConfirmation => Color.FromArgb("#F59E0B"), // Warning orange
                    UnitQuotaStatus.Pending => Color.FromArgb("#3B82F6"), // Info blue
                    UnitQuotaStatus.PartiallyPaid => Color.FromArgb("#F59E0B"), // Warning orange
                    _ => Color.FromArgb("#6B7280") // Gray
                };
            }
            return Color.FromArgb("#6B7280");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IsNotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class HasItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Collections.IEnumerable enumerable)
            {
                return enumerable.Cast<object>().Any();
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StatusToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is UnitQuotaStatus status && parameter is string param)
            {
                return param switch
                {
                    "ShowPayButton" => status == UnitQuotaStatus.Pending || status == UnitQuotaStatus.Overdue,
                    "ShowUploadButton" => status == UnitQuotaStatus.Pending || status == UnitQuotaStatus.Overdue || status == UnitQuotaStatus.PartiallyPaid,
                    "ShowPendingMessage" => status == UnitQuotaStatus.PendingConfirmation,
                    _ => false
                };
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value;
        }
    }

    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }

    public class OccurrenceStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is OccurrenceStatus status)
            {
                return status switch
                {
                    OccurrenceStatus.Open => Color.FromArgb("#3B82F6"), // Info blue
                    OccurrenceStatus.InProgress => Color.FromArgb("#F59E0B"), // Warning orange
                    OccurrenceStatus.OnHold => Color.FromArgb("#EF4444"), // Error red
                    OccurrenceStatus.Resolved => Color.FromArgb("#8B5CF6"), // Purple
                    OccurrenceStatus.Closed => Color.FromArgb("#10B981"), // Success green
                    _ => Color.FromArgb("#6B7280") // Gray
                };
            }
            return Color.FromArgb("#6B7280");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && parameter is string colorPair)
            {
                var colors = colorPair.Split(',');
                if (colors.Length == 2)
                {
                    var trueColor = colors[0];
                    var falseColor = colors[1];
                    return boolValue ? Color.FromArgb(trueColor) : Color.FromArgb(falseColor);
                }
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InverseBoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && parameter is string colorPair)
            {
                var colors = colorPair.Split(',');
                if (colors.Length == 2)
                {
                    var trueColor = colors[0];
                    var falseColor = colors[1];
                    return !boolValue ? Color.FromArgb(trueColor) : Color.FromArgb(falseColor);
                }
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && parameter is string stringPair)
            {
                var strings = stringPair.Split(',');
                if (strings.Length == 2)
                {
                    return boolValue ? strings[0] : strings[1];
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToFontAttributesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? FontAttributes.None : FontAttributes.Bold;
            }
            return FontAttributes.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter is string format)
            {
                return string.Format(format, value);
            }
            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IsNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string param && param.Equals("Inverse", StringComparison.OrdinalIgnoreCase))
            {
                return string.IsNullOrWhiteSpace(value?.ToString());
            }
            return !string.IsNullOrWhiteSpace(value?.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}