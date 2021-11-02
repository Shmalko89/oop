using System;

namespace oop
{
    class Program
    {
        static void Main(string[] args)
        {
            BillInBank bill = new BillInBank(125847.23, BillType.Deposit);
            
            //для примера 1
            /*
            Console.WriteLine("Добрый день!");
            Console.WriteLine($"Номер Вашего счета: {bill.GetBillNumber()} рублей.");
            Console.WriteLine($"На Вашем счету: {bill.GetBalance()}");
            Console.WriteLine($"Тип Вашего счета: {bill.GetBillType()}");
            Console.ReadKey();
            Console.Clear();
            */
            //для примера 4
            Console.WriteLine("Добрый день!");
            Console.WriteLine($"Номер Вашего счета: {bill.BillNumber}");
            Console.WriteLine($"На Вашем счету: {bill.Balance} рублей.");
            Console.WriteLine($"Тип Вашего счета: {bill.BillType}");
            Console.ReadKey();
            Console.Clear();


            

        }
    }
}
