using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyChangeDP
{
    class Program
    {
        public class ChangeValue
        {
            public int count;
            public List<int> Denominations;

            public ChangeValue()
            {
                count = Int32.MaxValue;
                Denominations = new List<int>();
            }
        }
        private static List<int> GetChange(int moneyValue, List<int> coins)
        {
            Dictionary<int, ChangeValue> denominations = new Dictionary<int, ChangeValue>();
            for (int i = 0; i <= moneyValue; i++)
            {
                denominations.Add(i, new ChangeValue());

                for (int j = 0; j < coins.Count; j++)
                {
                    if (coins[j] <= i)
                    {
                        var numCoins = denominations[i - coins[j]].count + 1;
                        if (numCoins < denominations[i].count)
                        {
                            denominations[i].count = numCoins;
                            denominations[i].Denominations = denominations[i - coins[j]].Denominations.ToList();
                            denominations[i].Denominations.Add(coins[j]);
                        }
                    }
                }
            }

            return denominations[moneyValue].Denominations;
        }

        static void Main(string[] args)
        {
            int moneyValue = Int32.Parse(Console.ReadLine());
            List<int> coins = new List<int>() { 1, 3, 4 };
            List<int> denominations = GetChange(moneyValue, coins);
           
            Console.WriteLine(denominations.Count);
            Console.Write(moneyValue + " = ");
            for (int i = 0; i < denominations.Count - 1; i++)
            {
                Console.Write(denominations[i] + " + ");
            }

            Console.Write(denominations.Last());
        }


    }
}
