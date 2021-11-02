using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop2
{
    class revers
    {
        public void Reverse(string str)
        {
            Console.WriteLine("Введите строку: ");
            str = Console.ReadLine();

            if (str != "")
            {
                for (int i = str.Length; i > 0; i--)
                {
                    Console.Write(str[i - 1]);
                }
            }
        }
    }   
}
