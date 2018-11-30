using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimitiveCalculator
{
    class Program
    {
        public class Operations
        {
            public int count;
            public List<int> Intermediates;

            public Operations()
            {
                count = Int32.MaxValue;
                Intermediates = new List<int>();
            }
        }
        private static List<int> GetNumberOfOperations(int number)
        {
            Dictionary<int, Operations> Operations = new Dictionary<int, Operations>();
            
            Operations.Add(1,new Operations());
            Operations[1].count = 0;
            for (int i = 2; i <= number; i++)
            {
                Operations.Add(i, new Operations());

                int min1 = Operations[i - 1].count;

                int min2 = Int32.MaxValue;
                int min3 = Int32.MaxValue;
                if (i % 2 == 0)
                {
                    min2 = Operations[i / 2].count;
                    
                }

                if (i % 3 == 0)
                {
                    min3 = Operations[i / 3].count;
                }

                int min = Math.Min(min1, Math.Min(min2, min3));
                if (min == min1)
                {
                    Operations[i].Intermediates = Operations[i - 1].Intermediates.ToList();
                }

                else if(min == min2)
                {
                    Operations[i].Intermediates = Operations[i / 2].Intermediates.ToList();
                }

                else if(min == min3)
                {
                    Operations[i].Intermediates = Operations[i / 3].Intermediates.ToList();
                }

                Operations[i].count = min + 1;
                Operations[i].Intermediates.Add(i);
            }

            return Operations[number].Intermediates;
        }

        static void Main(string[] args)
        {
            int number = Int32.Parse(Console.ReadLine());
            List<int> operations = GetNumberOfOperations(number);

            Console.WriteLine(operations.Count);
            Console.Write("1 ");
            for (int i = 0; i < operations.Count; i++)
            {
                Console.Write(operations[i] + "  ");
            }
        }
    }
}
