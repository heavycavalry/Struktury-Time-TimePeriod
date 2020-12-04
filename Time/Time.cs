﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Time
{
    public struct Time : IComparable<Time>, IEquatable<Time>
    {
        private int totalseconds
        {
            get
            {
                return Hours * 3600 + Minutes * 60 + Seconds;

            }
        }
        public byte Hours { get; }
        public byte Minutes { get; }
        public byte Seconds { get; }


        public Time(byte hours, byte minutes = 0, byte seconds = 0)
        {
            Seconds = seconds;
            Hours = hours;
            Minutes = minutes;

            if (hours > 24 || hours < 0 || minutes >= 60 || minutes < 0 || seconds >= 60 || seconds < 0) { throw new ArgumentOutOfRangeException(); }

        }

        public Time(long totalseconds)
        {
            if (totalseconds > (24 * 3600))
            {
                throw new ArgumentOutOfRangeException();
            }

            Hours = Convert.ToByte(totalseconds / 3600);
            Minutes = Convert.ToByte(totalseconds % 3600 / 60);
            Seconds = Convert.ToByte(totalseconds % 60);
        }

        public Time(string timeString)
        {
            string[] choppedString = timeString.Split(":");
            Hours = byte.Parse(choppedString[0]);
            Minutes = byte.Parse(choppedString[1]);
            Seconds = byte.Parse(choppedString[2]);
        }

        override public string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";


        public static bool operator ==(Time leftTime, Time rightTime) => leftTime.Equals(rightTime);
        public static bool operator !=(Time leftTime, Time rightTime) => !(leftTime == rightTime);
        public static bool operator >(Time leftTime, Time rightTime) => leftTime.CompareTo(rightTime) > 0;
        public static bool operator >=(Time leftTime, Time rightTime) => leftTime.CompareTo(rightTime) >= 0;
        public static bool operator <(Time leftTime, Time rightTime) => leftTime.CompareTo(rightTime) < 0;
        public static bool operator <=(Time leftTime, Time rightTime) => leftTime.CompareTo(rightTime) <= 0;


        public Time Plus(TimePeriod tp)
        {
            long total = this.totalseconds + tp.totalsecondss;
            Time newTime = new Time(total);
            return newTime;
        }

        public int CompareTo([AllowNull] Time other)
        {

            int hd = this.Hours - other.Hours;
            int md = this.Minutes - other.Minutes;
            int sd = this.Seconds - other.Seconds;

            if (hd != 0) return hd;
            if (md != 0) return md;
            if (sd != 0) return sd;
            return 0;

        }

        public bool Equals([AllowNull] Time other)
        {
            if (this.CompareTo(other) == 0)
            {
                return true;
            }
            return false;
        }

        override public bool Equals([AllowNull] object o)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
    }
}
