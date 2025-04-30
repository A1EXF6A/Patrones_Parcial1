using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    public class MagicSquareValidator
    {
        public bool IsMagic(int[,] square)
        {
            int n = square.GetLength(0);
            int targetSum = 0;

            for (int j = 0; j < n; j++)
                targetSum += square[0, j];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                    sum += square[i, j];
                if (sum != targetSum) return false;
            }
            for (int j = 0; j < n; j++)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                    sum += square[i, j];
                if (sum != targetSum) return false;
            }

            int diag1 = 0, diag2 = 0;
            for (int i = 0; i < n; i++)
            {
                diag1 += square[i, i];
                diag2 += square[i, n - i - 1];
            }

            return diag1 == targetSum && diag2 == targetSum;
        }
    }
}
