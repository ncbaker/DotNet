using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProgrammingProblems.DataStructures
{
    #region Node
    public class Node<T>
    {
        private NodeList<T> _children;

        public T Value { get; protected set; }
        public NodeList<T> Children { get { return _children; } protected set { _children = value; } }

        public Node() { _children = new NodeList<T>(); }
        public Node(T value) : this(value, new NodeList<T>()) {}
        public Node(T value, NodeList<T> nodes)
        {
            Value = value;
            _children = nodes;
        }
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
        public bool Added { get; set; }
        public bool HasChildren { get { return Children.Count > 0; } }
        public BinaryNode<T> Parent { get; private set; }
        public BinaryNode<T> LeftNode { get { return GetNodeAt(0); } set { SetNodeAt(0, value); } }
        public BinaryNode<T> RightNode { get { return GetNodeAt(1); } set { SetNodeAt(1, value); } }

        public BinaryNode() : base() { InitChildren(); }
        public BinaryNode(T value) : base(value, null) { InitChildren(); }
        public BinaryNode(T value, T left, T right)
            : this(value, new BinaryNode<T>(left), new BinaryNode<T>(right) ) { }
        public BinaryNode(T value, BinaryNode<T> left, BinaryNode<T> right) : this()
        {
            Value = value;
            left.Parent = right.Parent = this;
            
            Children[0] = left;
            Children[1] = right;
        }

        private void InitChildren() { Children = new NodeList<T>(2); }

        private BinaryNode<T> GetNodeAt(int index)
        {
            return Children.Count == 0 ? null : Children[index] as BinaryNode<T>;
        }
        
        private void SetNodeAt(int index, BinaryNode<T> node)
        {
            if (Children.Count == 0)
                InitChildren();

            node.Parent = this;
            Children[index] = node;
        }

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
    public class SummaryBinaryNode<T> : BinaryNode<T>
    {
        public SummaryBinaryNode() : base() {}
        public SummaryBinaryNode(T value) : base(value) { }
        public SummaryBinaryNode(T value, T left, T right): base(value, left, right) {}
        public SummaryBinaryNode(T value, BinaryNode<T> left, BinaryNode<T> right) : base(value, left, right) { }
    }

    public class SummaryBinaryTree<T> : BinaryTree<T>
    {
        public SummaryBinaryTree() {}
        public SummaryBinaryTree(BinaryNode<T> root) { Root = root; }

        //Returns all combinations of branches & sub-branches of the tree.
        public List<List<T>> ExplodeTree()
        {
            List<List<T>> list = new List<List<T>>();

            list.Add(new List<T>() { this.Root.Value });
            list.AddRange(ExplodeNode(this.Root, list[0]));

            ResetNode(this.Root);

            return list;
        }

        //Create a copy of the List adding the Left & Right nodes to the end of each List<int> 
        private List<List<T>> ExplodeNode(BinaryNode<T> node, List<T> ancenstors)
        {
            List<List<T>> ancenstorsPlus = new List<List<T>>();

            if (node.LeftNode != null)
                ancenstorsPlus.AddRange(ExplodeChild(node.LeftNode, ancenstors));

            if (node.RightNode != null)
                ancenstorsPlus.AddRange(ExplodeChild(node.RightNode, ancenstors));

            return ancenstorsPlus;
        }

        //Explode Child node and Recursively move down the inner branches until the leaves are reached.
        private List<List<T>> ExplodeChild(BinaryNode<T> node, List<T> ancenstors)
        {
            List<List<T>> ancenstorsPlus = new List<List<T>>();
            if (node == null)
                return ancenstorsPlus;

            //add to existing branch
            List<T> l = new List<T>(ancenstors);
            l.Add(node.Value);
            ancenstorsPlus.Add(l);
            ancenstorsPlus.AddRange(ExplodeNode(node, l));

            //begin as new branch   //(node as SummaryBinaryNode<T>)
            if (!node.Added)
            {
                ancenstorsPlus.Add(new List<T>() { node.Value });
                node.Added = true;
                ancenstorsPlus.AddRange(ExplodeNode(node, ancenstorsPlus.Last()));
            }

            return ancenstorsPlus;
        }

        //returns every List whose sum is matches the total parameter
        public Dictionary<int, List<int>> SearchBranchSummaries(int total)
        {
            Dictionary<int, List<int>> v = new Dictionary<int, List<int>>();

            List<List<int>> list = (this as SummaryBinaryTree<int>).ExplodeTree();
            
            for (int i = list.Count - 1; i >= 0; i--)
                if (list[i].Sum() == total)
                    v.Add(i, list[i]);

            return v;
        }

        private void ResetNode(BinaryNode<T> node)
        {
            node.Added = false;
            if (node.LeftNode != null)
                ResetNode(node.LeftNode);
            if (node.RightNode != null)
                ResetNode(node.RightNode);
        }
    }
    #endregion
}
