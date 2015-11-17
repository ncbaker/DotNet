using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class Pangram
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
    }
}
