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
            Assert.AreEqual(3132900, CalculateFarmerLand(1, 230, -770000));
        }

        float CalculateFarmerLand(float a, float b, float c)
        {
            
            a = 1;
            b = 230;
            c = -770000;
            float dt = b * b - 4 * a * c;

            return dt;
            
            

            
        }
    }
}
