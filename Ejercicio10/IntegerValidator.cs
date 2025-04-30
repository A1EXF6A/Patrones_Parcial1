
namespace Ejercicio10
{
  public class IntergerValidator : IValidator
  {
    public bool IsValidInput(string input)
    {
      bool isInt = !input.Contains('/');
      return isInt;
    }
  }
}