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
            Assert.AreEqual(4, PrefixCalculator("+22"));
        }

        [TestMethod]
        public void ShouldCalculateFourNumbersAndReturn()
        {
            Assert.AreEqual(4, PrefixCalculator("*+112"));
        }


        double PrefixCalculator(string input)
        {
            string[] elements = new string[input.Length];
            int i = 0;
            for (int j = 0; j < input.Length; j++)
                elements[j] = input[j].ToString();
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
