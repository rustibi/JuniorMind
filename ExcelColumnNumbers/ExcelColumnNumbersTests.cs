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
            Assert.AreEqual('b', CalculateExcelNumbers(2));
        }

        char CalculateExcelNumbers (int columnNo)
        {   
            return (char)('a' + columnNo - 1);
        }

    }
}
