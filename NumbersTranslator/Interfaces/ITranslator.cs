using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersTranslator
{
    public interface ITranslator
    {
        string Translate(int number);
    }
}
