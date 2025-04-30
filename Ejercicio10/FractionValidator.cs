namespace Ejercicio10
{
  public class FractionValidator : IValidator
  {
    public bool IsInteger(string fraction)
    {
      bool isInt = !fraction.Contains('/');
      return isInt;
    }

    public bool IsValidInput(string input)
    {
      string[] parts = input.Split('/');

      if (parts.Length != 2) return false;

      if (!int.TryParse(parts[0], out int numerator) || !int.TryParse(parts[1], out int denominator)) return false;

      if (denominator == 0) return false;

      return true;
    }
  }
}