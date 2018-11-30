using System;
using System.Collections.Generic;

namespace Inversions
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
                inputValues.Add(Int32.Parse(input?[i]));
            }

            int numberOfInversions = 0;
            inputValues = MergeSort(inputValues, 0, inputValues.Count, ref numberOfInversions);

            Console.WriteLine(numberOfInversions);
            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(inputValues[i] + " ");
            //}
        }

        private static List<long> MergeSort(List<long> inputValues, int l, int r, ref int numberOfInversions)
        {
            if (r - l == 1)
            {
                return new List<long>() {inputValues[l]};
            }

            int m = l + (r - l) / 2;
            var inputHalf1 = MergeSort(inputValues, l, m, ref numberOfInversions);
            var inputHalf2 = MergeSort(inputValues, m, r, ref numberOfInversions);
            var input = Merge(inputHalf1, inputHalf2, ref numberOfInversions);

            return input;
        }

        private static List<long> Merge(List<long> inputHalf1, List<long> inputHalf2, ref int numberOfInversions)
        {
            List<long> input = new List<long>();

            int input1Counter = 0;
            int input2Counter = 0;
            while (input1Counter < inputHalf1.Count && input2Counter < inputHalf2.Count)
            {
                if (inputHalf1[input1Counter] <= inputHalf2[input2Counter])
                {
                    input.Add(inputHalf1[input1Counter]);
                    input1Counter++;
                }
                else
                {
                    input.Add(inputHalf2[input2Counter]);
                    numberOfInversions += inputHalf1.Count - input1Counter;
                    input2Counter++;
                    
                }
            }

            for (int i = input1Counter; i < inputHalf1.Count; i++)
            {
                input.Add(inputHalf1[i]);
            }

            for (int i = input2Counter; i < inputHalf2.Count; i++)
            {
                input.Add(inputHalf2[i]);
            }

            return input;
        }
    }
}
