using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop7
{
    public interface ICoder
    {
        string Encoder(string text);
        string Decode(string text);
    }
}
