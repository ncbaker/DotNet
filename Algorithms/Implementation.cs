using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class ImplementationAlgorithms
    {
        /* https://www.hackerrank.com/challenges/find-digits */
        /// <summary>
        /// Traverse array and output number of elements that are evenly divisible by a number N.
        /// </summary>
        static void findDigits()
        {
            int num = Int32.Parse(Console.ReadLine());
            long[] entries = new long[num];
            for (int i = 0; i < num; i++)
                entries[i] = long.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                int[] numbers = Array.ConvertAll(entries[i].ToString().ToCharArray(), n => int.Parse(n.ToString()));
                int[] found = Enumerable.Repeat(0, 10).ToArray();

                /* todo: auto increment if number has already been tested */
                for (int j = 0; j < numbers.Length; j++)
                    if (numbers[j] != 0 && entries[i] % numbers[j] == 0)
                        found[numbers[j]]++;

                Console.WriteLine(found.Sum());
            }
        }

        /* https://www.hackerrank.com/challenges/taum-and-bday */
        /// <summary>
        /// Greedy algorithm to determine optimal purchasing of two different items based on input prices and a conversion price.
        /// </summary>
        static void taumBday()
        {
            int num = Int32.Parse(Console.ReadLine());
            long[,] gifts = new long[num, 2];
            long[,] costs = new long[num, 3];

            long[] g = new long[2];
            long[] c = new long[3];
            for (int i = 0; i < num; i++)
            {
                g = Array.ConvertAll(Console.ReadLine().Split(' '), s => long.Parse(s.ToString()));
                c = Array.ConvertAll(Console.ReadLine().Split(' '), s => long.Parse(s.ToString()));
                gifts[i, 0] = g[0];
                gifts[i, 1] = g[1];
                costs[i, 0] = c[0];
                costs[i, 1] = c[1];
                costs[i, 2] = c[2];
            }

            long cost, conversionCost;
            for (int i = 0; i < num; i++)
            {
                cost = conversionCost = (gifts[i, 0] * costs[i, 0]) + (gifts[i, 1] * costs[i, 1]);

                if (costs[i, 0] < costs[i, 1])
                    conversionCost = (gifts[i, 0] * costs[i, 0]) + (costs[i, 0] + costs[i, 2]) * gifts[i, 1];
                else if (costs[i, 0] > costs[i, 1])
                    conversionCost = (gifts[i, 1] * costs[i, 1]) + (costs[i, 1] + costs[i, 2]) * gifts[i, 0];

                Console.WriteLine(Math.Min(cost, conversionCost));
            }
        }

    }
}
