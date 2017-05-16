using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ShouldAddTwoNumbersAndReturnFour()
        {
            Assert.AreEqual(4, PrefixCalculator("+ 2 2"));
        }

        [TestMethod]
        public void ShouldCalculateThreeNumbersAndReturnFour()
        {
            Assert.AreEqual(4, PrefixCalculator("* + 1 1 2"));
        }


        [TestMethod]
        public void ShouldCalculateMoreComplexNumbers()
        {
            Assert.AreEqual(1549.41, PrefixCalculator("+ / * + 56 45 46 3 - 1 0.25"),1);
        }



        double PrefixCalculator(string input)
        {
            string[] elements = input.Split(' ');
            int i = 0;
            return PrefixCalculator(elements, ref i);
        }
        

        public double PrefixCalculator(string[] elements, ref int i)
        {
            string oneElement = elements[i];
            i++;
            double result = 0;
            if (double.TryParse(oneElement, out result))
                return result;
 
            switch (oneElement)
            {
                case "+":
                    return PrefixCalculator(elements, ref i) + PrefixCalculator(elements, ref i);
                case "-":
                    return PrefixCalculator(elements, ref i) - PrefixCalculator(elements, ref i);
                case "*":
                    return PrefixCalculator(elements, ref i) * PrefixCalculator(elements, ref i);
                default:
                    return PrefixCalculator(elements, ref i) / PrefixCalculator(elements, ref i);
            }
        }   
    }
}
