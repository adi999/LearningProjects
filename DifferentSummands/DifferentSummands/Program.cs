using System;
using System.Collections.Generic;

namespace DifferentSummands
{
    class Program
    {
        public static List<int> optimal_summands(int n)
        {
            List<int> summands = new List<int>();

            for (int k = n, l = 1; k > 0; l++)
            {
                if (k <= 2 * l)
                {
                    summands.Add(k);
                    k -= k;
                }
                else
                {
                    summands.Add(l);
                    k -= l;
                }
            }

            return summands;
        }
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<int> summands = optimal_summands(n);

            Console.WriteLine(summands.Count);

            for (int i = 0; i < summands.Count; i++)
            {
                Console.Write(summands[i].ToString() + " ");
            }
        }
    }
}
