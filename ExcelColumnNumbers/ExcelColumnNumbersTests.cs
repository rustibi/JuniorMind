using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumnNumbers
{
    [TestClass]
    public class ExcelColumnNumbersTests
    {
        [TestMethod]
        public void OneLetterColumn()
        {
            Assert.AreEqual("b", CalculateExcelColumnNumber(2));
        }

        [TestMethod]
        public void TwoLettersColumn()
        {
            Assert.AreEqual("aa", CalculateExcelColumnNumber(27));
        }

        [TestMethod]
        public void TwoLettersColumn2()
        {
            Assert.AreEqual("ab", CalculateExcelColumnNumber(28));
        }

        [TestMethod]
        public void ThreeLettersColumn()
        {
            Assert.AreEqual("aaa", CalculateExcelColumnNumber(53));
        }

        [TestMethod]
        public void ThreeLettersColumn2()
        {
            Assert.AreEqual("aab", CalculateExcelColumnNumber(54));
        }




        string CalculateExcelColumnNumber (int columnNo)
        {
            int constant = 26;
            string constantCount = String.Empty;
            string columnInLetters = String.Empty;

            while (columnNo >= 27)
            {
                columnNo = columnNo - constant;
                constantCount += "a";
            }

            columnInLetters = constantCount + (char)('a' + columnNo - 1);

            return columnInLetters;
        }

    }
}
