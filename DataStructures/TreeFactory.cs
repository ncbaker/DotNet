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


        public static SimpleNode GetCareerCupTreeSimple1()
        {
            SimpleNode l4 = new SimpleNode() { Value = 4 };
            SimpleNode l8 = new SimpleNode() { Value = 8 };
            SimpleNode left = new SimpleNode() { Value = 3, Left = l4, Right = l8 };

            SimpleNode r6 = new SimpleNode() { Value = 6 }; ;
            SimpleNode r2 = new SimpleNode() { Value = 2 }; ;
            SimpleNode rn2 = new SimpleNode() { Value = -2, Right = r2 }; ;
            SimpleNode right = new SimpleNode() { Value = 5, Left = r6, Right = rn2 };

            return new SimpleNode() { Value = 2, Left = left, Right = right };
        }

        //public static SimpleNode<int> GetCareerCupTreeSimple2()
        //{
        //    SimpleNode<int> l4 = new SimpleNode<int>() { Value = 4 };
        //    SimpleNode<int> l8 = new SimpleNode<int>() { Value = 8 };
        //    SimpleNode<int> left = new SimpleNode<int>() { Value = 3, Left = l4, Right = l8 };

        //    SimpleNode<int> r6 = new SimpleNode<int>() { Value = 6 }; ;
        //    SimpleNode<int> r2 = new SimpleNode<int>() { Value = 2 }; ;
        //    SimpleNode<int> rn2 = new SimpleNode<int>() { Value = -2, Right = r2 }; ;
        //    SimpleNode<int> right = new SimpleNode<int>() { Value = 5, Left = r6, Right = rn2 };

        //    return new SimpleNode<int>() { Value = 2, Left = left, Right = right };
        //}
    }
}


