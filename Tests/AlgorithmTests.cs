using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProgrammingProblems.Algorithms;
using System.Text;

namespace ProgrammingProblems.Test
{
    [TestClass]
    public class AlgorithmTests
    {
        #region Strings Algorithms
        [TestMethod]
        public void TestAlgorithmUtopianTree()
        {
            Dictionary<int, int> tests = new Dictionary<int, int>();
            tests.Add(0, 1);
            tests.Add(1, 2);
            tests.Add(2, 3);
            tests.Add(3, 6);
            tests.Add(4, 7);
            tests.Add(5, 14);
            tests.Add(6, 15);
            tests.Add(7, 30);
            tests.Add(8, 31);
            tests.Add(9, 62);
            tests.Add(10, 63);
            tests.Add(11, 126);
            tests.Add(12, 127);
            tests.Add(13, 254);
            tests.Add(14, 255);
            tests.Add(15, 510);
            tests.Add(16, 511);
            tests.Add(17, 1022);
            tests.Add(18, 1023);
            tests.Add(19, 2046);
            tests.Add(20, 2047);
            tests.Add(21, 4094);
            tests.Add(22, 4095);
            tests.Add(23, 8190);
            tests.Add(24, 8191);
            tests.Add(25, 16382);
            tests.Add(26, 16383);
            tests.Add(27, 32766);
            tests.Add(28, 32767);
            tests.Add(29, 65534);
            tests.Add(30, 65535);
            tests.Add(31, 131070);
            tests.Add(32, 131071);
            tests.Add(33, 262142);
            tests.Add(34, 262143);
            tests.Add(35, 524286);
            tests.Add(36, 524287);
            tests.Add(37, 1048574);
            tests.Add(38, 1048575);
            tests.Add(39, 2097150);
            tests.Add(40, 2097151);
            tests.Add(41, 4194302);
            tests.Add(42, 4194303);
            tests.Add(43, 8388606);
            tests.Add(44, 8388607);
            tests.Add(45, 16777214);
            tests.Add(46, 16777215);
            tests.Add(47, 33554430);
            tests.Add(48, 33554431);
            tests.Add(49, 67108862);
            tests.Add(50, 67108863);
            tests.Add(51, 134217726);
            tests.Add(52, 134217727);
            tests.Add(53, 268435454);
            tests.Add(54, 268435455);
            tests.Add(55, 536870910);
            tests.Add(56, 536870911);
            tests.Add(57, 1073741822);
            tests.Add(58, 1073741823);
            tests.Add(59, 2147483646);
            tests.Add(60, 2147483647);



            foreach (var v in tests)
                Assert.AreEqual<int>(StringAlgorithms.grow(v.Key), v.Value);
        }
        #endregion


        #region Search Algorithms
        [TestMethod]
        public void TestAlgorithmPangram()
        {
            string input = "We promptly judged antique ivory buckles for the next prize";
            Assert.AreEqual<bool>(SearchAlgorithms.isPangram(input), true);

            input = "We promptly judged antique ivory buckles for the prize";
            Assert.AreEqual<bool>(SearchAlgorithms.isPangram(input), false);

            input = "The quick brown fox jumps over the lazy dog";
            Assert.AreEqual<bool>(SearchAlgorithms.isPangram(input), true);
        }

        [TestMethod]
        public void TestIceCreamParlor()
        {
            Tuple<int,int> a = SearchAlgorithms.icecreamParlor(4, 5, new int[] { 1, 4, 5, 3, 2 });
            Assert.AreEqual<Tuple<int, int>> (a, new Tuple<int, int>(1, 4));

            Tuple<int, int> b = SearchAlgorithms.icecreamParlor(4, 4, new int[] { 2, 2, 4, 3 });
            Assert.AreEqual<Tuple<int, int>>(b, new Tuple<int, int>(1, 2));
        }
        #endregion


        #region DynamicProgramming
        [TestMethod]
        public void TestDynamicMaxSubarray()
        {
            string line;
            List<int[]> data = new List<int[]>();

            int[] array = new int[] { };

            int arrSize = 0;
            System.IO.StreamReader file = new System.IO.StreamReader("../../DynamicMaxSubarraySeedData.txt");
            while ((line = file.ReadLine()) != null)
            {
                arrSize = Convert.ToInt32(line);
                line = file.ReadLine();
                array = Array.ConvertAll(line.Split(','), s => int.Parse(s));
                if (array.Length != arrSize)
                    throw new ArrayTypeMismatchException(String.Format("Array length error in seed data text file.  Array #{0}.", data.Count));

                data.Add(array);
            }
            

            List<Tuple<int, int>> answers = new List<Tuple<int, int>>();
            answers.Add(new Tuple<int, int>( 2617065, 172083036));
            answers.Add(new Tuple<int, int>( 1274115, 193037987 ));
            answers.Add(new Tuple<int, int>( 2202862, 163398048 ));
            answers.Add(new Tuple<int, int>( 2454939, 240462364 ));
            answers.Add(new Tuple<int, int>( 3239908, 186256172 ));
            answers.Add(new Tuple<int, int>( 2486039, 202399661 ));
            answers.Add(new Tuple<int, int>( 1092777, 137409985 ));
            answers.Add(new Tuple<int, int>( 962621, 135978139 ));
            answers.Add(new Tuple<int, int>( 3020911, 224370860 ));
            answers.Add(new Tuple<int, int>( 1755033, 158953999 ));
            
            List<Tuple<int, int>> results = DynamicProgramming.processMax(data.Count, data);

            //foreach (int[] r in results)
            for (int i = 0; i < results.Count; i++)
            {
                Assert.AreEqual<int>(results[i].Item1, answers[i].Item1);
                Assert.AreEqual<int>(results[i].Item2, answers[i].Item2);
            }
        }
        #endregion


        #region GraphTheory
        [TestMethod]
        public void TestBFSSHortReach()
        {
            List<int> startNodes = new List<int>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"../../bfsshortreach1.txt");

            string line = file.ReadLine();

            int[] arr = new int[2];
            arr = Array.ConvertAll(line.Split(' '), s => int.Parse(s));
            int nodes = arr[0];
            int edges = arr[1];


            //load data            
            List<LinkedList<int>> graph = new List<LinkedList<int>>();
            for (int j = 0; j < nodes; j++)
                graph.Add(new LinkedList<int>());

            for (int j = 0; j < edges; j++)
            {
                line = file.ReadLine();
                arr = new int[2];
                arr = Array.ConvertAll(line.Split(' '), s => int.Parse(s) - 1);

                graph[arr[0]].AddLast(arr[1]);
                graph[arr[1]].AddLast(arr[0]);
            }


            //load expected results
            List<string> expectedResults = new List<string>();
            for (int j = 0; j < nodes; j++)
                expectedResults.Add(file.ReadLine());

            //process & format data
            List<int> result = new List<int>();
            for (int i = 0; i < nodes; i++)
            {
                startNodes.Add(i);
                result = GraphTheory.processBfsGraph(graph, i);

                StringBuilder output = new StringBuilder();
                for (int j = 0; j < result.Count; j++)
                    if (startNodes[i] != j)
                        output.Append(result[j] + " ");

                Assert.AreEqual<string>(output.ToString().Trim(), expectedResults[i]);
            }
        }
        #endregion


        #region BitManipulation
        [TestMethod]
        public void TestLonelyInteger()
        {
            int a = BitManipulation.lonelyinteger(new int[] { 1 });
            Assert.AreEqual<int>(a, 1);

            int b = BitManipulation.lonelyinteger(new int[] { 1, 1, 2 });
            Assert.AreEqual<int>(b, 2);

            int c = BitManipulation.lonelyinteger(new int[] { 0, 0, 1, 2, 1 });
            Assert.AreEqual<int>(c, 2);
        }
        #endregion
    }
}
