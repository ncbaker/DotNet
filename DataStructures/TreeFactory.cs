using System;

namespace NCB.DataStructures
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
        public static SummaryBinaryTree<int> GetCareerCupTree()
        {
            SummaryBinaryNode<int> a = new SummaryBinaryNode<int>(3, 4, 8);
            SummaryBinaryNode<int> b = new SummaryBinaryNode<int>(5, 6, -2);
            SummaryBinaryTree<int> tree = new SummaryBinaryTree<int>(new SummaryBinaryNode<int>(2, a, b));

            tree.Root.RightNode.RightNode.RightNode = new SummaryBinaryNode<int>(2);

            return tree;
        }
    }
}


