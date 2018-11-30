using System;
using System.Collections.Generic;

namespace AdRevenue
{
    class Program
    {
        /// <summary>
        /// Sorts two lists and returns their dot product
        /// </summary>
        /// <returns></returns>
        public static long max_product(List<int> profitPerClick, List<int> averageClicks)
        {
            long result = 0;

            profitPerClick.Sort();
            averageClicks.Sort();
            for (int i = 0; i < profitPerClick.Count; i++)
            {
                result += (long)profitPerClick[i] * averageClicks[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            int numberOfElements = Int32.Parse(Console.ReadLine());
            var inputProfit = Console.ReadLine().Split(' ');
            var inputClicks = Console.ReadLine().Split(' ');

            List<int> profitPerClick = new List<int>();
            List<int> averageClicks = new List<int>();

            for (int i = 0; i < numberOfElements; i++)
            {
                profitPerClick.Add(Int32.Parse(inputProfit[i]));
                averageClicks.Add(Int32.Parse(inputClicks[i]));
            }

            long result = max_product(profitPerClick, averageClicks);

            Console.WriteLine(result);
        }
    }
}
