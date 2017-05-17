using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LotoExtract
{
    [TestClass]
    public class LotoExtractTests
    {
        [TestMethod]
        public void ShouldSortAddedNumbers1()
        {
            int[] result = { 1, 2, 3, 4, 7, 23 };
            CollectionAssert.AreEqual(result, LotoExtract(new int[]{2, 4, 1, 3, 23, 7 }));
        }

        [TestMethod]
        public void ShouldSortAddedNumbers2()
        {
            int[] result = { 2, 9, 11, 30, 33, 45 };
            CollectionAssert.AreEqual(result, LotoExtract(new int[] { 11, 9, 2, 33, 45, 30 }));
        }

        int[] LotoExtract(int[] lotoNumbers)
        {
            for(int i = 1; i < lotoNumbers.Length; i++)
            {
                int curent = lotoNumbers[i];
                int index = i;
                while (index > 0 && lotoNumbers[index - 1] > curent)
                {
                    lotoNumbers[index] = lotoNumbers[index - 1];
                    index = index - 1;
                }
                lotoNumbers[index] = curent;
            }
            return lotoNumbers;
        }
    }
}
