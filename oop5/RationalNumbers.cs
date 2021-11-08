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

        public RationalNumbers (int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        public static RationalNumbers operator + (RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator);
        }

        public static RationalNumbers operator - (RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator);
        }

        public static RationalNumbers operator * (RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._numerator * b._numerator, a._denominator * b._denominator);
        }

        public static RationalNumbers operator / (RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._numerator * b._denominator, a._denominator * b._numerator);
        }

        public static RationalNumbers operator ++ (RationalNumbers a)
        {
            return a + new RationalNumbers(1, 1);
        } 

        public static RationalNumbers operator -- (RationalNumbers a)
        {
            return a + new RationalNumbers(1, 1);
        }

        public static bool operator > (RationalNumbers a, RationalNumbers b)
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


    }
}
