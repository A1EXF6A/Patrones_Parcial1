using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    public class MagicSquareBuilder
    {
        private readonly IMagicSquareGenerator generator;
        private readonly MagicSquareValidator validator;

        public MagicSquareBuilder(IMagicSquareGenerator generator, MagicSquareValidator validator)
        {
            this.generator = generator;
            this.validator = validator;
        }

        public int[,] Build(int size)
        {
            var candidates = generator.GenerateCandidates();

            var combos = GetCombinations(candidates, size * size);
            foreach (var combo in combos)
            {


                int[,] square = new int[size, size];
                var used = new HashSet<int>();

                for (int i = 0; i < size * size; i++)
                {
                    int number = combo[i];
                    if (used.Contains(number))
                        goto SkipCombo;

                    used.Add(number);
                    square[i / size, i % size] = number;
                }

                if (validator.IsMagic(square))
                    return square;

                SkipCombo:;


                if (validator.IsMagic(square))
                    return square;
            }

            return null;
        }

        private IEnumerable<List<int>> GetCombinations(List<int> nums, int count)
        {
            if (count == 1)
            {
                foreach (var num in nums)
                    yield return new List<int> { num };
            }
            else
            {
                foreach (var num in nums)
                {
                    foreach (var tail in GetCombinations(nums, count - 1))
                    {
                        tail.Insert(0, num);
                        yield return tail;
                    }
                }
            }
        }
    }
}
