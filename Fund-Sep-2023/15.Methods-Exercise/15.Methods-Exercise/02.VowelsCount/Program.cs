using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowelsCount = 0;

            vowelsCount = VovelCheck(input, vowelsCount);

            Console.WriteLine(vowelsCount);
        }

        private static int VovelCheck(string input, int vowelsCount)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char check = input[i];

                if (check == 'a' || check == 'A')
                {
                    vowelsCount++;
                }
                else if (check == 'e' || check == 'E')
                {
                    vowelsCount++;
                }
                else if (check == 'i' || check == 'I')
                {
                    vowelsCount++;
                }
                else if (check == 'o' || check == 'O')
                {
                    vowelsCount++;
                }
                else if (check == 'u' || check == 'U')
                {
                    vowelsCount++;
                }

            }

            return vowelsCount;
        }
    }
}


