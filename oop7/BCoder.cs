using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oop7
{
    public class BCoder : ICoder
    {
       
        char[] alphabet = Enumerable.Range(0, 32).Select((x, i) => (char)('а' + i)).ToArray();


        public string Decode(string text)
        {
            string txt = "";
            for (int i = 0; i < text.Length; i++)
                txt = txt + (char)(alphabet.Length - text[i]);
            return txt;
        }

        public string Encoder(string text)
        {
            string txt = "";
            for (int i = 0; i < text.Length; i++)
                txt = txt + (char)(alphabet.Length - text[i]);
            return txt;
        }       
    }
}
