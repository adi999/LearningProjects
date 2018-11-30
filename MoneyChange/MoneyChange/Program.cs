using System;

namespace MoneyChange
{
    class Program
    {
        public static int get_change(int moneyValue)
        {
            int minNumberOfRequiredCoins = 0;
            //int[] denominations = new int[] {1, 5, 10};
            
            while (moneyValue > 0)
            {
                if (moneyValue % 10 == 0)
                {
                    minNumberOfRequiredCoins += moneyValue / 10;
                    moneyValue = moneyValue % 10;
                }

                else
                {
                    minNumberOfRequiredCoins += moneyValue / 10;
                    moneyValue = moneyValue % 10;

                    if (moneyValue % 5 == 0)
                    {
                        minNumberOfRequiredCoins += moneyValue / 5;
                        moneyValue = moneyValue % 5;

                    }

                    else
                    {
                        minNumberOfRequiredCoins += moneyValue / 5 + moneyValue % 5;
                        moneyValue = 0;
                    }
                }
            }

            return minNumberOfRequiredCoins;
        }

        static void Main(string[] args)
        {
            int moneyValue = Int32.Parse(Console.ReadLine());
            Console.WriteLine(get_change(moneyValue));
        }
    }
}
