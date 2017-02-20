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


        int CalculateTotalRentCost(int monthRent, int delayDays)
        {
            int penaltyRate = delayDays > 10 ? 5 : 2;
            return monthRent + monthRent * delayDays * penaltyRate / 100;
        }
    }
}
