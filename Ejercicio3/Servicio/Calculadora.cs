using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio3.Interfaces;

namespace Ejercicio3.Servicio
{
    public class Calculadora : ICalculadora
    {
        public int Multiplicar(params int[] numeros)
        {
            int producto = 1;
            foreach (int number in numeros)
                producto *= number;

            return producto;
        }
    }
}
