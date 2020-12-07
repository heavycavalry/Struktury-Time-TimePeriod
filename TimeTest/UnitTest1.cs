using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Time.Test
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Time time = new Time(1);
            Assert.AreEqual("01:00:00", time.ToString());

        }

        [TestMethod]
        public void PlusTest()
        {
            TimePeriod tp = new TimePeriod(12, 12, 12);
            TimePeriod tp2 = new TimePeriod(23, 55, 55);
            Time time = new Time(1, 5, 55);

            Assert.AreEqual("13:18:07", time.Plus(tp).ToString());

            Assert.AreEqual("01:01:50", time.Plus(tp2).ToString());

        }

        [TestMethod]
        public void MinusTest()
        {
            TimePeriod tp = new TimePeriod(12, 30, 30);
            TimePeriod tp2 = new TimePeriod(24, 30, 30);
            Time time = new Time(12, 30, 30);

            Assert.AreEqual("00:00:00", time.Minus(tp).ToString());

            Assert.AreEqual("12:00:00", time.Minus(tp2).ToString());

        }

        [TestMethod]
        public void TimeEqualsTest()
        {

            Time time = new Time(00, 00, 05);
            Time time2 = new Time(23, 12, 12);
            Time time3 = new Time(0, 0, 5);

            Assert.AreEqual(true, time.Equals(time3));
            Assert.AreEqual(false, time.Equals(time2));

        }

        [TestMethod]

        public void TimePeriodEqualsTest()
        {
            TimePeriod tp = new TimePeriod(4, 2, 56);
            TimePeriod tp2 = new TimePeriod("04:02:56");
            TimePeriod tp3 = new TimePeriod(12, 12, 12);
            TimePeriod tp4 = new TimePeriod(43932);

            Assert.AreEqual(true, tp.Equals(tp2));
            Assert.AreEqual(false, tp2.Equals(tp3));
            Assert.AreEqual(true, tp3.Equals(tp4));
            Assert.AreEqual(true, tp4.Equals(tp3));
        }

        [TestMethod]

        public void CompareToTimeTest()
        {
            Time time = new Time(00, 00, 05);
            Time time2 = new Time(23, 12, 12);
            Time time3 = new Time(0, 0, 5);
            Time time4 = new Time(22, 24, 52);

            Assert.IsTrue(time2.CompareTo(time4) > 0);
            Assert.IsTrue(time4.CompareTo(time2) < 0);
            Assert.IsTrue(time.CompareTo(time3) == 0);
            Assert.IsTrue(time3.CompareTo(time2) < 0);

        }

        [TestMethod]

        public void CompareToTimePeriodTest()
        {
            TimePeriod tp = new TimePeriod(4, 2, 56);
            TimePeriod tp2 = new TimePeriod("04:02:56");
            TimePeriod tp3 = new TimePeriod(12, 12, 12);
            TimePeriod tp4 = new TimePeriod(43932);

            Assert.IsTrue(tp.CompareTo(tp3) < 0);
            Assert.IsTrue(tp.CompareTo(tp2) == 0);
            Assert.IsTrue(tp3.CompareTo(tp4) == 0);
            Assert.IsTrue(tp3.CompareTo(tp2) > 0);

        }


        [TestMethod]

        public void TimePeriodConstructorsTest()
        {
            Time t1 = new Time(35500);
            Time t2 = new Time(24500);
            Time t3 = new Time(15500);


            Assert.IsTrue(new TimePeriod(t1, t2).TotalSeconds == 11000);
            Assert.IsTrue(new TimePeriod(t3, t1).TotalSeconds == -20000);

        }

        [TestMethod]

        public void TimePeriodPlusOperatorTest()
        {
            TimePeriod t1 = new TimePeriod(35500);
            TimePeriod t2 = new TimePeriod(50000);

            Assert.IsTrue((t1 + t2).TotalSeconds == 85500);

        }

        [TestMethod]

        public void TimePeriodMinusOperatorTest()
        {
            TimePeriod t1 = new TimePeriod(35500);
            TimePeriod t2 = new TimePeriod(50000);

            Assert.IsTrue((t1 - t2).TotalSeconds == -14500);
            Assert.IsTrue((t2 - t1).TotalSeconds == 14500);

        }

        [TestMethod]

        public void TimePeriodEqualOperatorTest()
        {
            TimePeriod t1 = new TimePeriod(35500);
            TimePeriod t2 = new TimePeriod(50000);
            TimePeriod t3 = new TimePeriod(50000);

            Assert.IsFalse(t1 == t2);
            Assert.IsTrue(t2 == t3);

        }

        [TestMethod]

        public void TimePeriodOperatorsTest()
        {
            TimePeriod t1 = new TimePeriod(35500);
            TimePeriod t2 = new TimePeriod(50000);
            TimePeriod t3 = new TimePeriod(23, 59, 59);
            TimePeriod t4 = new TimePeriod(50000);

            Assert.IsTrue(t1 < t2);
            Assert.IsTrue(t3 > t2);
            Assert.IsTrue(t2 >= t4);
            Assert.IsFalse(t3 <= t2);

        }
    }
}
