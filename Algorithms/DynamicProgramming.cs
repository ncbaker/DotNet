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

            
        }

        static void processMax(int tests, List<int[]> arrays)
        {
            //process data
            int ttl, nonConTtl;
            int[] positiveArr;
            for (int i = 0; i < tests; i++)
            {
                //get max non-contiguous sum
                positiveArr = arrays[i].Where(x => x >= 0).ToArray();
                if (positiveArr.Length > 0)
                {
                    nonConTtl = positiveArr.Sum();

                    ttl = 0;
                    for (int j = 0; j < arrays[i].Length; j++)
                        ttl = Math.Max(ttl, findMax(arrays[i].Take(arrays[i].Length - j).ToArray()));
                }
                else //edge: all items in array are negative
                    nonConTtl = ttl = arrays[i].Max();

                Console.WriteLine(String.Format("{0} {1}", ttl, nonConTtl));
            }
        }

        static void processMax1(int tests, List<int[]> arrays)
        {
            //process data
            int ttl, nonConTtl;
            int[] positiveArr;
            for (int i = 0; i < tests; i++)
            {
                //get max non-contiguous sum
                positiveArr = arrays[i].Where(x => x >= 0).ToArray();
                if (positiveArr.Length > 0)
                {
                    nonConTtl = positiveArr.Sum();

                    ttl = 0;
                    for (int j = 0; j < arrays[i].Length; j++)
                        ttl = Math.Max(ttl, findMax(arrays[i].Take(arrays[i].Length - j).ToArray()));
                }
                else //edge: all items in array are negative
                    nonConTtl = ttl = arrays[i].Max();

                Console.WriteLine(String.Format("{0} {1}", ttl, nonConTtl));
            }
        }

        static int findMax(int[] arr)
        {
            int ttl = arr.Sum();
            if (arr.Length == 1)
                return ttl;
            int sub = findMax(arr.Skip(1).ToArray());
            return Math.Max(ttl, sub);
        }
    }
}
