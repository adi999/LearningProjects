using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FractionalKnapsack
{
    class Program
    {
        public class KnapsackItem
        {
            public int Weight;
            public int Value;
            public double ValueUnitWeight;

            public KnapsackItem(int weight, int value)
            {
                this.Weight = weight;
                this.Value = value;
                this.ValueUnitWeight = (double)this.Value / this.Weight;
            }
        }


        public static double get_optimal_value(int capacity, List<int> weights, List<int> values)
        {
            double value = 0.0;
            List<KnapsackItem> knapsackItems = new List<KnapsackItem>();

            for (int i = 0; i < weights.Count; i++)
            {
                knapsackItems.Add(new KnapsackItem(weights[i], values[i]));
            }

            knapsackItems.Sort(new Comparison<KnapsackItem>((x,y) => -1*x.ValueUnitWeight.CompareTo(y.ValueUnitWeight)));

            for (int i = 0; i < knapsackItems.Count; i++)
            {
                if (capacity == 0)
                {
                    break;
                }
                int weightOfItemUsed = Math.Min(capacity, knapsackItems[i].Weight);
                value += weightOfItemUsed * knapsackItems[i].ValueUnitWeight;
                capacity -= weightOfItemUsed;
            }

            return value;
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            int n = Int32.Parse(tokens[0]);
            int capacity = Int32.Parse(tokens[1]);
            List<int> values = new List<int>();
            List<int> weights = new List<int>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                tokens = input.Split(' ');
                values.Add(Int32.Parse(tokens[0]));
                weights.Add(Int32.Parse(tokens[1]));
            }

            double optimalKnapsackValue = get_optimal_value(capacity, weights, values);

            Console.WriteLine(optimalKnapsackValue);
        }
    }
}
