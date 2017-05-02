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
            Alarm alarm = new Alarm (Days.Monday, 6);
            bool testResult = true;
            var functionResult = IsAlarm(alarm);
            Assert.AreEqual(testResult, functionResult);
        }

        [TestMethod]
        public void TestStructDays2()
        {
            Alarm alarm = new Alarm (AddAlarm(Days.Monday | Days.Thursday | Days.Wednesday), 6);
            bool testResult =  true;
            var functionResult = IsAlarm(alarm);
            Assert.AreEqual(testResult, functionResult);
        }

        [TestMethod]
        public void TestStructDays3()
        {
            Alarm alarm = new Alarm(AddAlarm(Days.Monday | Days.Thursday | Days.Wednesday), 0);
            bool testResult = false;
            var functionResult = IsAlarm(alarm);
            Assert.AreEqual(testResult, functionResult);
        }

        [TestMethod]
        public void TestStructDays4()
        {
            AddAlarm(Days.Monday);
            Assert.AreEqual(Days.Friday|Days.Sunday, AddAlarm(Days.Friday|Days.Sunday));
        }



        public bool IsAlarm(Alarm alarm)
        {
            return (alarm.hour != 0);
        }


        Days AddAlarm(Days day)
        {
            return day;
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
