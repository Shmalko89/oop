using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop7
{
    public class ACoder : ICoder
    {

        public string Decode(string text)
        {
            string txt = "";
            for (int i = 0; i < text.Length; i++)
                txt = txt + (char)(text[i] - 1);
            return txt;
        }

        public string Encoder(string text)
        {
            string txt = "";
            for (int i = 0; i < text.Length; i++)
                txt = txt + (char)(text[i] + 1);
            return txt;
        }
    }
}
