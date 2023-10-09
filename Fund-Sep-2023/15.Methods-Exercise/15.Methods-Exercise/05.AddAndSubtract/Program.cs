using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int digitOne = int.Parse(Console.ReadLine());
            int digitTwo = int.Parse(Console.ReadLine());
            int digitThree = int.Parse(Console.ReadLine());

            int firstTwoSume = FirstSume(digitOne, digitTwo);
            int result = TotalSume(firstTwoSume, digitThree);

            Console.WriteLine(result);

        }

        static int FirstSume(int digitOne, int digitTwo)
        {
            return digitOne + digitTwo;
        }

        static int TotalSume(int firstTwoSume, int digitThree)
        {
            return firstTwoSume - digitThree;
        }
    }
}

