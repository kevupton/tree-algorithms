﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    public class Node
    {
        private Node left = null;
        private Node right = null;

        private int value;

        public Node (int value)
        {
            this.value = value;
        }

        public int Size
        {
            get
            {
                var size = 1;
                if (HasLeft) size += left.Size;
                if (HasRight) size += right.Size;
                return size;
            }
        }

        public bool HasLeft
        {
            get
            {
                return left != null;
            }
        }

        public bool HasRight
        {
            get
            {
                return right != null;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }
        }

        public Node Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public Node Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        public void SwapChild (Node child, Node with)
        {
            if (child == left) Left = with;
            if (child == right) Right = with;
        }
    }
}
