﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Time
{
    struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        readonly private long totalSeconds;
        public long hours { get => totalSeconds / 3600; }
        public long minutes { get => (totalSeconds % 3600) / 60; }
        public long seconds { get => totalSeconds % 60; }

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

        override public string ToString() => $"{hours}:{minutes}:{seconds}";

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
    }


}