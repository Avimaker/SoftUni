using System;

namespace _07.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenghth = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeVolume = width * lenghth * height;
            int usedVolum = 0;

            string input = Console.ReadLine();
            while (input != "Done")
            {
                int boxes = int.Parse(input);
                usedVolum += boxes;
                if (usedVolum > freeVolume)
                {
                    break;
                }
                input = Console.ReadLine();
            }

            if (freeVolume >= usedVolum)
            {
                Console.WriteLine($"{freeVolume - usedVolum} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {usedVolum - freeVolume} Cubic meters more.");
            }
        }
    }
}

