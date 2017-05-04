using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CycloMeterNew
{
    [TestClass]
    public class CycloMeterNewTests
    {
        [TestMethod]
        public void ShouldCalculateTotalDistanceForOneBike()
        {
            var recordsBiker1 = new Record[] { new Record(0.5, 1), new Record(1, 2), new Record(2, 3) };
            var biker1 = new Biker("tibi",0.6, recordsBiker1);
            Assert.AreEqual(6.594, CalculateTotalDistanceForOneBiker(biker1), 1);
        }

        [TestMethod]
        public void ShouldCalculateTotalDistance()
        {
            var recordsBiker1 = new Record[] { new Record(0.5, 1), new Record(1, 2), new Record(2, 3)};
            var recordsBiker2 = new Record[] { new Record(1, 1), new Record(2, 2), new Record(3, 3) };
            var biker1 = new Biker("tibi",0.665, recordsBiker1);
            var biker2 = new Biker("paul",0.665, recordsBiker2);
            Assert.AreEqual(19.847, CalculateTotalDistance(new Biker[] { biker1, biker2 }),1);
        }

        [TestMethod]
        public void ShouldCalculateTheAverageSpeedForOneBiker()
        {
            var recordsBiker1 = new Record[] { new Record(0.5, 1), new Record(1, 2), new Record(2, 3) };
            var biker1 = new Biker("tibi", 0.665, recordsBiker1);
            Assert.AreEqual(2.437, CalculateAverageSpeedForOneBiker(biker1),1);
        }

        [TestMethod]
        public void ShouldCalculateBestAverageSpeed()
        {
            var bikers = new Biker[] {
                new Biker ("tibi", 0.75, new Record[] { new Record(0.5, 1), new Record(1, 2)}),
                new Biker ("paul", 0.95, new Record[] { new Record(1, 1), new Record(2, 2)}),
                new Biker ("ana", 0.45, new Record[] { new Record(1, 1), new Record(2, 2)}),
                new Biker ("maria", 0.35, new Record[] { new Record(0.5, 1), new Record(1, 2)})
            };
            Assert.AreEqual("paul", FindBestBikerAverageSpeed(bikers));
        }

        [TestMethod]
        public void ShouldFindMaxRotationsForOneBiker()
        {
            var recordsBiker1 = new Record[] { new Record(0.5, 1), new Record(2, 2), new Record(7, 3), new Record(5, 4) };
            var biker1 = new Biker("tibi", 0.665, recordsBiker1);
            Assert.AreEqual(new Record(7, 3), FindMaxRotationsForOneBiker(biker1));
        }


        [TestMethod]
        public void ShoulReturnNameAndSecondOfTopSpeedBiker()
        {
            var bikers = new Biker[] {
                new Biker ("tibi", 0.75, new Record[] { new Record(0.5, 1), new Record(1, 2)}),
                new Biker ("paul", 0.95, new Record[] { new Record(1, 1), new Record(5, 2)}),
                new Biker ("ana", 0.45, new Record[] { new Record(1, 1), new Record(2, 2)}),
                new Biker ("maria", 0.35, new Record[] { new Record(0.5, 1), new Record(1, 2)})
            };
            NameAndSecond result = new NameAndSecond("paul", 2);
            Assert.AreEqual(result, FindBestBikerSpeed(bikers));

        }


        NameAndSecond FindBestBikerSpeed(Biker[] biker)
        {
            NameAndSecond nameAndSecond = new NameAndSecond(biker[0].name, biker[0].record[0].second);
            double maxSpeed = 0;
            for (int i = 1; i < biker.Length; i++)
            {
                Record bestRotations = FindMaxRotationsForOneBiker(biker[i]);
                double speed = bestRotations.rotations * biker[i].diameter;
                if (speed > maxSpeed)
                {
                    maxSpeed = speed;
                    nameAndSecond = new NameAndSecond(biker[i].name, bestRotations.second);
                }
            }
            return nameAndSecond;
        }



        Record FindMaxRotationsForOneBiker(Biker biker)
        {
            Record maxRotations = biker.record[0]; 
            for (int i = 1; i < biker.record.Length; i++)
            {
                if (biker.record[i].rotations > maxRotations.rotations)
                {
                    maxRotations = biker.record[i];
                }
            }
            return maxRotations;
        }



        string FindBestBikerAverageSpeed(Biker[] biker)
        {
            double bestAverageSpeed = CalculateAverageSpeedForOneBiker(biker[0]);
            string bikerName = biker[0].name;
            for (int i = 1; i < biker.Length; i++)
            {
                if (bestAverageSpeed < CalculateAverageSpeedForOneBiker(biker[i]))
                {
                    bestAverageSpeed = CalculateAverageSpeedForOneBiker(biker[i]);
                    bikerName = biker[i].name;
                }
            }
            return bikerName;
        }

 
        double CalculateAverageSpeedForOneBiker(Biker biker)
        {
            double distance = CalculateTotalDistanceForOneBiker(biker);
            int totalTime = biker.record.Length;
            return distance / totalTime;
        }



        double CalculateTotalDistance(Biker[] biker)
        {
            double distance = 0;
            for (int i = 0; i< biker.Length; i++)
            {
                distance += CalculateTotalDistanceForOneBiker(biker[i]);
            }
            return distance;
        }


        double CalculateTotalDistanceForOneBiker(Biker biker)
        {
            double distance = 0;
            double wheelLength = Math.PI * biker.diameter;
            for (int i = 0; i < biker.record.Length; i++)
            {
                distance += wheelLength * biker.record[i].rotations;
            }
            return distance;
        }



        public struct NameAndSecond
        {
            public string name;
            public int second;
            public NameAndSecond(string name, int second)
            {
                this.name = name;
                this.second = second;
            }
        }

        public struct Biker
        {
            public string name;
            public double diameter;
            public Record[] record;
            public Biker(string name, double diameter, Record[] record)
            {
                this.name = name;
                this.diameter = diameter;
                this.record = record;
            }
        }

        public struct Record
        {
            public double rotations;
            public int second;
            public Record(double rotations, int second)
            {   
                this.rotations = rotations;
                this.second = second;
            }
        }


        

    }
}

