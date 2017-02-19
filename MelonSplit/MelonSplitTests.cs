using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MelonSplit
{
    [TestClass]
    public class MelonSplitTests
    {
        [TestMethod]
        public void WeightMelonEven()
        {
            Assert.AreEqual("Da", CalculateMelonSplit(4));
        }

        [TestMethod]
        public void WeightMelonOddAndLessThenFor()
        {
            Assert.AreEqual("Nu", CalculateMelonSplit(3));
        }

        [TestMethod]
        public void WeightMelonOddAndGreaterThenFor()
        {
            Assert.AreEqual("Nu", CalculateMelonSplit(5));
        }


        string CalculateMelonSplit(int weight)
        {
            if ((weight >= 4) & (weight%2 == 0))
            {
                return "Da";
            }
                
            return "Nu";
        }

    }
}
