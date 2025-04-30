namespace Ejercicio8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] square = new int[4, 4]
            {
                { 5555, 5557, 5575, 5755 },
                { 5577, 5757, 5775, 7755 },
                { 5755, 5775, 7555, 7577 },
                { 7775, 7757, 7575, 7777 }
            };

            
            Console.WriteLine("Cuadrado mágico encontrado:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{square[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();


        }
    }
}
