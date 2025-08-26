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
                    UnitQuotaStatus.Paid => Colors.Green,
                    UnitQuotaStatus.Overdue => Colors.Red,
                    UnitQuotaStatus.PendingConfirmation => Colors.Orange,
                    _ => Colors.Black
                };
            }
            return Colors.Black;
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
}