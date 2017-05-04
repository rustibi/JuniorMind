using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

namespace ClockAlarm
{
    [TestClass]
    public class ClockAlarmTests
    {

        [TestMethod]
        public void TestAlarm3Days()
        {
            var alarm = new Alarm[] { new Alarm(Days.Monday | Days.Thursday | Days.Wednesday, 6) };
            Assert.AreEqual(true, IsAlarm(alarm, Days.Monday, 6));
        }

        [TestMethod]
        public void TestAlarm3Days1Day()
        {
            var alarm = new Alarm[] {new Alarm (Days.Monday | Days.Thursday | Days.Wednesday, 16),
                new Alarm (Days.Sunday, 10)};
            Assert.AreEqual(true, IsAlarm(alarm, Days.Sunday, 10));
            Assert.AreEqual(false, IsAlarm(alarm, Days.Friday, 16));
        }



        public bool IsAlarm(Alarm[] alarm, Days day, int hour)
        {
            for (int i = 0; i < alarm.Length; i++)
            {
                if ((alarm[i].day & day) != 0 && (alarm[i].hour == hour))
                {
                    return true;
                } 
            }
            return false;
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
