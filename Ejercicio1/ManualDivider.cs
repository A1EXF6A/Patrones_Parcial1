using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class ManualDivider : IManualDivider
    {
        public (string Quotient, string Remainder) Divide(string dividend, string divisor)
        {
            if (divisor == "0") throw new DivideByZeroException(); // Manejo de división por cero

            string result = "";
            string partial = "";
            int d = int.Parse(divisor); // Convertimos el divisor a entero (asumimos que cabe en int)

            // Recorremos cada dígito del dividendo
            foreach (char digit in dividend)
            {
                partial += digit;
                partial = TrimLeadingZeros(partial);
                if (partial == "") partial = "0";

                int partialInt = int.Parse(partial);
                if (partialInt < d)
                {
                    // Si aún no se puede dividir, se añade 0 al cociente
                    result += result.Length > 0 ? "0" : "";
                }
                else
                {
                    // División manual: resta repetida
                    int count = 0;
                    while (partialInt >= d)
                    {
                        partialInt -= d;
                        count++;
                    }
                    result += count.ToString();
                    partial = partialInt.ToString();
                }
            }

            // El resto es el último valor de partial
            string remainder = TrimLeadingZeros(partial);
            if (string.IsNullOrEmpty(remainder)) remainder = "0";

            return (result == "" ? "0" : result, remainder);
        }
        private string TrimLeadingZeros(string str)
        {
            return str.TrimStart('0');
        }
    }
}
