using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double cpuPrice = double.Parse(Console.ReadLine()) * 1.57;
            double gpuPrice = double.Parse(Console.ReadLine()) * 1.57;
            double ramPrice = double.Parse(Console.ReadLine()) * 1.57;
            int ramQuantity = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double totalRam = ramPrice * ramQuantity;
            double totalCpu = cpuPrice - cpuPrice * discount;
            double totalGpu = gpuPrice - gpuPrice * discount;

            double totalPrice = totalCpu + totalGpu + totalRam;

            Console.WriteLine($"Money needed - {totalPrice:f2} leva.");

        }
    }
}

