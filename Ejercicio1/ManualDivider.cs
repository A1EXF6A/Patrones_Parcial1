using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class ManualDivider : IManualDivider
    {
        public (string Quotient, string Remainder, string Display) Divide(string dividend, string divisor)
        {
            if (divisor == "0") throw new DivideByZeroException();

            StringBuilder quotient = new();
            StringBuilder display = new();
            StringBuilder subDividend = new();

            string header = $" {dividend} |{divisor}";
            int idx = 0;

            while (idx < dividend.Length)
            {
                subDividend.Append(dividend[idx]);
                subDividend = new StringBuilder(subDividend.ToString().TrimStart('0'));
                if (subDividend.Length == 0) subDividend.Append('0');

                string temp = subDividend.ToString();
                int count = 0;

                while (CompareStrings(temp, divisor) >= 0)
                {
                    temp = SubtractStrings(temp, divisor);
                    count++;
                }

                if (quotient.Length > 0 || count > 0)
                    quotient.Append(count);

                if (count > 0)
                {
                    string spaces = new string(' ', idx - temp.Length + 1);
                    display.AppendLine(spaces + subDividend);
                    display.AppendLine(spaces + "-" + MultiplyString(divisor, count));
                    display.AppendLine(spaces + new string('-', Math.Max(divisor.Length, temp.Length)));
                }

                subDividend = new StringBuilder(temp);
                idx++;
            }

            if (quotient.Length == 0) quotient.Append("0");
            string remainder = subDividend.ToString().TrimStart('0');
            if (remainder == "") remainder = "0";

            string separator = new string('-', dividend.Length) + "+" + new string('-', Math.Max(divisor.Length, quotient.Length));
            string quotientLine = new string(' ', dividend.Length + 2 - quotient.Length) + quotient;

            StringBuilder fullDisplay = new();
            fullDisplay.AppendLine(header);
            fullDisplay.AppendLine(separator);
            fullDisplay.AppendLine(quotientLine);
            fullDisplay.Append(display);
            fullDisplay.AppendLine($"Resto: {remainder}");

            return (quotient.ToString(), remainder, fullDisplay.ToString());
        }

        private int CompareStrings(string a, string b)
        {
            a = a.TrimStart('0');
            b = b.TrimStart('0');
            if (a.Length != b.Length)
                return a.Length.CompareTo(b.Length);
            return string.Compare(a, b, StringComparison.Ordinal);
        }

        private string SubtractStrings(string a, string b)
        {
            StringBuilder result = new();
            int carry = 0, i = a.Length - 1, j = b.Length - 1;

            while (i >= 0 || j >= 0)
            {
                int digitA = i >= 0 ? a[i] - '0' : 0;
                int digitB = j >= 0 ? b[j] - '0' : 0;
                int diff = digitA - digitB - carry;
                if (diff < 0)
                {
                    diff += 10;
                    carry = 1;
                }
                else carry = 0;
                result.Insert(0, diff);
                i--; j--;
            }

            return result.ToString().TrimStart('0');
        }

        private string MultiplyString(string num, int times)
        {
            StringBuilder result = new();
            int carry = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                int prod = (num[i] - '0') * times + carry;
                result.Insert(0, prod % 10);
                carry = prod / 10;
            }

            while (carry > 0)
            {
                result.Insert(0, carry % 10);
                carry /= 10;
            }

            return result.ToString();
        }
    }
}
