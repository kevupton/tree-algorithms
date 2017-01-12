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
                insertNode(node);
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
            traverseInOrder(list, node.Right);
        }

        private void traversePostOrder(List<int> list, Node node)
        {
            if (node == null) return;

            traversePostOrder(list, node.Left);
            traversePostOrder(list, node.Right);
            list.Add(node.Value);
        }

        private void traversePreOrder(List<int> list, Node node)
        {
            if (node == null) return;

            list.Add(node.Value);
            traversePreOrder(list, node.Left);
            traversePreOrder(list, node.Right);
        }

        protected Tuple<Node, Node> depthFirstSearch (int nb)
        {
            var stack = new Stack<Tuple<Node, Node>>();
            stack.Push(new Tuple<Node, Node>(root, null));

            while (stack.Count > 0)
            {
                var tuple = stack.Pop();
                
                if (tuple.Item1.Value == nb)
                {
                    return tuple;
                }
                else
                {
                    if (tuple.Item1.HasRight) stack.Push(new Tuple<Node, Node>(tuple.Item1.Right, tuple.Item1));
                    if (tuple.Item1.HasLeft) stack.Push(new Tuple<Node, Node>(tuple.Item1.Left, tuple.Item1));
                }
            }

            return null;
        }

        protected Tuple<Node, Node> breadthFirstSearch (int nb)
        {
            var queue = new Queue<Tuple<Node, Node>>();
            queue.Enqueue(new Tuple<Node, Node>(root, null));

            while (queue.Count > 0)
            {
                var tuple = queue.Dequeue();

                if (tuple.Item1.Value == nb)
                {
                    return tuple;
                }
                else
                {
                    if (tuple.Item1.HasLeft) queue.Enqueue(new Tuple<Node, Node>(tuple.Item1.Left, tuple.Item1));
                    if (tuple.Item1.HasRight) queue.Enqueue(new Tuple<Node, Node>(tuple.Item1.Right, tuple.Item1));
                }
            }

            return null;
        }
    }
}
