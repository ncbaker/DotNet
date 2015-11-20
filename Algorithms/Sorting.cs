using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class StringAlgorithms
    {
        /* https://www.hackerrank.com/challenges/insertionsort2 */
        public static void insertionSort2()
        {
            int num = Int32.Parse(Console.ReadLine());
            int[] arr = new int[num];
            arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            int[] temp;
            for (int i = 2; i <= arr.Length; i++)
            {
                temp = new int[i];
                Array.Copy(arr, temp, i);
                temp = insertionSort2(temp);
                Array.Copy(temp, 0, arr, 0, i);
                printArray(arr);
            }
        }

        public static int[] insertionSort2(int[] arr)
        {
            if (arr.Length == 1)
                return arr;

            int insert = arr[arr.Length - 1];

            //right edge case
            if (insert > arr[arr.Length - 2])
                return arr;

            bool inserted = false;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (insert > arr[i - 1])
                {
                    arr[i] = insert;
                    inserted = true;
                    break;
                }
                arr[i] = arr[i - 1];
            }

            //left edge case
            if (!inserted)
                arr[0] = insert;

            return arr;
        }

        static void printArray(int[] arr)
        {
            string s = string.Empty;
            for (int i = 0; i < arr.Length; i++)
                s += arr[i] + " ";
            Console.WriteLine(s);
        }

        /* https://www.hackerrank.com/challenges/tutorial-intro */
        public static void tutorialsIntro()
        {
            int find = Int32.Parse(Console.ReadLine());
            int num = Int32.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == find)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        /* incomplete binary search alg. */
        static void tutorialsIntroBad()
        {
            int find = Int32.Parse(Console.ReadLine());
            int num = Int32.Parse(Console.ReadLine());
            int[] arr = new int[num];
            arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            int[] temp = arr;
            int[] temp2;
            int count = 0;

            while (true)
            {
                //binary search - right half
                int half = (int)Math.Floor((decimal)temp.Length / 2M);

                temp2 = new int[half];
                if (find > temp[half - 1])
                {
                    Array.Copy(temp, temp.Length - half - 1, temp2, 0, half);
                    count += half - 1;
                }

                //binary search - left half
                else if (find < temp[half - 1])
                {
                    Array.Copy(temp, temp2, half);
                }

                else
                {
                    Console.WriteLine(count + half);
                    break;
                }

                temp = temp2;
            }

            //for (int i = 2; i <= arr.Length; i++)
            //{
            //    temp = new int[i];
            //    Array.Copy(arr, temp, i);
            //    temp = insertionSort2(temp);
            //    Array.Copy(temp, 0, arr, 0, i);
            //    printArray(arr);
            //}
        }
    }
}
