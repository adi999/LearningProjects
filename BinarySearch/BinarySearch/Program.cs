using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
        public static int BinarySearch(List<int> numList, int low, int high, int key)
        {
            if (high < low)
            {
                return -1;
            }

            int mid = low + (int)Math.Floor((double)(high - low) / 2);

            if (key == numList[mid])
            {
                return mid;
            }

            else if (key < numList[mid])
            {
                return BinarySearch(numList, low, mid - 1, key);
            }

            else
            {
                return BinarySearch(numList, mid + 1, high, key);
            }
        }
        static void Main(string[] args)
        {
            var inputList = Console.ReadLine()?.Split(' ');

            int inputListSize = Int32.Parse(inputList?[0]);
            List<int> inputListToSearch = new List<int>();

            for (int i = 0; i < inputListSize; i++)
            {
                inputListToSearch.Add(Int32.Parse(inputList?[i+1]));
            }

            var numbersToSearch = Console.ReadLine()?.Split(' ');
            int numbersToSearchSize = Int32.Parse(numbersToSearch?[0]);
            List<int> numbersListToSearch = new List<int>();

            for (int i = 0; i < numbersToSearchSize; i++)
            {
                int key = Int32.Parse(numbersToSearch?[i+1]);
                int keyPosition = BinarySearch(inputListToSearch, 0, inputListToSearch.Count - 1, key);
                Console.Write(keyPosition.ToString() + " ");
            }
        }
    }
}
