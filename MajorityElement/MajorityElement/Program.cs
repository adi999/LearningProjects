using System;
using System.Collections.Generic;

namespace MajorityElement
{
    class Program
    {
        public static int CountValue(List<long> values, long value, int low, int high)
        {
            int count = 0;
            for (int i = low; i <= high; i++)
            {
                if (values[i] == value)
                {
                    count++;
                }
            }

            return count;
        }

        public static long MajorityElement(List<long> values, int low, int high)
        {
            // base case; the only element in an array of size 1 is the majority
            // element.
            if (low == high)
            {
                return values[low];
            }

            // recurse on left and right halves of this slice.
            int mid = (high - low) / 2 + low;
            long left = MajorityElement(values, low, mid);
            long right = MajorityElement(values, mid + 1, high);

            // if the two halves agree on the majority element, return it.
            if (left == right)
            {
                return left;
            }

            // otherwise, count each element and return the "winner".
            int leftCount = CountValue(values, left, low, high);
            int rightCount = CountValue(values, right, low, high);

            if (leftCount >= ((high - low) + 1) / 2 + 1)
            {
                return left;
            }

            else if (rightCount >= ((high - low) + 1) / 2 + 1)
            {
                return right;
            }

            else
            {
                return -1;
            }
        }


        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            var input = Console.ReadLine()?.Split(' ');

            List<long> inputValues = new List<long>();

            for (int i = 0; i < n; i++)
            {
                inputValues.Add(Int64.Parse(input?[i]));
            }

            long majorityElementValue = MajorityElement(inputValues, 0, inputValues.Count - 1);

            if (majorityElementValue != -1)
            {
                majorityElementValue = 1;
            }

            else
            {
                majorityElementValue = 0;
            }
            Console.WriteLine(majorityElementValue);
        }
    }
}
