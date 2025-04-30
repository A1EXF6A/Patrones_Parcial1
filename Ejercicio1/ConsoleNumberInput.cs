using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class ConsoleNumberInput : INumberInput
    {
        public (string A, string B) ReadNumbers()
        {
            string A = ReadValidInteger("Ingrese el dividendo (A): ");
            string B = ReadValidInteger("Ingrese el divisor (B): ");

            return (A.TrimStart('0'), B.TrimStart('0'));
        }
    
     private string ReadValidInteger(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();
                if (!Regex.IsMatch(input, "^\\d{1,150}$"))
                {
                    Console.WriteLine("Entrada inválida. Ingrese solo números enteros positivos (máximo 150 dígitos).\n");
                    input = null;
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }
    }
}
