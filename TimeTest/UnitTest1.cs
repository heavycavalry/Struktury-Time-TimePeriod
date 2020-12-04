using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Time.Test
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Time time = new Time(1);
            Assert.AreEqual("01:00:00", time.ToString());

        }

        [TestMethod]
        public void Plus()
        {
            TimePeriod tp = new TimePeriod(12, 12, 12);
            TimePeriod tp2 = new TimePeriod(23, 55, 55);
            Time time = new Time(1,5,55);
            
            Assert.AreEqual("13:18:07", time.Plus(tp).ToString());

            Assert.AreEqual("01:01:50", time.Plus(tp2).ToString());

        }

    }
}
