using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


/*
 *   Redo this entire thing.  Look to solve CareerCup problem with DFS Pre-order traversal.
 *   Then create a bunch of test cases & unit tests
 *   After that redo front page to point to new algorithm then delete the pointers to old algorithms
 *   Maybe just ditch the web app entirely, use the console for testing, and put up a web front end eventually on a blog
 */

namespace ProgrammingProblems.DataStructures
{
    #region Node
    public class Node<T>
    {
        #region properties
        private NodeList<T> _children;
        public T Value { get; protected set; }
        public NodeList<T> Children { get { return _children; } protected set { _children = value; } }
        #endregion


        #region constructors
        public Node() { _children = new NodeList<T>(); }
        public Node(T value) : this(value, new NodeList<T>()) {}
        public Node(T value, NodeList<T> nodes)
        {
            Value = value;
            _children = nodes;
        }
        #endregion
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() { }
        public NodeList(int length) 
        {
            for (int i = 0; i < length; i++)
                this.Add(new Node<T>());
        }
        public Node<T> Find(T Value)
        {
            foreach (var node in this)
                if (node.Value.Equals(Value))
                    return node;

            return null;
        }
        public Node<T> GetAt(int position)
        {
            for (int i = 0; i < this.Count; i++)
                if (i == position)
                    return this[i];

            return null;
        }
    }
    #endregion


    #region Binary Tree
    public class BinaryNode<T> : Node<T>
    {
        #region properties
        public bool HasChildren { get { return Children.Count > 0; } }
        public BinaryNode<T> Parent { get; protected set; }
        public BinaryNode<T> LeftNode { get { return GetNodeAt(0); } set { SetNodeAt(0, value); } }
        public BinaryNode<T> RightNode { get { return GetNodeAt(1); } set { SetNodeAt(1, value); } }
        #endregion 


        #region constructors
        public BinaryNode() : base() { Initialize(); }
        public BinaryNode(T value) : base(value, null) { Initialize(); }
        public BinaryNode(T value, T left, T right)
            : this(value, new BinaryNode<T>(left), new BinaryNode<T>(right) ) { }
        public BinaryNode(T value, BinaryNode<T> left, BinaryNode<T> right) : this()
        {
            Value = value;
            LeftNode = left;
            RightNode = right;
        }
        #endregion


        #region methods
        private void Initialize() { Children = new NodeList<T>(2); }

        private BinaryNode<T> GetNodeAt(int index)
        {
            return Children[index] as BinaryNode<T>;
        }
        
        private void SetNodeAt(int index, BinaryNode<T> node)
        {
            node.Parent = this;
            Children[index] = node;
        }
        #endregion
    }

    public class BinaryTree<T>
    {
        public BinaryNode<T> Root { get; protected set; }

        public BinaryTree() {}
        public BinaryTree(BinaryNode<T> root) { Root = root; }

        public void Clear() { Root = null; }
    }
    #endregion


    #region Summary Binary Tree
    public class SummaryBinaryNode : BinaryNode<int>
    {
        internal bool Added { get; set; }
        public new SummaryBinaryNode Parent { get { return (SummaryBinaryNode)base.Parent; } set { base.Parent = value; } }
        public new SummaryBinaryNode LeftNode { get { return (SummaryBinaryNode)base.LeftNode; } set { base.LeftNode = value; } }
        public new SummaryBinaryNode RightNode { get { return (SummaryBinaryNode)base.RightNode; } set { base.RightNode = value; } }

        public SummaryBinaryNode() : base() {}
        public SummaryBinaryNode(int value) : base(value) { }
        public SummaryBinaryNode(int value, int left, int right) : base(value, new SummaryBinaryNode(left), new SummaryBinaryNode(right)) { }
        public SummaryBinaryNode(int value, SummaryBinaryNode left, SummaryBinaryNode right) : base(value, left, right) { }
    }

    public class SummaryBinaryTree : BinaryTree<int>
    {
        public new SummaryBinaryNode Root { get { return (SummaryBinaryNode)base.Root; } set { base.Root = value; } }
        public SummaryBinaryTree() {}
        public SummaryBinaryTree(SummaryBinaryNode root) { Root = root; }

        //Returns all combinations of branches & sub-branches of the tree.
        public List<List<int>> ExplodeTree()
        {
            List<List<int>> list = new List<List<int>>();

            list.Add(new List<int>() { this.Root.Value });
            list.AddRange(ExplodeNode(this.Root, list[0]));

            ResetNode((SummaryBinaryNode)this.Root);

            return list;
        }

        private List<List<int>> ExplodeNode(SummaryBinaryNode node, List<int> ancenstors)
        {
            List<List<int>> ancenstorsPlus = new List<List<int>>();

            if (node.LeftNode != null)
                ancenstorsPlus.AddRange(ExplodeChild(node.LeftNode, ancenstors));

            if (node.RightNode != null)
                ancenstorsPlus.AddRange(ExplodeChild(node.RightNode, ancenstors));

            return ancenstorsPlus;
        }

        private List<List<int>> ExplodeChild(SummaryBinaryNode node, List<int> ancenstors)
        {
            List<List<int>> ancenstorsPlus = new List<List<int>>();
            if (node == null)
                return ancenstorsPlus;

            //add to existing branch
            List<int> l = new List<int>(ancenstors);
            l.Add(node.Value);
            ancenstorsPlus.Add(l);
            ancenstorsPlus.AddRange(ExplodeNode(node, l));

            //begin as new branch
            if (!node.Added)
            {
                ancenstorsPlus.Add(new List<int>() { node.Value });
                node.Added = true;
                ancenstorsPlus.AddRange(ExplodeNode(node, ancenstorsPlus.Last()));
            }

            return ancenstorsPlus;
        }

        //keeping extra step to convert back to hash set temporarily.  tree allows better debugging.
        public List<List<int>> SearchBranchSums(int total)
        {
            Dictionary<int, List<int>> v = new Dictionary<int, List<int>>();

            List<List<int>> list = (this as SummaryBinaryTree).ExplodeTree();
            
            for (int i = list.Count - 1; i >= 0; i--)
                if (list[i].Sum() == total)
                    v.Add(i, list[i]);

            return v.Values.ToList();
            //return new HashSet<List<int>>(v.Values.AsEnumerable());
        }

        private void ResetNode(SummaryBinaryNode node)
        {
            node.Added = false;
            if (node.LeftNode != null)
                ResetNode(node.LeftNode);
            if (node.RightNode != null)
                ResetNode(node.RightNode);
        }
    }
    #endregion


    #region
    public class SimpleBinaryNode
    {
        #region properties                
        private SimpleBinaryNode _left, _right;
        public int Value { get; protected set; }
        public SimpleBinaryNode Parent { get; set; }
        public SimpleBinaryNode LeftNode { get { return _left; } set { _left = value; _left.Parent = this; } }
        public SimpleBinaryNode RightNode { get { return _right; } set { _right = value; _right.Parent = this; } }
        #endregion


        #region constructors
        public SimpleBinaryNode() {}
        public SimpleBinaryNode(int value) { Value = value; }
        public SimpleBinaryNode(int value, int left, int right) : this(value, new SimpleBinaryNode(left), new SimpleBinaryNode(right)) { }
        public SimpleBinaryNode(int value, SimpleBinaryNode left, SimpleBinaryNode right) 
        { 
            Value = value;
            LeftNode = left;
            RightNode = right;
        }
        #endregion
    }
    #endregion



    #region
    //public class SimpleNode<T>
    //{
    //    public T Value { get; set; }
    //    public SimpleNode<T> Left { get; set; }
    //    public SimpleNode<T> Right { get; set; }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        var leftEnumerable = (IEnumerable<T>)Left ?? new T[0];
    //        var rightEnumerable = (IEnumerable<T>)Right ?? new T[0];
                        
    //        return leftEnumerable.Concat(new T[] { Value })
    //                             .Concat(rightEnumerable)
    //                             .GetEnumerator();
    //    }
    //    //public IEnumerator GetEnumerator()
    //    //{
    //    //    if (Left != null)
    //    //    {
    //    //        foreach (var v in Left)
    //    //        {
    //    //            yield return v;
    //    //        }
    //    //    }

    //    //    yield return Value;

    //    //    if (Right != null)
    //    //    {
    //    //        foreach (var v in Right)
    //    //        {
    //    //            yield return v;
    //    //        }
    //    //    }
    //    //}
    //    //public List<SimpleNode> Preorder(SimpleNode root, List<SimpleNode> nodes)
    //    //{
    //    //    nodes.Add(root);

    //    //    if (root.Left != null)
    //    //        Preorder(root.Left, nodes);
    //    //    if (root.Right != null)
    //    //        Preorder(root.Right, nodes);

    //    //    return nodes;
    //    //}
    //    //public List<List<SimpleNode>> GetPathsWithSum(int search)
    //    //{

    //    //}
    //}

    public class SimpleNode
    {
        public int Value { get; set; }
        public SimpleNode Left { get; set; }
        public SimpleNode Right { get; set; }
    }
    public static class SimpleNodeHelper
    {
        public static List<List<string>> findPathsWithSumN(SimpleNode node, int searchValue)
        {
            var result = new List<List<string>>();

            Preorder(TreeFactory.GetCareerCupTreeSimple1(), searchValue, 0, result, new List<string>());

            return result;
        }
        private static void Preorder(SimpleNode root, int searchValue, int currentSum, List<List<string>> foundPaths, List<string> currentPath)
        {
            if (root == null)
                return;

            currentPath.Add(root.Value.ToString());
            currentSum += root.Value;

            if (currentSum == searchValue)
                foundPaths.Add(new List<string>(currentPath));

            if (root.Left != null)
                Preorder(root.Left, searchValue, currentSum, foundPaths, new List<string>(currentPath));
            if (root.Right != null)
                Preorder(root.Right, searchValue, currentSum, foundPaths, new List<string>(currentPath));

            currentSum = 0;
            currentPath.Clear();
        }
    }


        //PreOrder
        //    nodes.Add(root);

        //    if (root.Left != null)
        //        Preorder(root.Left, nodes);
        //    if (root.Right != null)
        //        Preorder(root.Right, nodes);
        //public IEnumerator GetEnumerator()
        //{
        //    yield return Value;

        //    if (Left != null)
        //        foreach (var v in Left)
        //            yield return v;

        //    if (Right != null)
        //        foreach (var v in Right)
        //            yield return v;

        //    yield return null;
        //}

        //InOrder
        //public IEnumerator GetInOrderEnumerator()
        //{
        //    if (Left != null)
        //    {
        //        foreach (var v in Left)
        //        {
        //            yield return v;
        //        }
        //    }

        //    yield return Value;

        //    if (Right != null)
        //    {
        //        foreach (var v in Right)
        //        {
        //            yield return v;
        //        }
        //    }
        //}
        //public List<SimpleNode> Preorder(SimpleNode root, List<SimpleNode> nodes)
        //{
        //    nodes.Add(root);

        //    if (root.Left != null)
        //        Preorder(root.Left, nodes);
        //    if (root.Right != null)
        //        Preorder(root.Right, nodes);

        //    return nodes;
        //}
        //public List<List<SimpleNode>> GetPathsWithSum(int search)
        //{

        //}

    #endregion
}
