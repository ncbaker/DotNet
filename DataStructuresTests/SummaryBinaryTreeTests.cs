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
        public void TestMethod1()
        {
            HashSet<List<int>> expectedResults = TreeFactory.GetCareerCupTreeResult();
            SummaryBinaryTree tree = TreeFactory.GetCareerCupTree();

            HashSet<List<int>> results = 
                new HashSet<List<int>>(tree.SearchBranchSums(7).AsEnumerable(), new SummaryBinaryTreeComparer());

            Assert.IsTrue(results.SetEquals(expectedResults));
        }
    }


    public class SummaryBinaryTreeComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y) { return x.SequenceEqual(y); }

        public int GetHashCode(List<int> x) { return 1; }
    }
}
