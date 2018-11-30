using System;
using System.Collections.Generic;

namespace MaximumSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            var values = Console.ReadLine().Split(' ');
            List<string> numbers = new List<string>();

            for (int i = 0; i < n; i++)
            {
                numbers.Add(values[i]);
            }

            Console.WriteLine(largest_number(numbers));
        }

        public static string largest_number(List<string> numbers)
        {
            string result = String.Empty;

            numbers.Sort(new Comparison<string>((x,y)=>-1*(x+y).CompareTo(y+x)));

            foreach (var entry in numbers)
            {
                result += entry;
            }

            return result;
        }
    }
}
