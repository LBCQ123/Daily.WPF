using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Daily.WPF.Converters
{
    /// <summary>
    /// 将DateTime转换为规定格式的String
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateTimeToStringConverter : IValueConverter
    {
        /// <summary>
        /// 结果样例：2024年-03-03 星期日
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime dateTime)
            {
                string output = dateTime.ToString("yyyy年-MM-dd ");
                switch(dateTime.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        output += "星期一";
                        break;
                    case DayOfWeek.Tuesday:
                        output += "星期二";
                        break;
                    case DayOfWeek.Wednesday:
                        output += "星期三";
                        break;
                    case DayOfWeek.Thursday:
                        output += "星期四";
                        break;
                    case DayOfWeek.Friday:
                        output += "星期五";
                        break;
                    case DayOfWeek.Saturday:
                        output += "星期六";
                        break;
                    case DayOfWeek.Sunday:
                        output += "星期日";
                        break;
                }

                return output;
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
