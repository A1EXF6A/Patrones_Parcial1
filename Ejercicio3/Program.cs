using Ejercicio3.Interfaces;
using Ejercicio3.Servicio;
using RomanMultiplication.Application.Services;

namespace Ejercicio3;

public class Program
{
    private const int maximoValor = 3999;

    public static void Main(string[] args)
    {
        IConvertirNumero convertir = new ConvertirNumeroRomano();
        ICalculadora calculadora = new Calculadora();
        IEntradaDatos leerDato = new EntradaDatos(convertir);

        Console.WriteLine("=== Multiplicador de Números Romanos ===\n");

        while (true)
        {
            string romano1 = leerDato.LeerNumeroRomano("Ingrese el primer número romano: ");
            string romano2 = leerDato.LeerNumeroRomano("Ingrese el segundo número romano: ");
            string romano3 = leerDato.LeerNumeroRomano("Ingrese el tercer número romano: ");

            int numero1 = convertir.ConvertirDecimal(romano1);
            int numero2 = convertir.ConvertirDecimal(romano2);
            int numero3 = convertir.ConvertirDecimal(romano3);

            int producto = calculadora.Multiplicar(numero1, numero2, numero3);

            if (producto > maximoValor)
            {
                Console.WriteLine("\n❌ El resultado excede el valor permitido (3999). Intente nuevamente con números más pequeños.\n");
                continue;
            }

            Console.WriteLine($"\n✅ Resultado en decimal: {producto}");
            Console.WriteLine($"✅ Resultado en romano: {convertir.ConvertirRomano(producto)}");
            break;
        }
    }
}
