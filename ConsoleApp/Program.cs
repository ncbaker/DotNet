using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProgrammingProblems.DataStructures;
using StringBuilder = System.Text.StringBuilder;
using ProgrammingProblems.Algorithms;

namespace ProgrammingProblems.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            //List<int[]> tc = DynamicMaxSubarraySeed.GetTestCase3();
            //List<int[]> answers = new List<int[]>();
            //answers.Add(new int[] { 2617065, 172083036 });
            //answers.Add(new int[] { 1274115, 193037987 });
            //answers.Add(new int[] { 2202862, 163398048 });
            //answers.Add(new int[] { 2454939, 240462364 });
            //answers.Add(new int[] { 3239908, 186256172 });
            //answers.Add(new int[] { 2486039, 202399661 });
            //answers.Add(new int[] { 1092777, 137409985 });
            //answers.Add(new int[] { 962621, 135978139 });
            //answers.Add(new int[] { 3020911, 224370860 });
            //answers.Add(new int[] { 1755033, 158953999 });

            ////foreach (var arr in tc)
            //for (int i = 0; i < tc.Count; i++)
            //{
            //    List<int> param = new List<int>();
            //    param.AddRange(tc[i]);
            //    List<int[]> p = new List<int[]> { param.ToArray() };
            //    int[] output = DynamicProgramming.processMax(1, p);

            //    if (output[0] != answers[i][0] || output[1] != answers[i][1])
            //    {

            //    }
            //    else
            //    {

            //    }
            //}


            DynamicProgramming.maxSubArray();

            while (Console.ReadLine().ToLower() == "y")
            {
                DynamicProgramming.maxSubArray();
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();


            //int count = Convert.ToInt32(Console.ReadLine());
            //int[] numbers = new int[count];
            //for (int i = 0; i < count; i++)
            //    numbers[i] = Convert.ToInt32(Console.ReadLine());

            //foreach (int i in numbers)
            //{
            //    if (i < 0)
            //        Console.WriteLine(1);
            //    else
            //        Console.WriteLine(UtopianTree.grow(i));
            //}

            //SimpleNode nodes = TreeFactory.GetCareerCupTreeSimple1();
            //foreach (List<string> list in SimpleNodeHelper.findPathsWithSumN(nodes, 7))
            //    foreach (string s in list)
            //        Console.WriteLine(s + " ");

            //StringBuilder sb = new StringBuilder();
            //List<string> output = new List<string>();
            //int runningTtl = 0;
            //int search = 7;
            //foreach (int n in nodes)
            //{
            //    if (sb.Length == 0)
            //        sb.Append("{");

            //    if (n != null)
            //    {
            //        runningTtl += n;
            //        sb.Append(n + ",");
            //    }
            //    else if (sb.Length > 0)
            //    {
            //        sb.Append("}");
            //        output.Add(sb.ToString());
            //    }
            //}


            Console.ReadLine();
        }

        static void Amazon()
        {
            test();
            return;

            Dictionary<int, int> someDictionary = new Dictionary<int, int>();
            
            List<string> friendCourses = new List<string>() { "3", "2", "1", "3", "1", "1" };
            Dictionary<string, int> recs = new Dictionary<string, int>();
            foreach(string course in friendCourses)
                if(recs.Count(c => c.Key == course) == 0)
                    recs.Add(course, 1);
                else 
                    recs[course]++;

            List<KeyValuePair<string, int>> myList = recs.ToList();
            myList.Sort((firstPair,nextPair) =>
            {
                return nextPair.Value.CompareTo(firstPair.Value);
            });
            List<string> recomendations = new List<string>();
            foreach (var i in myList)
                recomendations.Add(i.Key);
        }

        static void test()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                
            }
            int[] j = new int[] { 1, 2, 3, 4, 10, 11 };
            int t = j.Sum();
        }
    }
}
