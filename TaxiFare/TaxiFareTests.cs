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
            decimal pricePerKm = distanceInKm > 20? 8: 5;
            return distanceInKm * pricePerKm;
        }
    }
}
