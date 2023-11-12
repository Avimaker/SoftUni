/*
Programming is cool!
*/

using System.Text;

namespace _04.CaesarCipher;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        StringBuilder pass = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char originalChar = input[i];
            int tempChar = originalChar + 3;
            char passChar = Convert.ToChar(tempChar);
            //char passChar = (char)tempChar;

            pass.Append(passChar);

        }

        Console.WriteLine(pass);
    }
}

