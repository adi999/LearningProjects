using System;

namespace fibonacciHuge
{
    class Program
    {
        static long get_pisano_period(long m)
        {
            long pisanoPeriod = -1;
            long a = 0, b = 1, c = a + b;

            for (int i = 0; i < m * m; i++)
            {
                c = (a + b) % m;
                a = b;
                b = c;
                if (a == 0 && b == 1)
                {
                    pisanoPeriod = i + 1;
                    break;
                }
            }

            return pisanoPeriod;
        }


        //static long get_fibonacci_huge_fast(long n, long m)
        //{
        //    long remainder = n % get_pisano_period(m);

        //    long first = 0, second = 1;
        //    long res = remainder;

        //    for (int i = 1; i < remainder; i++)
        //    {
        //        res = (first + second) % m;
        //        first = second;
        //        second = res;
        //    }

        //    return res;
        //}

        //static long fibonacci_sum_fast(long n)
        //{
        //    //long remainder1 = (n + 2) % get_pisano_period(10);

        //    //long remainder2 = (n + 2) % get_pisano_period(10);

        //    long firstFib =  FibonacciSum(remainder1);
        //    long secondFib = FibonacciSum(remainder2);

        //    return (firstFib * secondFib) % 10;
        //}

        private static long FibonacciSum(long remainder)
        {
            long first = 0, second = 1;
            long res = remainder;
            for (int i = 1; i < remainder; i++)
            {
                res = (first + second) % 10;
                first = second;
                second = res;
            }

            return res;
        }

        static long fibonacci_sum_squares_fast(long n)
        {
            long remainder1 = (n) % 60;

            long remainder2 = (n + 1) % 60;

            long firstFib = FibonacciSum(remainder1);
            long secondFib = FibonacciSum(remainder2);

            return (firstFib * secondFib) % 10;
        }

        //static long get_fibonacci_partial_sum_fast(long from, long to)
        //{
        //    long[] fibonacciVals = new long[61];
        //    for (int i = 0; i < 61; i++)
        //    {
        //        if (i <= 1)
        //        {
        //            fibonacciVals[i] = i;
        //        }

        //        else
        //        {
        //            fibonacciVals[i] = fibonacciVals[i - 1] + fibonacciVals[i - 2];
        //        }
        //    }

        //    from = from % 60;
        //    to = to % 60;
        //    while (to < from)
        //    {
        //        to += 60;
        //    }

        //    long sum = 0;
        //    for (long j = from; j < (to + 1); j++)
        //    {
        //        sum += fibonacciVals[j % 60];
        //    }

        //    return sum % 10;
        //}

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            //var tokens = input.Split(' ');
            //long m = long.Parse(tokens[0]);
            long n = long.Parse(input);
            long fibonacciSumFast = fibonacci_sum_squares_fast(n);
            Console.WriteLine(fibonacciSumFast);
        }
    }
}
