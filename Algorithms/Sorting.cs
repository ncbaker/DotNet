using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.Algorithms
{
    public static class SortingAlgorithms
    {
        /* https://www.hackerrank.com/challenges/insertionsort2 */
        /// <summary>
        /// Build a sorted array by repeatedly running InsertionSort algorithm over an array, which is built item by item appended to the end of the array.
        /// </summary>
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
                temp = insertionSort1(temp);
                Array.Copy(temp, 0, arr, 0, i);
                printArray(arr);
            }
        }

        /* https://www.hackerrank.com/challenges/insertionsort1 */
        /// <summary>
        /// Sorted unsorted number e in the rightmost cell of a sorted List
        /// </summary>
        /// <returns>Sorted int[]</returns>
        public static int[] insertionSort1(int[] arr)
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

        /// <summary>
        /// Helper method to print array to console
        /// </summary>
        static void printArray(int[] arr)
        {
            string s = string.Empty;
            for (int i = 0; i < arr.Length; i++)
                s += arr[i] + " ";
            Console.WriteLine(s);
        }

        /* https://www.hackerrank.com/challenges/tutorial-intro */
        /// <summary>
        /// Given a sorted array (arar) and a number (VV) print the index location of VV in the array
        /// </summary>
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
    }
}
