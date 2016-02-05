using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class DynamicProgramming
    {
        /* https://www.hackerrank.com/challenges/maxsubarray */
        /// <summary>
        /// Outputs both the largest continuous and largest discontinous sub arry in an array.  HackerRank submission which creates array from input
        /// </summary>
        public static void maxSubArray()
        {
            //load data
            int tests = Int32.Parse(Console.ReadLine());
            List<int[]> arrays = new List<int[]>();

            for (int i = 0; i < tests; i++)
            {
                int[] arr = new int[Int32.Parse(Console.ReadLine())];
                arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
                arrays.Add(arr);
            }

            List<Tuple<int, int>> results = processMax(tests, arrays);

            foreach (Tuple<int, int> r in results)
                Console.WriteLine(String.Format("{0} {1}", r.Item1, r.Item2));
        }

        /// <summary>
        /// Process a series of arrays and returns a list of outputs with the largest continuous and largest discontinous sub arry in an array.
        /// </summary>
        public static List<Tuple<int, int>> processMax(int tests, List<int[]> arrays)
        {
            //process data
            int nonConTtl, max1, max2;
            List<Tuple<int, int>> results = new List<Tuple<int, int>>();
            for (int i = 0; i < tests; i++)
            {
                //get max non-contiguous sum
                nonConTtl = arrays[i].Where(x => x >= 0).ToArray().Sum();
                if (nonConTtl > 0)
                {
                    max1 = max2 = 0;
                    for (int j = 0; j < arrays[i].Length; j++)
                    {
                        max1 = Math.Max(0, max1 + arrays[i][j]);
                        max2 = Math.Max(max1, max2);
                    }
                }
                else //edge: all items in array are negative
                    nonConTtl = max2 = arrays[i].Max();

                results.Add(new Tuple<int, int>(max2, nonConTtl));
            }

            return results;
        }
    }
}