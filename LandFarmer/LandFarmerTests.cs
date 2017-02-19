using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LandFarmer
{
    [TestClass]
    public class LandFarmerTests
    {
        [TestMethod]
        public void DeltaGreaterThenZero()
        {
            Assert.AreEqual(1770, CalculateSqrtDelta(1, 230, -770000));
        }
        
        [TestMethod]
        public void CalculateInitialArea()
        {
            Assert.AreEqual(770, CalculateInitialArea(1, 230, -770000));
        }

        


        double CalculateSqrtDelta(float a, float b, float c)
        {
            double dt = b * b - 4 * a * c;
            
            if (dt < 0) {
                Console.WriteLine("The Equation has complex solution!");
            }
            return Math.Sqrt(dt);
        }




        double CalculateInitialArea(float a, float b, float c)
        {

            return (-b + CalculateSqrtDelta(a, b, c)) / (2 * a);
            
        }

        

        
    }
}
