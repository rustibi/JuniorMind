using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void DivisibleByFifteen()
        {
            Assert.AreEqual("FizzBuzz", CalculateFizzBuzz(15));
        }


        string CalculateFizzBuzz(int number)
        {
            string result = "";
            if (number % 15 == 0)
                result = "FizzBuzz";
                return result;
            
        }
    }
}
