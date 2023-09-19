using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacantionMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());

            int daysCount = 0;
            int spendDaysCount = 0;


            while (ownedMoney < vacantionMoney && spendDaysCount < 5)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                daysCount++;

                if (command == "save")
                {
                    ownedMoney += money;
                    spendDaysCount = 0;
                }

                else if (command == "spend")
                {
                    ownedMoney -= money;
                    spendDaysCount ++;
                    if (ownedMoney <= 0)
                    {
                        ownedMoney = 0;
                    }
                }

            }
            if (spendDaysCount==5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCount);
            }

            if (ownedMoney >= vacantionMoney)
            {
                Console.WriteLine($"You saved the money for {daysCount} days.");
            }

        }
    }
}

