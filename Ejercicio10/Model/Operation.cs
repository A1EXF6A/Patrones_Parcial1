using Ejercicio10;

public class AdditionOperation : FractionOperation
{
  public override double Execute(double currentResult, string fraction, Converter converter)
  {
    return currentResult + converter.GetDoubleFromFraction(fraction);
  }
}
