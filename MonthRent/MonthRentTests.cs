using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonthRent
{
    [TestClass]
    public class MonthRentTests
    {
        [TestMethod]
        public void UnderTenDelayDays()
        {
            Assert.AreEqual(104, CalculateTotalRentCost(100, 2));
        }

        [TestMethod]
        public void OverTenAndUnderThirtyDelayDays()
        {
            Assert.AreEqual(155, CalculateTotalRentCost(100, 11));
        }


        [TestMethod]
        public void OverThirtyDelayDays()
        {
            Assert.AreEqual(410, CalculateTotalRentCost(100, 31));
        }


        int CalculateTotalRentCost(int monthRent, int delayDays)
        {
            int penaltyRate = 2;
            if (delayDays > 30)
                penaltyRate = 10;
            else if (delayDays > 10)
                penaltyRate = 5;
            return monthRent + monthRent * delayDays * penaltyRate / 100;
        }
    }
}
