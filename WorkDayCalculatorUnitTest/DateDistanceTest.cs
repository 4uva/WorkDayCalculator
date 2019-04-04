using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkDayCalculatorLib;

namespace WorkDayCalculatorUnitTest
{
    [TestClass]
    public class DateDistanceTest
    {
        [TestMethod]
        public void SingleDayWeekend()
        {
            DateTime start = new DateTime(2017, 4, 21);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 23));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 4, 26), end);
        }

        [TestMethod]
        public void AdjacentWeekends()
        {
            DateTime start = new DateTime(2017, 4, 21);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 24));
            var weekend2 = new DateRange(new DateTime(2017, 4, 25), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 4, 28), end);
        }
    }
}
