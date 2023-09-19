using System;

namespace _04.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int juriesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < juriesCount && points <= 1250.5; i++)
            {
                string nameOfJury = Console.ReadLine();
                double score = double.Parse(Console.ReadLine());

                points += nameOfJury.Length * score / 2;
            }

            if (points > 1250.5)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {points:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - points:f1} more!");
            }

        }
    }
}

