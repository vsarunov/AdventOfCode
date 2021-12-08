using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal static class Day6
    {
        private static int[] input = new int[] { 5, 1, 1, 1, 3, 5, 1, 1, 1, 1, 5, 3, 1, 1, 3, 1, 1, 1, 4, 1, 1, 1, 1, 1, 2, 4, 3, 4, 1, 5, 3, 4, 1, 1, 5, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 4, 2, 3, 2, 1, 4, 1, 1, 4, 2, 1, 4, 5, 5, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 5, 5, 1, 1, 4, 4, 5, 1, 1, 1, 3, 1, 5, 1, 2, 1, 5, 1, 4, 1, 3, 2, 4, 2, 1, 1, 4, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 3, 5, 4, 1, 1, 3, 1, 1, 1, 2, 1, 1, 1, 1, 5, 1, 1, 1, 4, 1, 4, 1, 1, 1, 1, 1, 2, 1, 1, 5, 1, 2, 1, 1, 2, 1, 1, 2, 4, 1, 1, 5, 1, 3, 4, 1, 2, 4, 1, 1, 1, 1, 1, 4, 1, 1, 4, 2, 2, 1, 5, 1, 4, 1, 1, 5, 1, 1, 5, 5, 1, 1, 1, 1, 1, 5, 2, 1, 3, 3, 1, 1, 1, 3, 2, 4, 5, 1, 2, 1, 5, 1, 4, 1, 5, 1, 1, 1, 1, 1, 1, 4, 3, 1, 1, 3, 3, 1, 4, 5, 1, 1, 4, 1, 4, 3, 4, 1, 1, 1, 2, 2, 1, 2, 5, 1, 1, 3, 5, 2, 1, 1, 1, 1, 1, 1, 1, 4, 4, 1, 5, 4, 1, 1, 1, 1, 1, 2, 1, 2, 1, 5, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 3, 1, 5, 3, 3, 1, 1, 2, 4, 4, 1, 1, 2, 1, 1, 3, 1, 1, 1, 1, 2, 3, 4, 1, 1, 2 };

        internal static long GetPart1Result()
        {
            var grouped = input.GroupBy(x => x)
                .ToDictionary(x => x.Key, y => (long)y.Count())
                .OrderBy(x => x.Key);

            var arr = new long[9];

            foreach (var g in grouped)
            {
                arr[g.Key] = g.Value;
            }

            var days = 256;
            while (days != 0)
            {
                var fishes = new long[9];
                for (int i = 8; i >= 0; i--)
                {
                    var index = i - 1;
                    if (index == -1)
                    {
                        fishes[6] = fishes[6] + arr[i];
                        fishes[8] = arr[i];
                    }
                    else fishes[index] = arr[i];
                }
                arr = fishes;
                days--;
            }

            return arr.Sum();
        }
    }
}
