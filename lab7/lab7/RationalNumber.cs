using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace lab7
{
    public class RationalNumber : IComparable<RationalNumber>
    {
        public enum RepresentationVariant { Fraction, DecimalFraction }

        private long denominator;
        public long Numerator { get; set; }

        public long Denominator
        {
            get => denominator;
            set
            {
                if (value < 1)
                {
                    throw new ApplicationException(
                        "Invalid denominator.");
                }

                denominator = value;
            }
        }

        public RationalNumber()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public RationalNumber(long numerator, long denominator)
        {
            if (denominator < 1)
            {
                throw new DivideByZeroException();
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public static RationalNumber operator -(RationalNumber number1, RationalNumber number2)
        {
            RationalNumber result = new RationalNumber();
            result.Numerator = number1.Numerator * number2.Denominator - number2.Numerator * number1.Denominator;
            result.Denominator = number1.Denominator * number2.Denominator;
            result.DecreaseFraction();

            return result;
        }

        public static RationalNumber operator +(RationalNumber number1, RationalNumber number2)
        {
            RationalNumber result = new RationalNumber();
            result.Numerator = number1.Numerator * number2.Denominator + number2.Numerator * number1.Denominator;
            result.Denominator = number1.Denominator * number2.Denominator;
            result.DecreaseFraction();

            return result;
        }

        public static RationalNumber operator *(RationalNumber number1, RationalNumber number2)
        {
            RationalNumber result = new RationalNumber();
            result.Numerator = number1.Numerator * number2.Numerator;
            result.Denominator = number1.Denominator * number2.Denominator;
            result.DecreaseFraction();

            return result;
        }

        public static RationalNumber operator /(RationalNumber number1, RationalNumber number2)
        {
            if (number2.Numerator == 0)
            {
                throw new DivideByZeroException();
            }

            RationalNumber result = new RationalNumber();
            result.Numerator = number1.Numerator * number2.Denominator;
            result.Denominator = number1.Denominator * number2.Numerator;
            result.DecreaseFraction();

            return result;
        }

        public static bool operator >(RationalNumber number1, RationalNumber number2) => number1.CompareTo(number2) > 0;

        public static bool operator >=(RationalNumber number1, RationalNumber number2) => number1.CompareTo(number2) >= 0;

        public static bool operator <(RationalNumber number1, RationalNumber number2) => number1.CompareTo(number2) < 0;

        public static bool operator <=(RationalNumber number1, RationalNumber number2) => number1.CompareTo(number2) <= 0;

        public static bool operator ==(RationalNumber number1, RationalNumber number2) => number1.Equals(number2);

        public static bool operator !=(RationalNumber number1, RationalNumber number2) => !number1.Equals(number2);

        public static explicit operator int(RationalNumber number) => (int)number.ToDouble();

        public static explicit operator double(RationalNumber number) => number.ToDouble();

        public static implicit operator RationalNumber(int number) => new RationalNumber(number, 1);

        public static implicit operator RationalNumber(double number) => DecimalToRational(number);

        private void DecreaseFraction()
        {
            long greatestCommonDivisor = Math.Abs(Numerator) > Math.Abs(Denominator)
                ? GreatestCommonDivisor(Math.Abs(Numerator), Denominator)
                : GreatestCommonDivisor(Math.Abs(Denominator), Math.Abs(Numerator));

            Numerator /= greatestCommonDivisor;
            Denominator /= greatestCommonDivisor;
        }

        public static long GreatestCommonDivisor(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }

            return GreatestCommonDivisor(b, a % b);
        }

        public static RationalNumber DecimalToRational(double number)
        {
            RationalNumber rationalNumber;
            long numerator;
            long denominator = 1;
            string s = number.ToString();
            int digitsAtferDot = s.Length - 1 - s.IndexOf('.');

            for (int i = 0; i < digitsAtferDot; i++)
            {
                number *= 10;
                denominator *= 10;
            }
            numerator = (long)Math.Round(number);
            rationalNumber = new RationalNumber(numerator, denominator);
            rationalNumber.DecreaseFraction();

            return rationalNumber;
        }

        public static RationalNumber StringToNumber(string s)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            RationalNumber rationalNumber;
            string fractionPattern = "^[+-]?[1-9][0-9]*/[1-9][0-9]*$|^0/[1-9][0-9]*$";
            string floatingPointPattern = "^[+-]?([0-9]+([.][0-9]*)?$|^[.][0-9]+)$";

            if (Regex.IsMatch(s, fractionPattern))
            {
                int sign = s[0] == '-' ? -1 : 1;
                int numberBeginPosition = Char.IsDigit(s[0]) ? 0 : 1;
                int fractionLinePos = s.IndexOf('/');
                string numerator = s.Substring(numberBeginPosition, fractionLinePos - numberBeginPosition);
                string denominator = s.Substring(fractionLinePos + 1);

                rationalNumber = new RationalNumber(sign * Int64.Parse(numerator), Int64.Parse(denominator));

                return rationalNumber;
            }
            else if (Regex.IsMatch(s, floatingPointPattern))
            {
                rationalNumber = DecimalToRational(Double.Parse(s, formatter));
                return rationalNumber;
            }
            else
            {
                throw new ApplicationException("Invalid string representation of rational number");
            }
        }

        public int CompareTo(RationalNumber other)
        {
            double accuracy = 0.0000000001;
            double delta = Math.Abs(this.ToDouble() - other.ToDouble());

            if (delta < accuracy)
            {
                return 0;
            }
            else
            {
                return this.ToDouble().CompareTo(other.ToDouble());
            }
        }

        public override bool Equals(object obj)
        {

            if (obj is RationalNumber rationalNumber)
            {
                double accuracy = 0.0000000001;
                double delta = Math.Abs(this.ToDouble() - rationalNumber.ToDouble());

                return delta < accuracy;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator.GetHashCode()) * (Denominator.GetHashCode());
            }
        }

        public string ToString(RepresentationVariant mode)
        {
            switch (mode)
            {
                case RepresentationVariant.Fraction:
                    {
                        return $"{Numerator}/{Denominator}";
                    }
                case RepresentationVariant.DecimalFraction:
                    {
                        return ToDouble().ToString();
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        public double ToDouble()
        {
            return (double)Numerator / Denominator;
        }

    }
}