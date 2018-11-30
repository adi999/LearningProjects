using System;

namespace GreatestCommonDivisor
{
    class Program
    {

        static int gcd_naive(int a, int b)
        {
            int current_gcd = 1;

            for (int d = 2; d <= a && d <= b; d++)
            {
                if (a % d == 0 && b % d == 0)
                {
                    if (d > current_gcd)
                    {
                        current_gcd = d;
                    }
                }
            }

            return current_gcd;
        }

        static long gcd_fast(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }

            return gcd_fast(b, a % b);
        }

        static long lcm_fast(long a, long b)
        {
            long lcm =  a * b / gcd_fast(a, b);

            return lcm;
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            long a = long.Parse(tokens[0]);
            long b = long.Parse(tokens[1]);

            long lcmVal = lcm_fast(a, b);

            Console.WriteLine(lcmVal);
        }
    }
}
