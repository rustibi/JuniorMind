using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Fibonacci
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void ShouldReturn5()
        {      
            Assert.AreEqual(5, Fibonacci(5));
        }

        [TestMethod]
        public void ShouldReturn8()
        {
            Assert.AreEqual(8, Fibonacci(6));
        }

        [TestMethod]
        public void ShouldReturn1()
        {
            Assert.AreEqual(1, Fibonacci(1));
        }

        [TestMethod]
        public void ShouldReturn1again()
        {
            Assert.AreEqual(1, Fibonacci(2));
        }


        public int Fibonacci (int number)
        {     
            if (number < 2)
                return number;
            return Fibonacci(number - 1) + Fibonacci(number - 2);
          
        }
    }
}
