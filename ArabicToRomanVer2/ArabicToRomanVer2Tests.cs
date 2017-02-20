using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArabicToRomanVer2
{
    [TestClass]
    public class ArabicToRomanVer2Tests
    {
      

        [TestMethod]
        public void TestTens()
        {
            Assert.AreEqual("L", ArabicToRomanVer2(50));
        }

        [TestMethod]
        public void TestOnes()
        {
            Assert.AreEqual("IX", ArabicToRomanVer2(9));
        }


        string ArabicToRomanVer2 (int number)
        {
            string[] tens = { " ", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = {" ","I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
            
        //  int[] arabic = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string romanNo = string.Empty;

            romanNo = romanNo + tens[(int)(number / 10)];
            romanNo = ones[number];


            return romanNo;
        }
    }
}
