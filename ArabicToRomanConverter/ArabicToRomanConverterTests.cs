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

        string ArabicToRomanConverter(int number)
        {
            string[] romanNo = { "I", "V", "X", "L", "C", "D", "M" };
            int[] arabicNo = { 1, 5, 10, 50, 100, 500, 1000 };
            string lst = string.Empty;
            for (int i = arabicNo.Count() - 1; i > 0; i--)
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
