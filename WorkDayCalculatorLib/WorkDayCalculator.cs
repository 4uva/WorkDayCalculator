using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDayCalculatorLib
{
    static public class WorkDayCalculator
    {
        private class DateRangeByStartDateComparer : IComparer<DateRange>
        {
            public int Compare(DateRange x, DateRange y)
            {
                // x and y are never null here
                return x.StartDate.CompareTo(y.StartDate);
            }
        }

        static public DateTime Compute(DateTime begin, int duration, params DateRange[] weekends)
        {
            if (begin.TimeOfDay != TimeSpan.Zero)
                throw new ArgumentException("Must contain only date", nameof(begin));
            if (duration <= 0)
                throw new ArgumentException("Duration must be positive", nameof(duration));
            if (weekends == null)
                throw new ArgumentNullException(nameof(weekends));

            int weekendCount = weekends.Length;

            var beginRange = new DateRange(begin, begin);
            int indexOfCurrentWeekend = Array.BinarySearch(weekends, beginRange, new DateRangeByStartDateComparer());
            if (indexOfCurrentWeekend < 0) // not found
                indexOfCurrentWeekend = ~indexOfCurrentWeekend - 1; // index of first weekend starting before or -1

            DateTime currentDate = begin;
            if (indexOfCurrentWeekend >= 0) // if there is weekend before...
            {
                DateRange startWeekend = weekends[indexOfCurrentWeekend];
                DateTime firstWorkDayAfterStartWeekend = startWeekend.EndDate.AddDays(1);
                if (currentDate < firstWorkDayAfterStartWeekend) // and that weekend didn't finish yet
                    currentDate = firstWorkDayAfterStartWeekend; // shift to the next working day
            }

            // current is always a working day
            // indexOfCurrentWeekend is before current
            int remainingDays = duration - 1;
            indexOfCurrentWeekend++;
            // loop over all remaining weekends
            for (/**/; indexOfCurrentWeekend < weekendCount; indexOfCurrentWeekend++)
            {
                // compute working days on the preceding week
                DateRange currentWeekend = weekends[indexOfCurrentWeekend];
                int daysToCurrentWeekend = (currentWeekend.StartDate - currentDate).Days;
                if (daysToCurrentWeekend > remainingDays)
                {
                    // we can finish before weekend
                    return currentDate.AddDays(remainingDays);
                }
                else
                {
                    currentDate = currentWeekend.EndDate.AddDays(1);
                    remainingDays -= daysToCurrentWeekend;
                }
            }
            // no more weekends
            return currentDate.AddDays(remainingDays);
        }
    }
}
