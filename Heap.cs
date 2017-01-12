using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    public class Heap
    {
        private int[] heap = new int[1];
        private int size = 1;

        public Heap (int[] numbers)
        {

        }

        public void Insert (int[] numbers)
        {
            var newSize = numbers.Count() + size;

            if (newSize > size)
            {
                newSize = calcRequiredSize(newSize);
                var newArray = new int[newSize];

                Array.Copy(heap, newArray, size);

                heap = newArray;
            }
        }

        private int calcRequiredSize (int newSize)
        {
            var power = Math.Ceiling(Math.Log(newSize / size) / Math.Log(2));
            return (int) (size * Math.Pow(size, power));
        }
    }
}
