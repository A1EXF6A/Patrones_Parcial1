using Ejercicio3.Interfaces;
using System;

namespace RomanMultiplication.Application.Services
{
    public class EntradaDatos : IEntradaDatos
    {
        private readonly IConvertirNumero _convertir;

        public EntradaDatos(IConvertirNumero convertir)
        {
            _convertir = convertir;
        }

        public string LeerNumeroRomano(string dato)
        {
            string entrada;
            do
            {
                Console.Write(dato);
                entrada = Console.ReadLine()?.ToUpper() ?? "";

                if (!_convertir.EsValidoNumeroRomano(entrada))
                    Console.WriteLine("❌ Error: Número romano inválido. Inténtelo nuevamente.\n");
            }
            while (!_convertir.EsValidoNumeroRomano(entrada));

            return entrada;
        }
    }
}
