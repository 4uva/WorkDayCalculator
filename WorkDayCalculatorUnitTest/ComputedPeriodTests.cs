using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkDayCalculatorLib;

namespace WorkDayCalculatorUnitTest
{
    [TestClass]
    public class ComputedPeriodTests
    {
        [TestMethod]
        public void NoWeekendInside()
        {
            DateTime start = new DateTime(2017, 4, 26);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 5, 1), new DateTime(2017, 5, 2));
            var duration = 2;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 4, 27), end);
        }

        [TestMethod]
        public void SingleWeekendInside()
        {
            DateTime start = new DateTime(2017, 4, 20);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 5, 1), new DateTime(2017, 5, 2));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 4, 27), end);
        }

        [TestMethod]
        public void TwoWeekendsInside()
        {
            DateTime start = new DateTime(2017, 4, 20);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 5, 1), new DateTime(2017, 5, 2));
            var duration = 10;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 5, 4), end);
        }
    }
}
