using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class BitManipulation
    {
        /* https://www.hackerrank.com/challenges/lonely-integer */
        /// <summary>
        /// Method which returns the number which exists in in the array once.  HackerRank submission which creates array from input
        /// </summary>
        public static void lonelyIntegerMain()
        {
            int res;

            int _a_size = Convert.ToInt32(Console.ReadLine());
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }
            res = lonelyinteger(_a);
            Console.WriteLine(res);
        }


        /// <summary>
        /// Method which returns the number which exists in in the array once
        /// </summary>
        /// <param name="a">array of integers</param>
        /// <returns>int</returns>
        /// <remarks>Complexity - O(n)</remarks>
        public static int lonelyinteger(int[] a)
        {
            return a.Aggregate((x, y) => x ^ y);
        }
    }
}
