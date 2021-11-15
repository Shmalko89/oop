using System;

namespace oop7
{
    class Program
    {
        static void Main(string[] args)
        {
            var txt = "привет";
            Console.WriteLine(txt);
            var coder = new ACoder();
            var codeText = coder.Encoder(txt);
            Console.WriteLine(codeText);
            var decodeText = coder.Decode(codeText);
            Console.WriteLine(decodeText);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
