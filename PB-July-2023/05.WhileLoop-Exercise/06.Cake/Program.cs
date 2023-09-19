using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {

            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int piecesLeft = width * lenght;

            string input = Console.ReadLine();
            while (input != "STOP")
            {
                int pcsToTake = int.Parse(input);
                piecesLeft -= pcsToTake;
                if (piecesLeft <= 0)
                {
                    break;
                }
                input = Console.ReadLine();

            }

            if (piecesLeft > 0)
            {
                Console.WriteLine($"{piecesLeft} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {-1 * piecesLeft} pieces more.");

            }

        }
    }
}

