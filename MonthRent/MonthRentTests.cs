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
            return monthRent + monthRent * delayDays * GetPenaltyRate(delayDays) / 100;
        }



        int GetPenaltyRate(int delayDays)
        {
            int[] penaltyRate = { 2, 5, 10 };

            if (delayDays > 30)
                return penaltyRate[2];
            if (delayDays > 10)
                return penaltyRate[1];
            return penaltyRate[0];
        }
    }
}
