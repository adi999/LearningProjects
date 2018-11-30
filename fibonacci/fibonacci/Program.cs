using System;
using System.Diagnostics;

namespace fibonacci
{
    class Program
    {
        static int fibonacci_naive(int n)
        {
            if (n <= 1)
                return n;
            else
            {
                return fibonacci_naive(n - 1) + fibonacci_naive(n - 2);
            }
        }

        static int fibonacci_fast(int n)
        {
            int[] fibonacciVals = new int[n+1];
            for (int i = 0; i < n+1; i++)
            {
                if (i <= 1)
                {
                    fibonacciVals[i] = i;
                }

                else
                {
                    fibonacciVals[i] = fibonacciVals[i - 1] + fibonacciVals[i - 2];
                }
            }

            return fibonacciVals[n];
        }

        static void Main(string[] args)
        {
            int n;
            n = Int32.Parse(Console.ReadLine());
            int fibonacciValue = fibonacci_fast(n);
            Console.WriteLine(fibonacciValue);

           // TestSolution();
        }

        static void TestSolution()
        {
            Debug.Assert(fibonacci_fast(3) == 2);
            Debug.Assert(fibonacci_fast(10) == 55);

            for (int i = 0; i < 10; i++)
            {
                Debug.Assert(fibonacci_naive(i) == fibonacci_fast(i));
            }
        }
    }
}
