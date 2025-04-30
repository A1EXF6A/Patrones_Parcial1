using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(string result)
        {
            Console.WriteLine(result);
        }
    }
}
