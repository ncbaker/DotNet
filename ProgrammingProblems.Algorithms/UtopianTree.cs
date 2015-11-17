using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class UtopianTree
    {
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
    }
}
