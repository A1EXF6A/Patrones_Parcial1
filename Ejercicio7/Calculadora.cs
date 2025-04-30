using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7
{
    // S: Esta clase tiene una única responsabilidad: realizar operaciones matemáticas (suma de fracciones)

    public class Calculadora
    {
        public Fraccion Sumar(Fraccion[] fracciones)
        {
            int num = 0;
            int den = 1;

            foreach (var f in fracciones)
            {
                num = num * f.Denominador + f.Numerador * den;
                den = den * f.Denominador;
            }

            var resultado = new Fraccion(num, den);
            resultado.Simplificar(); // se reutiliza lógica de la clase Fraccion (S)
            return resultado;
        }
    }

}
