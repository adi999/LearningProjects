using System;

namespace FibonacciLastDigit
{
    class Program
    {
        static int get_fibonacci_last_digit_naive(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            int prev = 0;
            int current = 1;
            for (int i = 0; i < n - 1; ++i)
            {
                int tmpPrev = prev;
                prev = current;
                current = tmpPrev + current;
            }

            return current % 10;
        }

        static int get_fibonacci_last_digit_fast(int n)
        {
            int[] fibonacciLastDigits = new int[n+1];
            for (int i = 0; i < n + 1; i++)
            {
                if (i <= 1)
                {
                    fibonacciLastDigits[i] = i;
                }

                else
                {
                    fibonacciLastDigits[i] = fibonacciLastDigits[i - 1] + fibonacciLastDigits[i - 2];
                    fibonacciLastDigits[i] %= 10;
                }
            }

            return fibonacciLastDigits[n];
        }

        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            int fibonacciLastDigit = get_fibonacci_last_digit_fast(n);
            Console.WriteLine(fibonacciLastDigit);
        }
    }
}
