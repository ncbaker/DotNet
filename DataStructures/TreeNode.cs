using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Data
{
    public class DSTreeNode<T>
    {
        public T Value { get; private set; }
        LinkedList<DSTreeNode<T>> _nodes;

        public DSTreeNode(T data)
        {
            Value = data;
            _nodes = new LinkedList<DSTreeNode<T>>();
        }

        public void AddChild(DSTreeNode<T> node)
        {
            if (typeof(T) != typeof(System.Int32))
                throw new Exception("AddChild type exception");

            _nodes.AddLast(node);
            //return _nodes.Last;
        }

        public List<DSTreeNode<T>> SearchNodesBySumValue(int branchSum)
        {
            return new List<DSTreeNode<T>>();
        }
    }
}
