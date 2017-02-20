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

        string ArabicToRomanConverter(int number)
        {
            string[] romanNo = { "I", "V", "X", "L", "C", "D", "M" };
            int[] arabicNo = { 1, 5, 10, 50, 100, 500, 1000 };
            string lst = string.Empty;
            for(int i = 0; i<arabicNo.Count()-1; i++)
            {
                if (number == arabicNo[i])
                {
                    return lst = lst+romanNo[i];
                    
                } 

            }
            return lst;
            
        }

       
    }
}
