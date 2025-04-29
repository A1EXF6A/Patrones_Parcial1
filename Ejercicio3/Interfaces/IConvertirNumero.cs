
namespace Ejercicio3.Interfaces
{
    public interface IConvertirNumero
    {
        int ConvertirDecimal(string romano);
        string ConvertirRomano(int numero);
        bool EsValidoNumeroRomano(string romano);
    }
}
