using System;

namespace _08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Моля въведете броя опаковки храна за куче");
            int dogFood = int.Parse(Console.ReadLine());
            //Console.WriteLine("Моля въведете броя опаковки храна за коте");
            int catFood = int.Parse(Console.ReadLine());

            double dogFoodPrice = dogFood * 2.5;
            double catFoodPrice = catFood * 4.0;

            double total = dogFoodPrice + catFoodPrice;

            Console.WriteLine($"{total} lv.");

        }
    }
}

