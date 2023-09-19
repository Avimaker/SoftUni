using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int period = int.Parse(Console.ReadLine());
            double ylp = double.Parse(Console.ReadLine());

            double lihva = deposit * ylp * 0.01;
            double lihvaOneM = lihva / 12;
            double totalSume = deposit + period * lihvaOneM;

            Console.WriteLine(totalSume);
        }
    }
}

