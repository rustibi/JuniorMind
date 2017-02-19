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
            Assert.AreEqual(3132900, CalculateDelta(1, 230, -770000));
        }


       
        float CalculateDelta(float a, float b, float c)
        {
            float dt = b * b - 4 * a * c;
            return dt;
        }

        

        
    }
}
