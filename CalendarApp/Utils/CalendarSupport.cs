using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarApp.Utils
{
    class CalendarSupport
    {
        public const int DaysInWeek = 7;

        public const int WeeksInMonth = 5;

        public static int GetDayNumber(DayOfWeek day)
        {
            if (day == DayOfWeek.Sunday)
                return 7;
            return (int)day;
        }

        public static int GetIndexOfDay(int day)
        {
            if (day == 6)
                return 0;
            return day + 1;
        }
    }
}
