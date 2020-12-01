﻿using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Time
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    struct Time : IComparable<Time>, IEquatable<Time>
    {


        public byte Hours { get; }
        public byte Minutes { get; }
        public byte Seconds { get; }

        public Time(byte hours, byte minutes = 0, byte seconds = 0)
        {
            Seconds = seconds;
            Hours = hours;
            Minutes = minutes;
        }

        public Time(string timeString)
        {
            string[] choppedString = timeString.Split(":");
            Hours = byte.Parse(choppedString[0]);
            Minutes = byte.Parse(choppedString[1]);
            Seconds = byte.Parse(choppedString[2]);
        }

        override public string ToString() => $"{Hours}:{Minutes}:{Seconds}";


        public static bool operator ==(Time leftTime, Time rightTime) => leftTime.Equals(rightTime);
        public static bool operator !=(Time leftTime, Time rightTime) => !(leftTime == rightTime);
        public static bool operator >(Time leftTime, Time rightTime) => leftTime.CompareTo(rightTime) > 0;
        public static bool operator >=(Time leftTime, Time rightTime) => leftTime.CompareTo(rightTime) >= 0;
        public static bool operator <(Time leftTime, Time rightTime) => leftTime.CompareTo(rightTime) < 0;
        public static bool operator <=(Time leftTime, Time rightTime) => leftTime.CompareTo(rightTime) <= 0;


        public int CompareTo([AllowNull] Time other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Hours > other.Hours)
            {
                return 1;
            }

            if (this.Hours < other.Hours)
            {
                return -1;
            }

            if (this.Minutes > other.Minutes)
            {
                return 1;
            }

            if (this.Minutes < other.Minutes)
            {
                return -1;
            }

            if (this.Seconds > other.Seconds)
            {
                return 1;
            }

            if (this.Seconds < other.Seconds)
            {
                return -1;
            }

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
    }
}