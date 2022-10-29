using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEDataExtractor
{
    public static class DateHelper
    {
        public static DateTime GetNextDayOfTheWeek(DayOfWeek dayOfWeek)
        {
           return DateTime.Today.AddDays(((int)DateTime.Today.DayOfWeek - (int)dayOfWeek) + 7);
        }

        public static DateTime GetNextWeekday(DateTime start, DayOfWeek dayOfWeek)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)dayOfWeek - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }
    }
}
