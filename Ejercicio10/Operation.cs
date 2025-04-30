using Ejercicio10;

public abstract class FractionOperation
{
  public abstract double Execute(double currentResult, string fraction, Converter converter);
}

public class AdditionOperation : FractionOperation
{
  public override double Execute(double currentResult, string fraction, Converter converter)
  {
    return currentResult + converter.GetDoubleFromFraction(fraction);
  }
}