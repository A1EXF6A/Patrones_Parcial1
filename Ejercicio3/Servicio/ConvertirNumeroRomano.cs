using Ejercicio3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ejercicio3.Servicio;

public class ConvertirNumeroRomano : IConvertirNumero
{
    private static readonly Dictionary<char, int> RomanoAInt = new()
    {
        {'I', 1 }, {'V', 5 }, {'X', 10 }, {'L', 50 },
        {'C', 100 }, {'D', 500 }, {'M', 1000 }
    };

    private static readonly (int Valor, string Simbolo)[] DecimalARomano = new (int, string)[]
    {
        (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
        (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
        (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
    };

    private const int MaximoNumeroRomano = 3999;

    public int ConvertirDecimal(string romano)
    {
        int total = 0, valorAnterior = 0;

        foreach (char c in romano)
        {
            int value = RomanoAInt[c];
            total += value > valorAnterior ? value - 2 * valorAnterior : value;
            valorAnterior = value;
        }

        return total;
    }

    public string ConvertirRomano(int numero)
    {
        if (numero < 1 || numero > MaximoNumeroRomano)
            throw new ArgumentOutOfRangeException(nameof(numero), $"El número debe estar entre 1 y {MaximoNumeroRomano}.");

        var romano = string.Empty;

        foreach (var (valor, simbolo) in DecimalARomano)
        {
            while (numero >= valor)
            {
                romano += simbolo;
                numero -= valor;
            }
        }

        return romano;
    }

    public bool EsValidoNumeroRomano(string romano)
    {
        if (string.IsNullOrEmpty(romano))
            return false;

        const string RomanoPatron = "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        return Regex.IsMatch(romano, RomanoPatron);
    }
}
