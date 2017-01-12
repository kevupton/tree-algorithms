using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    public abstract class Tree
    {
        public enum TraversalMethod
        {
            InOrder,
            PreOrder,
            PostOrder
        }

        protected Node root = null;
        
        public Tree() { }

        public Tree(List<int> numbers)
        {
            Insert(numbers);
        }

        public Tree(int[] numbers) : this(numbers.ToList()) { }
        public Tree(int number) : this(new List<int> { number }) { }

        public bool HasNodes
        {
            get
            {
                return root != null;
            }
        }

        public void Insert(List<int> list)
        {
            list.ForEach(Insert);
        }

        public void Insert(int nb)
        {
            var node = new Node(nb);
            if (!HasNodes)
            {
                root = node;
            }
            else
            {
                insertNode(root);
            }
        }

        public void Remove(List<int> list)
        {
            list.ForEach(Remove);
        }

        public void Remove(int nb)
        {
            removeNode(nb);
        }

        public void Clear()
        {
            root = null;
        }

        protected abstract void insertNode(Node node);
        protected abstract void removeNode(int nb);

        public List<int> Traverse (TraversalMethod method)
        {
            var list = new List<int>();
            switch (method)
            {
                case TraversalMethod.InOrder:
                    traverseInOrder(list, root);
                    break;
                case TraversalMethod.PreOrder:
                    traversePreOrder(list, root);
                    break;
                case TraversalMethod.PostOrder:
                    traversePostOrder(list, root);
                    break;
            }
            return list;
        }

        private void traverseInOrder (List<int> list, Node node)
        {
            if (node == null) return;

            traverseInOrder(list, node.Left);
            list.Add(node.Value);
            traverseInOrder(list, node.Left);
        }

        private void traversePostOrder(List<int> list, Node node)
        {
            if (node == null) return;

            traversePostOrder(list, node.Left);
            traversePostOrder(list, node.Left);
            list.Add(node.Value);
        }

        private void traversePreOrder(List<int> list, Node node)
        {
            if (node == null) return;

            list.Add(node.Value);
            traversePreOrder(list, node.Left);
            traversePreOrder(list, node.Left);
        }
    }
}
