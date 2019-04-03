using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDayCalculatorLib;

namespace WorkDayCalculatorSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = new DateTime(2017, 4, 21);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);
            Console.WriteLine(end);

            DateTime start2 = new DateTime(2017, 4, 21);
            var end2 = WorkDayCalculator.Compute(start2, 5, new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                                                            new DateRange(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29)));
            Console.WriteLine(end2);
        }
    }
}
