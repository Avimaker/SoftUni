using System;

namespace _04.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int money = 0;
            int giftedMoney = 10;
            int toys = 0;
            int brother = 0;


            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                  money += giftedMoney;
                    giftedMoney += 10;
                    brother++;
                }
                if (i % 2 != 0)
                {
                    toys++;
                }
            }

            double toysSold = toyPrice * toys;
            double savings = (toysSold + money) - brother;

            if (savings >= washPrice)
            {
                Console.WriteLine($"Yes! {savings - washPrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washPrice - savings:f2}");
            }
        }
    }
}

