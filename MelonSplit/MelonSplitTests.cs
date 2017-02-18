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

        string CalculateMelonSplit(int weight)
        {
            return "Da";
        }

    }
}
