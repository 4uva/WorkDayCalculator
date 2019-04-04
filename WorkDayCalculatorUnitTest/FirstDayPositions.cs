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
    public class FirstDayPositions
    {
        [TestMethod]
        public void StartBeforeFirstWeekend() // from reqs
        {
            DateTime start = new DateTime(2017, 4, 21);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 4, 28), end);
        }

        [TestMethod]
        public void StartAfterLastWeekend()
        {
            DateTime start = new DateTime(2017, 5, 1);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 5, 5), end);
        }

        [TestMethod]
        public void StartBetweenWeekends()
        {
            DateTime start = new DateTime(2017, 4, 26);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 4, 28), new DateTime(2017, 5, 1));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 5, 4), end);
        }

        [TestMethod]
        public void StartOnWeekendBegin()
        {
            DateTime start = new DateTime(2017, 4, 23);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 4, 30), end);
        }

        [TestMethod]
        public void StartOnWeekendMiddle()
        {
            DateTime start = new DateTime(2017, 4, 24);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 4, 30), end);
        }

        [TestMethod]
        public void StartOnWeekendEnd()
        {
            DateTime start = new DateTime(2017, 4, 25);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 4, 30), end);
        }

        [TestMethod]
        public void StartOnWeekendSingleDay()
        {
            DateTime start = new DateTime(2017, 4, 23);
            var weekend = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 23));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend);

            Assert.AreEqual(new DateTime(2017, 4, 28), end);
        }

        [TestMethod]
        public void StartOnFirstWeekday()
        {
            DateTime start = new DateTime(2017, 4, 26);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 5, 1), end);
        }

        [TestMethod]
        public void StartOnLastWeekday()
        {
            DateTime start = new DateTime(2017, 4, 28);
            var weekend1 = new DateRange(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var weekend2 = new DateRange(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29));
            var duration = 5;

            var end = WorkDayCalculator.Compute(start, duration, weekend1, weekend2);

            Assert.AreEqual(new DateTime(2017, 5, 3), end);
        }
    }
}
