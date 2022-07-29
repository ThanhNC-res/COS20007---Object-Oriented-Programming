using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Clock;

namespace Clock
{
    [TestClass]
    public class clockTest
    {
        [TestMethod]
        public void IncrementTest()
        {
            Counter testClock = new Counter("testClock", 0);
            Clock clock = new Clock();

            testClock.CountIncre();
            testClock.CountIncre();

            Assert.AreEqual(2, testClock.Count, "Count increase 2");

        }

        [TestMethod]
        public void Init_Test()
        {
            Counter testClock = new Counter("testClock", 0);
            Clock clock = new Clock();

            testClock.ResetCount();

            Assert.AreEqual(0, testClock.Count, "Clock count reset to 0");
        }

        [TestMethod]
        public void Timers_test()
        {
            Clock clock = new Clock();

            for (int i = 0; i < 40; i++)
            {
                clock.Tick();
            }
            Assert.AreEqual(40, clock.Seconds, "Test the second tick to number 40");

            for (int i = 0; i < 60; i++)
            {
                clock.Tick();
            }
            Assert.AreEqual(1, clock.Minutes, "Test the second tick to number 54");

            for (int i = 0; i < 3600; i++)
            {
                clock.Tick();
            }
            Assert.AreEqual(1, clock.Hours, "Test the second tick to number 54");
        }

        [TestMethod]
        public void ResetClockTest()
        {
            Clock clock = new Clock();
            for (int i = 0; i < 86400; i++)
            {
                clock.Tick();
                if (clock.Hours == 24)
                {
                    clock.Resetclock();
                }
            }
            Assert.AreEqual(0, clock.Seconds, "Clock is reseted when hour run to 24");

        }
    }
}
