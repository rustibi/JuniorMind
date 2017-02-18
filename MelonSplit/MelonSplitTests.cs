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
            Assert.AreEqual("Da", CalculateMelonSplit(2));
        }

        [TestMethod]
        public void WeightMelonOdd()
        {
            Assert.AreEqual("Nu", CalculateMelonSplit(3));
        }


        string CalculateMelonSplit(int weight)
        {
            if (weight%2 == 0)
            {
                return "Da";
            }
                
            return "Nu";
        }

    }
}
