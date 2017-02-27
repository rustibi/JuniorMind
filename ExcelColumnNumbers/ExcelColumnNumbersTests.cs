using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumnNumbers
{
    [TestClass]
    public class ExcelColumnNumbersTests
    {
        
        [TestMethod]
        public void OneLettersColumn()
        {
            Assert.AreEqual("a", CalculateExcelColumnNumber(1));
        }

        [TestMethod]
        public void TwoLettersColumn2()
        {
            Assert.AreEqual("ab", CalculateExcelColumnNumber(28));
        }

        [TestMethod]
        public void TwoLettersColumn3()
        {
            Assert.AreEqual("ba", CalculateExcelColumnNumber(53));
        }

        [TestMethod]
        public void ThreeLettersColumn1()
        {
            Assert.AreEqual("aaa", CalculateExcelColumnNumber(703));
        }




        string CalculateExcelColumnNumber(int columnNo)
        {
            int constant = 26;
            string columnInLetters = String.Empty;
            int count = 0;

            while (columnNo > 0)
            {
                count = (columnNo-1) % constant;
                columnInLetters = (char)('a' + count) + columnInLetters;
                columnNo = (columnNo - count) / constant;
            }
            
            return columnInLetters;
        }

    }
}