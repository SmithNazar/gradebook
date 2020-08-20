using System;

namespace GradeBook
{
    public class Stats
    {
        public double Avarage
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public double Sum;
        public int Count;
        public char Letter
        {
            get
            {
                switch (Avarage)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';
                }

            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Stats()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }
    }
}