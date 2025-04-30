namespace Ejercicio7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Programa iniciado correctamente!");

            int n;

            Console.Write("¿Cuántas fracciones desea ingresar?: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número entero positivo válido.");
                Console.Write("¿Cuántas fracciones desea ingresar?: ");
            }

            Fraccion[] fracciones = new Fraccion[n];

            for (int i = 0; i < n; i++)
            {
                int num, den;

                Console.WriteLine($"\nFracción {i + 1}:");

                Console.Write("Numerador: ");
                while (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.Write("Entrada inválida. Ingrese un número entero: ");
                }

                Console.Write("Denominador: ");
                while (!int.TryParse(Console.ReadLine(), out den) || den == 0)
                {
                    Console.Write("Entrada inválida. El denominador no puede ser cero. Ingrese otro: ");
                }

                fracciones[i] = new Fraccion(num, den);
            }

            Ordenador ordenador = new Ordenador();
            ordenador.QuickSort(fracciones, 0, fracciones.Length - 1);

            Console.WriteLine("\nFracciones ordenadas (mayor a menor):");
            foreach (var f in fracciones)
            {
                Console.WriteLine(f.ToString());
            }

            Calculadora calc = new Calculadora();
            Fraccion suma = calc.Sumar(fracciones);

            Console.WriteLine("\nSuma total (irreducible): " + suma.ToString());
            Console.ReadKey();
        }

    }
}
