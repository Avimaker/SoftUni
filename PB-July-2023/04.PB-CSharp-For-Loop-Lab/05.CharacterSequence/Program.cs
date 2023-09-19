using System;

namespace _05.CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = Console.ReadLine();
            //int textLenght = text.Length;

            //for (int i = 0; i < textLenght; i++)
            //{
            //    char letter = text[i];
            //    Console.WriteLine(letter);
            //}


            string text = Console.ReadLine();
            
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}

