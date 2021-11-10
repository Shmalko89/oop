using System;

namespace oop5
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new RationalNumbers(5, 7);
            var b = new RationalNumbers(3, 8);

            Console.WriteLine(a);
            Console.WriteLine(b.ToString());

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
            Console.WriteLine(a > b);
            Console.WriteLine(a < b);
            Console.WriteLine(a >= b);
            Console.WriteLine(a <= b);
            Console.WriteLine(++a);
            Console.WriteLine(--b);
            Console.WriteLine(a == b);
            Console.WriteLine(a != b);

            Console.ReadLine();
            Console.Clear();
        }
    }
}
