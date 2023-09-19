using System;

namespace _05.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int himikalki = int.Parse(Console.ReadLine());
            int markeri = int.Parse(Console.ReadLine());
            int preparat = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine()) * 0.01;


            //double penPrice = himikalki * 5.80;
            //double markerPrice = markeri * 7.20;
            //double preparatPrice = preparat * 1.20;

            //double totalPrice = penPrice + markerPrice + preparatPrice;

            double totalPrice = himikalki * 5.80 + markeri * 7.20 + preparat * 1.2;

            double discountPrice = totalPrice - totalPrice * discount;


            Console.WriteLine(discountPrice);
        }
    }
}

