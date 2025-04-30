using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7
{
    // O: Esta clase está abierta para extensión (puedes agregar otros algoritmos de ordenamiento)
    //    pero cerrada para modificación (no necesitas tocar QuickSort si agregas otro método)

    public class Ordenador
    {
        public void QuickSort(Fraccion[] fracciones, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(fracciones, low, high);
                QuickSort(fracciones, low, pi - 1);
                QuickSort(fracciones, pi + 1, high);
            }
        }

        private int Partition(Fraccion[] arr, int low, int high)
        {
            double pivot = arr[high].ValorDecimal();
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j].ValorDecimal() >= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        private void Swap(Fraccion[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

}
