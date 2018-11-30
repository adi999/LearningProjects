using System;

namespace MaximumPairwiseProduct
{
    class Program
    {

        static long MaxPairwiseProductNaive(long[] array)
        {
            long maxProduct = 0;
            int inputLength = array.Length;

            for (int i = 0; i < inputLength; i++)
            {
                for (int j = i + 1; j < inputLength; j++)
                {
                    maxProduct = Math.Max(array[i] * array[j], maxProduct);
                }
            }

            return maxProduct;
        }

        public static long MaxPairwiseProduct(long[] array)
        {
            long largestNum = array[0];
            long secondLargestNum = -1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > largestNum)
                {
                    secondLargestNum = largestNum;
                    largestNum = array[i];
                }

                else if (array[i] > secondLargestNum)
                {
                    secondLargestNum = array[i];
                }

            }

            return largestNum * secondLargestNum;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var tokens = input.Split(' ');
            long[] array = new long[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = long.Parse(tokens[i]);
            }

            long result = MaxPairwiseProduct(array);
            Console.WriteLine(result);
        }
    }
}
