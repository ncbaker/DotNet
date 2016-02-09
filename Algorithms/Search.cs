using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class SearchAlgorithms
    {
        /* https://www.hackerrank.com/challenges/pangrams */
        /// <summary>
        /// Determines if the string is a pangram
        /// </summary>
        /// <param name="s"></param>
        /// <returns>bool if string is a pangram </returns>
        public static bool isPangram(string s)
        {
            List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();
            foreach (char c in s.ToLower().ToCharArray())
            {
                if (alphabet.Contains(c))
                    alphabet.Remove(c);

                if (alphabet.Count == 0)
                    return true;
            }
            return false;
        }

        /* https://www.hackerrank.com/challenges/pairs */
        public static void pairsMain()
        {
            int res;

            String line = Console.ReadLine();
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }

            res = pairs(_a, _k);
            Console.WriteLine(res);
        }
        static int pairs(int[] a, int k)
        {
            //edge: empty
            if (a.Length == 0)
                return 0;

            //edge: k == zero, all items are distinct
            if (k == 0)
                return 0;

            List<int> numbers = a.OrderBy(i => i).ToList();

            //edge: k > biggest difference
            if (k > numbers.Max() - numbers.Min())
                return 0;

            int count = 0;
            int previousStop = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                //edge: previous end point is next starting point
                for (int j = Math.Max(i + 1, previousStop); j < numbers.Count; j++)
                {
                    if (numbers[j] - numbers[i] == k)
                    {
                        count++;

                        //edge: k found on final item
                        if (j == numbers.Count - 1)
                            return count;

                        previousStop = j + 1;

                        break;
                    }
                    //edge: passed it
                    else if (numbers[j] - numbers[i] > k)
                        break;
                    //edge: difference < k && last pass of loop
                    else if (j == numbers.Count - 1 && numbers[j] - numbers[i] < k)
                        return count;
                }
            }
            return count;
        }

        /* https://www.hackerrank.com/challenges/icecream-parlor */
        /// <summary>
        /// Determines if the string is a pangram
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Outputs</returns>
        public static void icecreamParlorMain()
        {
            int tests = Int32.Parse(Console.ReadLine());

            int[] M = new int[tests];
            int[] N = new int[tests];
            int[][] arrays = new int[tests][];
            for (int i = 0; i < tests; i++)
            {
                M[i] = Convert.ToInt16(Console.ReadLine());
                N[i] = Convert.ToInt16(Console.ReadLine());
                arrays[i] = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            }

            Tuple<int, int> res;
            for (int i = 0; i < arrays.Length; i++)
            {
                res = icecreamParlor(M[i], N[i], arrays[i]);
                Console.WriteLine(String.Format("{0} {1}", res.Item1, res.Item2));
            }
        }

        /// <summary>
        /// Determines if the string is a pangram
        /// </summary>
        /// <param name="M">total dollars</param>
        /// <param name="N">number of flavors</param>
        /// <param name="c">array of prices</param>
        /// <returns>Tuple<int, int></returns>
        public static Tuple<int, int> icecreamParlor(int M, int N, int[] c)
        {
            for (int i = 0; i < c.Length; i++)
                for (int j = 0; j < c.Length; j++)
                {
                    if (i == j)
                        continue;

                    if (c[i] + c[j] == M)
                        return new Tuple<int, int>(Math.Min(i, j)+1, Math.Max(i, j) + 1);
                }

            return new Tuple<int, int>(0, 0);
        }
    }
}
