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

        [TestMethod]
        public void DayTimeFareForLongDistances()
        {
            Assert.AreEqual(600, CalculateTaxiFare(100, 8));
        }


        [TestMethod]
        public void NightTimeFareForShortDistances()
        {
            Assert.AreEqual(7, CalculateTaxiFare(1, 21));
        }




        decimal CalculateTaxiFare(int distanceInKm, int hour)
        {
            decimal[] dayTimePrices = { 5, 8, 6 };
            decimal[] nightTimePrices = { 7 };
            decimal[] prices = IsDayTime(hour) ? dayTimePrices : nightTimePrices;
            decimal pricePerKm = GetPricePerKm(distanceInKm, prices);
            return distanceInKm * pricePerKm;
        }

        private bool IsDayTime(int hour)
        {
            return 8 <= hour && hour < 21;
        }

        private decimal GetPricePerKm(int distanceInKm, decimal[] prices)
        {

            if (IsLongDistance(distanceInKm))
                return prices[2];

            if (IsMediumDistance(distanceInKm))
                return prices[1];

            return prices[0];
        }

        private bool IsLongDistance(int distanceInKm)
        {
            return distanceInKm > 60;
        }

        private static bool IsMediumDistance(int distanceInKm)
        {
            return distanceInKm > 20;
        }
            
    }
}
