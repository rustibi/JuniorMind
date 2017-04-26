using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ClockAlarm
{
    [TestClass]
    public class ClockAlarmTests
    {
        [TestMethod]
        public void TestEnumDays()
        {
            Assert.AreEqual(1, (int)Days.Monday);
        }

        [TestMethod]
        public void TestStructDays1()
        {
            var alarm = new Alarm[] { new Alarm(Days.Monday, 6) };
            List<bool> testResult = new List<bool>{ true };
            var functionResult = IsAlarm(alarm);
            CollectionAssert.AreEqual(testResult, functionResult);
        }

        [TestMethod]
        public void TestStructDays2()
        {
            var alarm = new Alarm[] { new Alarm(Days.Monday, 6), new Alarm(Days.Thursday, 6), new Alarm(Days.Wednesday, 6) };
            List<bool> testResult = new List<bool> { true, true, true };
            var functionResult = IsAlarm(alarm);
            CollectionAssert.AreEqual(testResult, functionResult);
        }


        public List<bool> IsAlarm(Alarm[] alarm)
        {
            List<bool> result = new List<bool>();
            int i = 0;
            while (i < alarm.Length)
            {
                if (alarm[i++].hour != 0)
                {
                    result.Add(true);
                }
                else
                    result.Add(false);     
            }  
            return result;
        }


        [Flags]
        public enum Days
        {
            Monday = 0x01,
            Tuesday = 0x02,
            Wednesday = 0x04,
            Thursday = 0x08,
            Friday = 0x20,
            Saturday = 0x40,
            Sunday = 0x80
        }


        public struct Alarm
        {
            public Days day;
            public int hour;
            public Alarm (Days day, int hour)
            {
                this.day = day;
                this.hour = hour;
            }
        }
    }
}
