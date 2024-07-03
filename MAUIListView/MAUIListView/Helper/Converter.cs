using Syncfusion.Maui.DataSource.Extensions;
using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIListView
{
    public class EmptyViewHeightConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var groupresult = value as GroupResult;
            var listView = parameter as SfListView;
            if (groupresult != null)
            {
                foreach (var item in groupresult.Items)
                {
                    if ((item as Contacts)!.ContactName == "")
                    {
                        return 100;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return 0;
        }
    }

    public class EmptyViewVisibilityConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if( value != null)
            {
                var groupresult = value as GroupResult;
                if (groupresult != null)
                {
                    foreach (var item in groupresult.Items)
                    {
                        if ((item as Contacts)!.ContactName == "")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                }               
            }
            
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
