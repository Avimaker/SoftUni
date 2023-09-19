using System;

namespace _01.ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {

            int bitcoin = int.Parse(Console.ReadLine());
            double yoan = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine()) * 0.01;

            int bitcoinPrice = 1168 * bitcoin;
            double chy2usd = yoan * 0.15;
            double usd2Bgn = chy2usd * 1.76;
            double eur2Bgn = 1.95;


            double leva = bitcoinPrice + usd2Bgn;
            double euro = leva / eur2Bgn;
            double takedCommision = euro * commission;

            Console.WriteLine($"{euro-takedCommision:f2}");


        }
    }
}

