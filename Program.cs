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
            var array = randArray(5, 100);
            var tree = new BinaryTree(array);
            Console.WriteLine("removed: " + array[0] + "\n");
            tree.Remove(array[0]);
            tree.Traverse(Tree.TraversalMethod.InOrder).ForEach(nb => System.Console.WriteLine(nb));


            Console.ReadKey();
        }

        static List<int> randArray(int size, int max)
        {
            var list = new List<int>();
            var random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(max));
            }

            return list;
        }
    }
}
