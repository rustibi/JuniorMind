using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LotoOdds
{
    [TestClass]
    public class LotoOddsTests
    {
        [TestMethod]
        public void SixWinningNumbers649()
        {
            Assert.AreEqual(1/13983816, CalculateLotoOdds(6));
            
        }

        int CalculateLotoOdds(int winningNumbers)
        {
            return 1/49 * 2/48 * 3/47 * 4/46 * 5/45 * 6/44;
        }

    }
}
