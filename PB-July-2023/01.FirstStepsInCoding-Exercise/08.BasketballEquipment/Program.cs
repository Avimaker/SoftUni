using System;

namespace _08.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearTax = int.Parse(Console.ReadLine());

            //double sportShoes = yearTax - (yearTax * 0.40);
            //double sportShoes = 1 * yearTax - 0.4 * yearTax = (1-0.4) * yearTax = 0.6 * yearTax;
            double sportShoes = (1-0.4) * yearTax;
            double sportDress = sportShoes - (sportShoes * 0.20); // 0.8 * sportShoes;
            double sportBall = sportDress * 0.25;
            //double sportAccs = sportBall / 5.0;
            double sportAccs = (1.0 / 5) * sportBall;

            double totalPrice = yearTax + sportShoes + sportDress + sportBall + sportAccs;

            Console.WriteLine(totalPrice);
        }
    }
}

