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
            throw new NotImplementedException();
        }
    }
}
