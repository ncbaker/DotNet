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

            List<int[]> results = processMax(tests, arrays);

            foreach(int[] r in results)
                Console.WriteLine(String.Format("{0} {1}", r[0], r[1]));
        }

        public static List<int[]> processMax(int tests, List<int[]> arrays)
        {
            //process data
            int nonConTtl, max1, max2;
            List<int[]> results = new List<int[]>();
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

                results.Add(new int[] { max2, nonConTtl });
            }

            return results;
        }

        //public static int[] processMaxOld(int tests, List<int[]> arrays)
        //{
        //    //process data
        //    int ttl, nonConTtl;
        //    int[] positiveArr;
        //    int[] output = new int[2];
        //    for (int i = 0; i < tests; i++)
        //    {
        //        //get max non-contiguous sum
        //        positiveArr = arrays[i].Where(x => x >= 0).ToArray();
        //        if (positiveArr.Length > 0)
        //        {
        //            nonConTtl = positiveArr.Sum();

        //            ttl = 0;
        //            for (int j = 0; j < arrays[i].Length; j++)
        //                ttl = Math.Max(ttl, findMax(arrays[i].Take(arrays[i].Length - j).ToArray()));
        //        }
        //        else //edge: all items in array are negative
        //            nonConTtl = ttl = arrays[i].Max();

        //        output[0] = ttl;
        //        output[1] = nonConTtl;
        //    }

        //    return output;
        //}


        //public static int[] processMax11(int tests, List<int[]> arrays)
        //{
        //    //process data
        //    int ttl, nonConTtl, sum;
        //    int[] positiveArr;
        //    int[] output = new int[2];
        //    for (int i = 0; i < tests; i++)
        //    {
        //        //get max non-contiguous sum
        //        positiveArr = arrays[i].Where(x => x >= 0).ToArray();
        //        if (positiveArr.Length > 0)
        //        {
        //            nonConTtl = positiveArr.Sum();

        //            ttl = sum = 0;
        //            for (int j = 0; j < arrays[i].Length; j++)
        //            {
        //                sum += arrays[i][j];
        //                if (sum >= ttl)
        //                    ttl = sum;
        //                else
        //                    sum = 0;
        //            }
        //        }
        //        else //edge: all items in array are negative
        //            nonConTtl = ttl = arrays[i].Max();

        //        output[0] = ttl;
        //        output[1] = nonConTtl;
        //    }

        //    return output;
        //}

        //static void processMax2(int tests, List<int[]> arrays)
        //{
        //    //process data
        //    int ttl, nonConTtl;
        //    int[] positiveArr;
        //    for (int i = 0; i < tests; i++)
        //    {
        //        //get max non-contiguous sum
        //        positiveArr = arrays[i].Where(x => x >= 0).ToArray();
        //        if (positiveArr.Length > 0)
        //        {
        //            nonConTtl = positiveArr.Sum();

        //            ttl = 0;
        //            for (int j = 0; j < arrays[i].Length; j++)
        //                ttl = Math.Max(ttl, findMax(arrays[i].Take(arrays[i].Length - j).ToArray()));
        //        }
        //        else //edge: all items in array are negative
        //            nonConTtl = ttl = arrays[i].Max();

        //        Console.WriteLine(String.Format("{0} {1}", ttl, nonConTtl));
        //    }
        //}

        //static int findMax(int[] arr)
        //{
        //    int ttl = arr.Sum();
        //    if (arr.Length == 1)
        //        return ttl;
        //    int sub = findMax(arr.Skip(1).ToArray());
        //    return Math.Max(ttl, sub);
        //}
    }
}
