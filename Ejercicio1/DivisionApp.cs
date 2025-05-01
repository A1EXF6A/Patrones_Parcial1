using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class DivisionApp
    {
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
            var (A, B) = _input.ReadNumbers();
            try
            {
                var (quotient, remainder, display) = _divider.Divide(A, B);
                _output.Write(display);
            }
            catch (DivideByZeroException)
            {
                _output.Write("Error: Division por cero.");
            }
        }
    }
}
