using System;

namespace oop6
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new BillInBank(127, BillType.Deposit);
            var b = new BillInBank(182, BillType.Deposit);

            Console.WriteLine(a == b);
            Console.WriteLine(a !=b);

            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
        }
    }
}
