using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class GreedyAlgorithms
    {
        /* https://www.hackerrank.com/challenges/flowers */
        public static void flowersMain()
        {
            int N, K;
            string NK = Console.ReadLine();
            string[] NandK = NK.Split(new Char[] { ' ', '\t', '\n' });
            N = Convert.ToInt32(NandK[0]);
            K = Convert.ToInt32(NandK[1]);

            int[] C = new int[N];

            string numbers = Console.ReadLine();
            string[] split = numbers.Split(new Char[] { ' ', '\t', '\n' });

            int i = 0;

            foreach (string s in split)
            {
                if (s.Trim() != "")
                {
                    C[i++] = Convert.ToInt32(s);
                }
            }

            int result = flowers(N, K, C);
            Console.WriteLine(result);
        }

        static int flowers(int N, int K, int[] C)
        {
            int[] ordered = C.OrderByDescending(i => i).ToArray();
            int ttl = 0;
            
            for (int i = 0; i < ordered.Length; i++)
                for (int j = 0; j < K; j++)
                    if ((i * K) + j < ordered.Length)
                        ttl += (i+1) * ordered[(i * K) + j];
                    else //handle un-even arrays
                        break;

            return ttl;
        }
        
        /* https://www.hackerrank.com/challenges/two-arrays */
        public static void twoArrays()
        {
            //load data
            int tests = Int32.Parse(Console.ReadLine());
            int[,] testParams = new int[tests,2];
            List<int[]> arrays = new List<int[]>();            
            string[] line;
            for (int i = 0; i < tests; i++)
            {
                line = Console.ReadLine().Split(new Char[] { ' ', '\t', '\n' });
                testParams[i, 0] = Convert.ToInt32(line[0]);
                testParams[i, 1] = Convert.ToInt32(line[1]);
                
                arrays.Add(Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s)));
                arrays.Add(Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s)));
            }

            //process data
            bool failed;
            int[] x, y;
            int K;
            for (int i = 0; i < tests; i++)
            {
                failed = false;
                K = testParams[i, 1];
                x = arrays[(i * 2)].OrderBy(v => v).ToArray();
                y = arrays[(i * 2)+1].OrderByDescending(v => v).ToArray();
                for (int j = 0; j < x.Length; j++)
                {
                    if(x[j]+y[j]<K)
                    {
                        failed = true;
                        Console.WriteLine("NO");
                        break;
                    }
                }

                if(!failed)
                    Console.WriteLine("YES");
            }

            //possible edges - differently sized arrays
        }
    }
}
