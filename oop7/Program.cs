using System;
using System.Linq;
using System.Text;

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

            var txt1 = "aбв";
            var coder1 = new BCoder();
            var codeText1 = coder1.Encoder(txt1);
            Console.WriteLine(codeText1);
            var decodeText1 = coder.Decode(codeText1);
            Console.WriteLine(decodeText1);
            Console.ReadLine();
            Console.Clear();

           
        }
    }
}
