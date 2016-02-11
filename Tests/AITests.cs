using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProgrammingProblems.Algorithms;
using System.Text;

namespace ProgrammingProblems.Test
{
    [TestClass]
    public class AITests
    {
        #region Bot Building
        [TestMethod]
        public void TestSavesPrincess()
        {
            string[] input = new string[] { "---", "-m-", "p--" };
            string[] expected = new string[] { "LEFT", "DOWN" };
            CollectionAssert.AreEqual(AI.BotBuilding.displayPathtoPrincess(input.Length, input).ToArray(), expected);

            input = new string[] { "----p", "-----", "-----", "-m---", "-----" };
            expected = new string[] { "RIGHT", "RIGHT", "RIGHT", "UP", "UP", "UP" };
            CollectionAssert.AreEqual(AI.BotBuilding.displayPathtoPrincess(input.Length, input).ToArray(), expected);
        }
        #endregion
    }
}
