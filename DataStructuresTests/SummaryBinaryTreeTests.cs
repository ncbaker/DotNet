using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingProblems.DataStructures;

namespace ProgrammingProblems.DataStructuresTests
{
    [TestClass]
    public class SummaryBinaryTreeTests
    {
        [TestInitialize()]
        public void Initialize()
        {
        }

        [TestMethod]
        public void ExplodeTree()
        {//todo: use a different equalitycomparer that compares order
            HashSet<List<int>> expectedResults = SummaryBinaryTreeTestFactory.GetCareerCupTreeExplodeResult();
            SummaryBinaryTree tree = TreeFactory.GetCareerCupTree();

            HashSet<List<int>> results =
                new HashSet<List<int>>(tree.ExplodeTree().AsEnumerable(), new SummaryBinaryTreeComparer());

            Assert.IsTrue(results.SetEquals(expectedResults));
        }

        [TestMethod]
        public void SearchBranchSums()
        {
            HashSet<List<int>> expectedResults = SummaryBinaryTreeTestFactory.GetCareerCupTreeSearchSumResult7();
            SummaryBinaryTree tree = TreeFactory.GetCareerCupTree();

            HashSet<List<int>> results = 
                new HashSet<List<int>>(tree.SearchBranchSums(7).AsEnumerable(), new SummaryBinaryTreeComparer());

            Assert.IsTrue(results.SetEquals(expectedResults));
        }
    }

    public class SummaryBinaryTreeTestFactory
    {
        /* from http://www.careercup.com/question?id=5164812231245824 
                   2
                 3   5 
                4 8 6 -2
                        2
                searching 7 return {3,4}, {2,5}, {2, 5, -2, 2}
         */

        //todo move these to [TestSetup] methods?
        public static HashSet<List<int>> GetCareerCupTreeSearchSumResult7()
        {//intended results for SummaryBinaryTreeTests.SearchBranchSums(7) using TreeFactory.GetCareerCupTree() data
            HashSet<List<int>> results = new HashSet<List<int>>();
            results.Add(new List<int>() { 3, 4 });
            results.Add(new List<int>() { 2, 5 });
            results.Add(new List<int>() { 2, 5, -2, 2 });

            return results;
        }

        public static HashSet<List<int>> GetCareerCupTreeExplodeResult()
        {//intended results for SummaryBinaryTreeTests.ExplodeTree() using TreeFactory.GetCareerCupTree() data
            HashSet<List<int>> results = new HashSet<List<int>>();
            results.Add(new List<int>() { 2 });
            results.Add(new List<int>() { 2, 3 });
            results.Add(new List<int>() { 2, 3, 4 });
            results.Add(new List<int>() { 4 });
            results.Add(new List<int>() { 2, 3, 8 });
            results.Add(new List<int>() { 8 });
            results.Add(new List<int>() { 3 });
            results.Add(new List<int>() { 3, 4 });
            results.Add(new List<int>() { 3, 8 });
            results.Add(new List<int>() { 2, 5 });
            results.Add(new List<int>() { 2, 5, 6 });
            results.Add(new List<int>() { 6 });
            results.Add(new List<int>() { 2, 5, -2 });
            results.Add(new List<int>() { 2, 5, -2, 2 });
            results.Add(new List<int>() { 2 });
            results.Add(new List<int>() { -2 });
            results.Add(new List<int>() { -2, 2 });
            results.Add(new List<int>() { 5 });
            results.Add(new List<int>() { 5, 6 });
            results.Add(new List<int>() { 5, -2 });
            results.Add(new List<int>() { 5, -2, 2 });

            return results;
        }
    }
    public class SummaryBinaryTreeComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y) { return x.SequenceEqual(y); }

        //by default List<> returns Objects HashCode, which fails comparer
        public int GetHashCode(List<int> x) { return String.Join(",", x).GetHashCode(); }
    }
}
