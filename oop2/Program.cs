using System;

namespace oop2
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "hello";
            revers rev = new revers();
            rev.Reverse(str);
            Console.ReadLine();
            Console.Clear();


            var bill1 = new BillInBank(250, BillType.Deposit);
            var bill2 = new BillInBank(200, BillType.Deposit);

            bill2.MoneyTransfer(bill1, 50);

            Console.WriteLine($"На Вашем счету: {bill1.Balance} рублей.");
            Console.WriteLine($"На Вашем счету: {bill2.Balance} рублей.");


        }
    }
}
