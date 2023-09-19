using System;

namespace _07.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            double chickenMenu = double.Parse(Console.ReadLine())*10.35;
            double fishMenu = double.Parse(Console.ReadLine())*12.40;
            double veganMenu = double.Parse(Console.ReadLine())*8.15;

            double menuPrice = chickenMenu + fishMenu + veganMenu;

            double desertPrice = menuPrice * 0.20;
            
            double totalPrice = menuPrice + desertPrice + 2.50;

            Console.WriteLine(totalPrice);
        }
    }
}

