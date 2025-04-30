namespace Ejercicio7
{
    // S: Esta clase solo se encarga de representar y operar una fracción (una única responsabilidad)

    public class Fraccion
    {
        public int Numerador { get; set; }
        public int Denominador { get; set; }

        public Fraccion(int num, int den)
        {
            if (den == 0)
                throw new ArgumentException("El denominador no puede ser cero.");

            Numerador = num;
            Denominador = den;
        }

        // S: Responsabilidad de representar el valor decimal de la fracción
        public double ValorDecimal()
        {
            return (double)Numerador / Denominador;
        }

        // S: Responsabilidad de simplificar la fracción
        public void Simplificar()
        {
            int mcd = CalcularMCD(Math.Abs(Numerador), Math.Abs(Denominador));
            Numerador /= mcd;
            Denominador /= mcd;

            if (Denominador < 0)
            {
                Numerador *= -1;
                Denominador *= -1;
            }
        }

        private int CalcularMCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{Numerador}/{Denominador}";
        }
    }
}
