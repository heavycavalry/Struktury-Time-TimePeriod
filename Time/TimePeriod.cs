using System;
using System.Diagnostics.CodeAnalysis;

namespace Time
{

    //zmienna typu Time opisuje punkt w czasie, w przedziale 00:00:00 … 23:59:59
    //(weź pod uwagę arytmetykę modulo w godzinach %24 oraz minutach i sekundach %60
    //-- wtedy, kiedy to będzie sensowne i wymagane)

    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {

        public long TotalSeconds { get { return totalSeconds; } }
        readonly private long totalSeconds;
        public long Hours { get => totalSeconds / 3600; }
        public long Minutes { get => (totalSeconds % 3600) / 60; }
        public long Seconds { get => totalSeconds % 60; }

        public TimePeriod(long seconds) => totalSeconds = seconds;

        public TimePeriod(long h, long m, long s) => totalSeconds = ToSeconds(h, m, s);

        public TimePeriod(Time t1, Time t2)
        {
            long sec_t1 = ToSeconds(t1);
            long sec_t2 = ToSeconds(t2);
            long period = sec_t1 - sec_t2;

            totalSeconds = period;

        }

        public TimePeriod(string timeString)
        {
            string[] choppedString = timeString.Split(":");
            long hours = long.Parse(choppedString[0]);
            long minutes = long.Parse(choppedString[1]);
            long seconds = long.Parse(choppedString[2]);

            totalSeconds = ToSeconds(hours, minutes, seconds);
        }

        override public string ToString() => $"{Hours}:{Minutes:D2}:{Seconds:D2}";

        public static long ToSeconds(Time t) => t.Hours * 3600 + t.Minutes * 60 + t.Seconds;
        public static long ToSeconds(long h, long m, long s) => h * 3600 + m * 60 + s;

        public bool Equals([AllowNull] TimePeriod other)
        {

            if (this.CompareTo(other) == 0)
            {
                return true;
            }
            return false;
        }

        public int CompareTo([AllowNull] TimePeriod other)
        {
            return this.totalSeconds.CompareTo(other.totalSeconds);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(totalSeconds);
        }

        public override bool Equals(object obj)
        {
            return false;
        }

        public static bool operator ==(TimePeriod leftTime, TimePeriod rightTime) => leftTime.Equals(rightTime);
        public static bool operator !=(TimePeriod leftTime, TimePeriod rightTime) => !(leftTime.Equals(rightTime));
        public static bool operator >(TimePeriod leftTime, TimePeriod rightTime) => leftTime.CompareTo(rightTime) > 0;
        public static bool operator >=(TimePeriod leftTime, TimePeriod rightTime) => leftTime.CompareTo(rightTime) >= 0;
        public static bool operator <(TimePeriod leftTime, TimePeriod rightTime) => leftTime.CompareTo(rightTime) < 0;
        public static bool operator <=(TimePeriod leftTime, TimePeriod rightTime) => leftTime.CompareTo(rightTime) <= 0;
        public static TimePeriod operator +(TimePeriod leftTime, TimePeriod rightTime) => new TimePeriod(leftTime.totalSeconds + rightTime.totalSeconds);
        public static TimePeriod operator -(TimePeriod leftTime, TimePeriod rightTime) => new TimePeriod(leftTime.totalSeconds - rightTime.totalSeconds);


    }

}
