using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ArabicToRomanConverter
{
    [TestClass]
    public class ArabicToRomanConverterTests
    {
        [TestMethod]
        public void ConvertToOneDigitRomanX()
        {
            Assert.AreEqual("X", ArabicToRomanConverter(10));
        }

        [TestMethod]
        public void ConvertToOneDigitRomanL()
        {
            Assert.AreEqual("L", ArabicToRomanConverter(50));
        }

        [TestMethod]
        public void ConvertToTwoDigitsRomanLV()
        {
            Assert.AreEqual("LV", ArabicToRomanConverter(55));
        }

        [TestMethod]
        public void ConvertToTwoDigitsRomanXL()
        {
            Assert.AreEqual("XL", ArabicToRomanConverter(40));
        }

        [TestMethod]
        public void ConvertToThreeDigitsRomanXLV()
        {
            Assert.AreEqual("XLV", ArabicToRomanConverter(45));
        }

        [TestMethod]
        public void ConvertToForDigitsRomanXCIX()
        {
            Assert.AreEqual("XCIX", ArabicToRomanConverter(99));
        }


        [TestMethod]
        public void ConvertToNineDigitsRomanMMMCMXCIX()
        {
            Assert.AreEqual("MMMCMXCIX", ArabicToRomanConverter(3999));
        }

        string ArabicToRomanConverter(int number)
        {
            string[] romanNo = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM","M" };
            int[] arabicNo = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string lst = string.Empty;
            for (int i = arabicNo.Count() - 1; i >= 0; i--)
            {
                while (number >= arabicNo[i])
                {
                    lst = lst+romanNo[i];
                    number = number - arabicNo[i];  
                } 
            }
            return lst;
            
        }

       
    }
}
