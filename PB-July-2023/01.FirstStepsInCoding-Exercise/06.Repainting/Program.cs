using System;

namespace _06.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double nylon = double.Parse(Console.ReadLine());
            double paint = double.Parse(Console.ReadLine());
            double diluent = double.Parse(Console.ReadLine());
            int labourHours = int.Parse(Console.ReadLine());

            double nylonPrice = (nylon + 2) * 1.50;
            double paintPrice = (paint + (paint * 0.10)) * 14.50;
            double diluentPrice = diluent * 5.00;
            double totalProductPrice = nylonPrice + paintPrice + diluentPrice + 0.40;
            double labourHoursPrice = (totalProductPrice * 0.30) * labourHours;
            double totlaPrice = totalProductPrice + labourHoursPrice;


            Console.WriteLine(totlaPrice);
        }
    }
}

