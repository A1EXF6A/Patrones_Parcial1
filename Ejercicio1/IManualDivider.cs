using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public interface IManualDivider
    {
        (string Quotient, string Remainder) Divide(string dividend, string divisor);
    }
}
