using System;

namespace _04.Sequence2kPlus1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sume = 1;

            while (sume <= n)
            {
                Console.WriteLine(sume);
                sume = sume * 2 + 1;
            }
        }
    }
}

