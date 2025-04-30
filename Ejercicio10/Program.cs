using System.Runtime.CompilerServices;
using Ejercicio10;

internal class Program
{
  static void Main(string[] args)
  {
    Converter converter = new();
    IValidator fractionValidator = new FractionValidator();
    IValidator integerValidator = new IntergerValidator();
    FractionOperation operation = new AdditionOperation();

    Console.WriteLine("Ingrese la cantidad de fracciones a sumar: ");

    string? input = Console.ReadLine();

    if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int n) || n <= 0)
    {
      Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero positivo.");
      return;
    }

    int i = 0;
    double result = 0;
    List<string> fractions = new(n);

    while (i < n)
    {
      Console.WriteLine($"Ingrese una fracción (Formato: Numerador/Denominador): ");
      string? fractionInput = Console.ReadLine();

      if (string.IsNullOrEmpty(fractionInput) || !fractionValidator.IsValidInput(fractionInput))
      {
        Console.WriteLine("Entrada no válida. Por favor, ingrese una fracción en el formato correcto.");
        continue;
      }

      result = operation.Execute(result, fractionInput, converter);
      fractions.Add(fractionInput);

      i++;
    }

    string fractionResult = converter.GetFractionFromDouble(result);

    Console.WriteLine("El resultado es: ");

    for (int j = 0; j < fractions.Count; j++)
    {
      if (j == 0)
      {
        Console.Write($"{fractions[j]} ");
        continue;
      }

      bool isNegative = fractions[j].StartsWith('-');

      if (isNegative) Console.Write($"- {fractions[j][1..]} ");
      else Console.Write($"+ {fractions[j]} ");

    }

    if (integerValidator.IsValidInput(fractionResult))
    {
      Console.WriteLine($"= {fractionResult} ");
    }
    else
    {
      string simplifiedFraction = converter.GetSimplifiedFraction(fractionResult);

      Console.WriteLine($"= {simplifiedFraction}");
    }



  }
}
