using System;
using System.Collections.Generic;

namespace ProgrammingProblems.DataStructures
{
    public static class TreeFactory
    {
        /* from http://www.careercup.com/question?id=5164812231245824 
                   2
                 3   5 
                4 8 6 -2
                        2
                searching 7 return {3,4}, {2,5}, {2, 5, -2, 2}
         */
        public static SummaryBinaryTree GetCareerCupTree()
        {
            SummaryBinaryNode a = new SummaryBinaryNode(3, 4, 8);
            SummaryBinaryNode b = new SummaryBinaryNode(5, 6, -2);
            SummaryBinaryTree tree = new SummaryBinaryTree(new SummaryBinaryNode(2, a, b));

            tree.Root.RightNode.RightNode.RightNode = new SummaryBinaryNode(2);

            return tree;
        }
        
        public static SimpleBinaryNode GetCareerCupTreeSimple()
        {
            SimpleBinaryNode a = new SimpleBinaryNode(3, 4, 8);
            SimpleBinaryNode b = new SimpleBinaryNode(5, 6, -2);
            SimpleBinaryNode tree = new SimpleBinaryNode(2, a, b);

            tree.RightNode.RightNode.RightNode = new SimpleBinaryNode(2);

            return tree;
        }
    }
}


