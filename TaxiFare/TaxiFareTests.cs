﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaxiFare
{
    [TestClass]
    public class TaxiFareTests
    {
        [TestMethod]
        public void DayTimeFareForShortDistances()
        {
            Assert.AreEqual(5, CalculateTaxiFare(1, 8));
        }

        [TestMethod]
        public void DayTimeFareForMediumDistances()
        {
            Assert.AreEqual(168, CalculateTaxiFare(21, 8));
        }

        decimal CalculateTaxiFare(int distanceInKm, int hour)
        {
            decimal pricePerKm = IsMediumDistance(distanceInKm) ? 8: 5;
            return distanceInKm * pricePerKm;
        }

        private static bool IsMediumDistance(int distanceInKm)
        {
            return distanceInKm > 20;
        }
            
    }
}
