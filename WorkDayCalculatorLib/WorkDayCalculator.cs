using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDayCalculatorLib
{
    static public class WorkDayCalculator
    {
        static public DateTime Compute(DateTime begin, int duration, params DateRange[] weekends)
        {
            if (begin.TimeOfDay != TimeSpan.Zero)
                throw new ArgumentException("Must contain only date", nameof(begin));
            if (duration <= 0)
                throw new ArgumentException("Duration must be positive", nameof(duration));
            if (weekends == null)
                throw new ArgumentNullException(nameof(weekends));

            int weekendCount = weekends.Length;
            DateTime[] weekendsStart = new DateTime[weekendCount];
            DateTime[] workWeekStart = new DateTime[weekendCount];
            for (int i = 0; i < weekendCount; i++)
            {
                weekendsStart[i] = weekends[i].StartDate;
                workWeekStart[i] = weekends[i].EndDate.AddDays(1);
            }

            DateTime current;
            int indexOfCurrentWeekend = Array.BinarySearch(weekendsStart, begin);
            if (indexOfCurrentWeekend >= 0) // found
            {
                // shift to the next working day
                current = workWeekStart[indexOfCurrentWeekend];
            }
            else
            {
                indexOfCurrentWeekend = ~indexOfCurrentWeekend - 1; // index of first weekend starting before or -1
                if (indexOfCurrentWeekend >= 0 && begin < workWeekStart[indexOfCurrentWeekend])
                    current = workWeekStart[indexOfCurrentWeekend];
                else
                    current = begin;
            }

            // current is always a working day
            // indexOfCurrentWeekend is before current
            int remainingDays = duration - 1;
            indexOfCurrentWeekend++;
            for (/**/; indexOfCurrentWeekend < weekendCount; indexOfCurrentWeekend++)
            {
                int daysToNextWeekend = (weekendsStart[indexOfCurrentWeekend] - current).Days;
                if (daysToNextWeekend >= remainingDays)
                {
                    // we can finish before weekend
                    return current.AddDays(remainingDays);
                }
                else
                {
                    current = workWeekStart[indexOfCurrentWeekend];
                    remainingDays -= daysToNextWeekend;
                }
            }
            // no more weekends
            return current.AddDays(remainingDays);
        }
    }
}
