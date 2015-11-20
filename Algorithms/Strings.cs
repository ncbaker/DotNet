using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class StringsAlgorithms
    {
        /* https://www.hackerrank.com/challenges/pangrams */
        public static bool isPangram(string s)
        {
            List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToList();
            foreach(char c in s.ToLower().ToCharArray())
            {
                if (alphabet.Contains(c))
                    alphabet.Remove(c);

                if (alphabet.Count == 0)
                    return true;
            }
            return false;
        }

        /* https://www.hackerrank.com/challenges/utopian-tree */
        public static int grow(int numberOfCycles)
        {
            int result = 1;
            for (int i = 1; i <= numberOfCycles; i++)
            {
                if (i % 2 == 1)
                    result *= 2;
                else
                    result++;
            }
            return result;
        }

        /* https://www.hackerrank.com/challenges/funny-string */
        static void isFunny()
        {
            int num = Int32.Parse(Console.ReadLine());
            string[] entries = new string[num];
            for (int i = 0; i < num; i++)
                entries[i] = Console.ReadLine();

            for (int i = 0; i < num; i++)
            {
                string entry = entries[i];
                char[] arr = entry.ToCharArray();
                Array.Reverse(arr);
                string reverse = new string(arr);

                bool failed = false;
                for (int j = 1; j < entry.Length; j++)
                    if (Math.Abs(entry[j] - entry[j - 1]) != Math.Abs(reverse[j] - reverse[j - 1]))
                    {
                        failed = true;
                        break;
                    }

                string output = failed ? "Not Funny" : "Funny";
                Console.WriteLine(output);
            }
        }

        /* https://www.hackerrank.com/challenges/alternating-characters */
        static void alternatingCharacters()
        {
            int num = Int32.Parse(Console.ReadLine());
            string[] entries = new string[num];
            for (int i = 0; i < num; i++)
                entries[i] = Console.ReadLine();

            for (int i = 0; i < num; i++)
            {
                int count = 0;
                char[] c = entries[i].ToCharArray();
                for (int j = c.Length - 1; j > 0; j--)
                {
                    if (c[j] == c[j - 1])
                        count++;
                }
                Console.WriteLine(count);
            }
        }

    }
}
