// Aplicar el principio de Responsabilidad Única (SRP): Cada clase debe tener una única responsabilidad.
// La clase Converter se encargará únicamente de las conversiones matemáticas relacionadas con fracciones.

namespace Ejercicio10
{
  public class Converter
  {
    public double GetDoubleFromFraction(string fraction)
    {
      double result = 0;

      string[] parts = fraction.Split('/');

      result = double.Parse(parts[0]) / double.Parse(parts[1]);

      return result;
    }

    public string GetFractionFromDouble(double number)
    {
      string[] parts = number.ToString().Contains('.')
        ? number.ToString().Split('.')
        : number.ToString().Split(',');

      if (parts.Length == 1) return $"{number}";

      if (parts[1].Length > 3) parts[1] = parts[1].Substring(0, 3);

      int numerator = int.Parse(parts[0]) * (int)Math.Pow(10, parts[1].Length) + int.Parse(parts[1]);
      int denominator = (int)Math.Pow(10, parts[1].Length);

      return $"{numerator}/{denominator}";
    }

    public string GetSimplifiedFraction(string fraction)
    {
      string[] parts = fraction.Split('/');
      int numerator = int.Parse(parts[0]);
      int denominator = int.Parse(parts[1]);

      int gcd = GCD(numerator, denominator);

      numerator /= gcd;
      denominator /= gcd;

      return $"{numerator}/{denominator}";
    }

    private int GCD(int firstNumber, int secondNumber)
    {
      if (secondNumber == 0) return firstNumber;
      return GCD(secondNumber, firstNumber % secondNumber);
    }
  }

}