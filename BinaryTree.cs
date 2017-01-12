using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    public class BinaryTree : Tree
    {
        public BinaryTree(List<int> list) : base(list) { }

        protected override void insertNode(Node node)
        {
            var placed = false;
            var currentNode = root;

            while (!placed)
            {
                if (node.Value < currentNode.Value)
                {
                    if (!currentNode.HasLeft)
                    {
                        currentNode.Left = node;
                        placed = true;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    if (!currentNode.HasRight)
                    {
                        currentNode.Right = node;
                        placed = true;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
            }
        }

        protected override void removeNode(int nb)
        {
            var tuple = depthFirstSearch(nb);

            var node = tuple.Item1;
            var parent = tuple.Item2;

            if (node == null) return;

            Node toReplace = null;

            if (node.HasRight)
            {
                toReplace = node.Right;
                Node toReplaceParent = node;

                while (toReplace.HasLeft)
                {
                    toReplaceParent = toReplace;
                    toReplace = toReplace.Left;
                }

                toReplace.Left = node.Left;
                toReplaceParent.Left = toReplace.Right;

                if (node.Right != toReplace)
                {
                    toReplace.Right = node.Right;
                }
            }
            else
            {
                toReplace = node.Left;
            }

            if (node == root)
            {
                root = toReplace;
            }
            else
            {
                parent.SwapChild(node, toReplace);
            }
        }
    }
}
