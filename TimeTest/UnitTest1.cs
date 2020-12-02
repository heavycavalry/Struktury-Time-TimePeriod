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
    }
}
