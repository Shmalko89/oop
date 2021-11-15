using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop5
{
    public class RationalNumbers
    {
        private int _numerator;

        private int _denominator;

        public int Numerator => _numerator;

        public int Denomirator => _denominator;

        public RationalNumbers(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        public static RationalNumbers operator +(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator);
        }

        public static RationalNumbers operator -(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator);
        }

        public static RationalNumbers operator *(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._numerator * b._numerator, a._denominator * b._denominator);
        }

        public static RationalNumbers operator /(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._numerator * b._denominator, a._denominator * b._numerator);
        }

        public static RationalNumbers operator ++(RationalNumbers a)
        {
            return a + new RationalNumbers(1, 1);
        }

        public static RationalNumbers operator --(RationalNumbers a)
        {
            return a + new RationalNumbers(1, 1);
        }

        public static bool operator >(RationalNumbers a, RationalNumbers b)
        {
            if (a._numerator * b._denominator > b._numerator * a._denominator)
                return true;
            else
                return false;
        }

        public static bool operator <(RationalNumbers a, RationalNumbers b)
        {
            if (a._numerator * b._denominator < b._numerator * a._denominator)
                return true;
            else
                return false;
        }

        public static bool operator ==(RationalNumbers a, RationalNumbers b) => a.Equals(b);


        public static bool operator !=(RationalNumbers a, RationalNumbers b) => !a.Equals(b);


        public static bool operator >=(RationalNumbers a, RationalNumbers b)
        {
            if (a._numerator / a._denominator >= b._numerator / b._denominator)
                return true;
            else
                return false;
        }

        public static bool operator <=(RationalNumbers a, RationalNumbers b)
        {
            if (a._numerator / a._denominator <= b._numerator / b._denominator)
                return true;
            else
                return false;
        }

        public override string ToString() => $"{_numerator}/{_denominator}";

        public static explicit operator int(RationalNumbers a)
        {
            return (int)a._numerator / a._denominator;
        }

        public static explicit operator float(RationalNumbers a)
        {
            return (float)a._numerator / a._denominator;
        }

        public static explicit operator double(RationalNumbers a)
        {
            return (double)a._numerator / a._denominator;
        }

        public bool Equals(RationalNumbers other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return _numerator == other._numerator
                && _denominator == other._denominator;


        }

        public override bool Equals(object obj) => Equals(obj as RationalNumbers);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = _numerator.GetHashCode();

                hash = (hash * 397) ^ _denominator.GetHashCode();


                return hash;
            }
        }
    }
}
