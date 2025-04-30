using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    public class ManualNumberGenerator : IMagicSquareGenerator
    {
        private readonly List<int> customNumbers;

        public ManualNumberGenerator(List<int> numbers)
        {
            customNumbers = numbers;
        }

        public List<int> GenerateCandidates()
        {
            return customNumbers;
        }
    }
}
