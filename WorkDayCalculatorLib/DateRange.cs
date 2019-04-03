using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDayCalculatorLib
{
    public class DateRange
    {
        public DateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate.TimeOfDay != TimeSpan.Zero)
                throw new ArgumentException("Must contain only date", nameof(startDate));
            if (endDate.TimeOfDay != TimeSpan.Zero)
                throw new ArgumentException("Must contain only date", nameof(endDate));
            if (startDate > endDate)
                throw new ArgumentException("Start date after end date");
            StartDate = startDate;
            EndDate = endDate;
        }

        public readonly DateTime StartDate, EndDate;
    }
}
