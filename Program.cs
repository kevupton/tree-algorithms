using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree(randArray(100, 1000));
        }

        static List<int> randArray(int size, int max)
        {
            var list = new List<int>();
            var random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(size));
            }

            return list;
        }
    }
}
