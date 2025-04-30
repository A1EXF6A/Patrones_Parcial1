namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INumberInput input = new ConsoleNumberInput();
            IManualDivider divider = new ManualDivider();
            IOutputWriter output = new ConsoleOutputWriter();

            // Coordinador principal de la aplicación
            DivisionApp app = new DivisionApp(input, divider, output);
            app.Run();
        }
    }
}
