using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class DivisionApp
    {
        // Inyección de dependencias para entrada, lógica, salida (Principio D - Dependency Inversion)
        private readonly INumberInput _input;
        private readonly IManualDivider _divider;
        private readonly IOutputWriter _output;

        public DivisionApp(INumberInput input, IManualDivider divider, IOutputWriter output)
        {
            _input = input;
            _divider = divider;
            _output = output;
        }

        public void Run()
        {
            // Lee los números
            var (A, B) = _input.ReadNumbers();
            try
            {
                // Ejecuta la división
                var (quotient, remainder) = _divider.Divide(A, B);

                // Imprime resultado
                _output.Write($"Cociente: {quotient}\nResto: {remainder}");
            }
            catch (DivideByZeroException)
            {
                _output.Write("Error: Division por cero.");
            }
        }
    }
}
