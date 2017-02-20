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

        int CalculateTotalRentCost(int monthRent, int delayDays)
        {
            return monthRent + monthRent*2/100*delayDays;
        }
    }
}
