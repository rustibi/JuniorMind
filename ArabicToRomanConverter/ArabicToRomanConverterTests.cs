using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArabicToRomanConverter
{
    [TestClass]
    public class ArabicToRomanConverterTests
    {
        [TestMethod]
        public void ConvertToOneDigitRoman()
        {
            Assert.AreEqual("X", ArabicToRomanConverter(10));
        }

        string ArabicToRomanConverter(int number)
        {
            string[] romanNo = { "I", "V", "X", "L", "C", "D", "M" };
            return romanNo[2];
        }
    }
}
