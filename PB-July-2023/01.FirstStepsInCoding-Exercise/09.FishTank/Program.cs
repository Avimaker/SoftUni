using System;

namespace _09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double procent = double.Parse(Console.ReadLine())*0.01;

            double aquariumVolume = length * width * height;
            double waterVolume = aquariumVolume * 0.001;

            double water = waterVolume * (1 - procent);

            Console.WriteLine(water);
        }
    }
}

