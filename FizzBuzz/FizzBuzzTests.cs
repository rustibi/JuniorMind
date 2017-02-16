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

        [TestMethod]
        public void DivisibleByFive()
        {
            Assert.AreEqual("Buzz", CalculateFizzBuzz(5));
        }

        [TestMethod]
        public void DivisibleByThree()
        {
            Assert.AreEqual("Fizz", CalculateFizzBuzz(3));
        }


        string CalculateFizzBuzz(int number)
        {
            string result = "";
            if (number % 15 == 0)
            {
                result = "FizzBuzz";
                return result;
            }
            else if (number % 5 == 0)
            {
                result = "Buzz";
                return result;
            }

            else if (number % 3 == 0)
            {
                result = "Fizz";
                return result;
            }

            else
                return null;
            
            
        }
    }
}
