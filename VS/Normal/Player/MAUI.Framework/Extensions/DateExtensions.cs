using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIApp.Framework.Extensions
{
    public static class DateExtensions
    {
        public static string ToTimeAgo(this DateTime baseTime)
        {
            var _timeSpan = DateTime.Now - baseTime;

            if (_timeSpan.TotalMinutes == 0)
                return "Just Now";

            if (_timeSpan.TotalMinutes < 60)
                return $"{Convert.ToInt32(_timeSpan.TotalMinutes)} min(s) ago";

            if (_timeSpan.TotalHours < 2)
                return $"{Convert.ToInt32(_timeSpan.TotalHours)} hour ago";

            if (_timeSpan.TotalHours < 24)
                return $"{Convert.ToInt32(_timeSpan.TotalHours)} hour(s) ago";

            if (_timeSpan.TotalDays < 2)
                return $"{Convert.ToInt32(_timeSpan.TotalDays)} day ago";

            if (_timeSpan.TotalDays < 365)
                return $"{Convert.ToInt32(_timeSpan.TotalDays)} days(s) ago";

            double totalYears = (Convert.ToDouble(_timeSpan.TotalHours) / 365);
            if (totalYears < 2)
                return $"{totalYears.ToString("#")} year ago";

            return $"{totalYears.ToString("#")} year ago";
        }

        public static string ToReadableString(this TimeSpan timeSpan) =>
            String.Format("{0}{1}{2}{3}",                
                timeSpan.Duration().Days > 0 ? string.Format("{0:0} day{1}, ", timeSpan.Days, timeSpan.Days == 1 ? string.Empty : "s") : string.Empty,
                timeSpan.Duration().Hours > 0 ? string.Format("{0:0} hr{1}, ", timeSpan.Hours, timeSpan.Hours == 1 ? string.Empty : "s") : string.Empty,
                timeSpan.Duration().Minutes > 0 ? string.Format("{0:0} min{1}, ", timeSpan.Minutes, timeSpan.Minutes == 1 ? string.Empty : "s") : string.Empty,
                timeSpan.Duration().Seconds > 0 ? string.Format("{0:0} sec{1}, ", timeSpan.Seconds, timeSpan.Seconds == 1 ? string.Empty : "s") : string.Empty
                );

        public static TimeSpan ToTimeSpan(this string isoDuration) =>
            System.Xml.XmlConvert.ToTimeSpan(isoDuration);
    }
}
