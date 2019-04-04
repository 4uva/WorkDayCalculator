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
    public class LastDayPositions
    {
        [TestMethod]
        public void FinishBeforeFirstWeekend()
        {
            DateTime start = new DateTime(2017, 4, 18);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 4, 22), end);
        }

        [TestMethod]
        public void FinishBetweenWeekends() // from reqs
        {
            DateTime start = new DateTime(2017, 4, 21);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 4, 28), end);
        }

        [TestMethod]
        public void FinishAfterLastWeekend()
        {
            DateTime start = new DateTime(2017, 4, 22);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 4, 29), end);
        }

        [TestMethod]
        public void FinishSingleDayBeforeWeekend()
        {
            DateTime start = new DateTime(2017, 4, 20);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 4, 28), new DateTime(2017, 4, 29));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 4, 27), end);
        }

        [TestMethod]
        public void FinishSingleDayAfterWeekend()
        {
            DateTime start = new DateTime(2017, 4, 19);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 4, 28), new DateTime(2017, 4, 29));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 4, 26), end);
        }
    }
}
