using System;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            var input = Console.ReadLine()?.Split(' ');
            List<long> inputValues = new List<long>();
            for (int i = 0; i < n; i++)
            {
                if (input != null) inputValues.Add(Int32.Parse(input[i]));
            }

            RandomizedQuickSort(inputValues, 0, inputValues.Count - 1);

            for (int i = 0; i < n; i++)
            {
                Console.Write(inputValues[i] + " ");
            }
        }

        private static void RandomizedQuickSort(List<long> inputValues, int l, int r)
        {
            if (l >= r)
            {
                return;
            }
            //Random rand = new Random();
            //int k = rand.Next(l, r);
            //Swap(inputValues[l], inputValues[k]);
            var m = Partition3(inputValues, l, r);
            RandomizedQuickSort(inputValues, l, m[0] - 1);
            RandomizedQuickSort(inputValues, m[1] + 1, r);
        }

        private static int Partition2(List<long> inputValues, int l, int r)
        {
            long x = inputValues[l];
            int j = l;
            for (int i = l + 1; i <= r; i++)
            {
                if (inputValues[i] <= x)
                {
                    j++;
                    Swap(inputValues, i , j);
                }
            }
            Swap(inputValues, l, j);
            return j;
        }

        private static List<int> Partition3(List<long> inputValues, int l, int r)
        {
            long x = inputValues[l];
            int begin = l + 1;
            int end = l;

            for (int i = l + 1; i <= r; i++)
            {
                if (inputValues[i] <= x)
                {
                    end++;
                    Swap(inputValues, i,end);
                    if (inputValues[end] < x)
                    {
                        Swap(inputValues, begin, end);
                        begin += 1;
                    }
                }
            }
            Swap(inputValues, l, begin-1);

            return new List<int>() {begin, end};
        }

        private static void Swap(List<long> inputValues, int i, int j)
        {
            long swapValue = inputValues[i];
            inputValues[i] = inputValues[j];
            inputValues[j] = swapValue;
        }
    }
}
