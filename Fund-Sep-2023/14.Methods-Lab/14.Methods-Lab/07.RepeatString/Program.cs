using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            PrintPreparation(text, n);
            string Print = PrintPreparation(text, n);

            Console.WriteLine(Print);
        }

        static string PrintPreparation(string text, int n)
        {
            string result = "";

            for (int i = 0; i < n; i++)
            {
                result += text;
            }

            return result;
        }
    }
}

