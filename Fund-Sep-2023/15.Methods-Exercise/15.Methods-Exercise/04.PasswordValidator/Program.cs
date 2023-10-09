using System;
using System.Text.RegularExpressions;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = true;
            string passInput = Console.ReadLine();

            int boolCounter = 0;

            isTrue = CharactersLength(passInput);
            if (!isTrue) { boolCounter++;}
            isTrue = CheckForSymbols(passInput);
            if (!isTrue) { boolCounter++; }
            isTrue = DigitCounter(passInput);
            if (!isTrue) { boolCounter++; }


            if (isTrue && boolCounter == 0)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CharactersLength(string passInput)
        {
            bool isTrue;
            if (passInput.Length < 6 || passInput.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isTrue = false;
                return isTrue;
            }
            isTrue = true;
            return isTrue;
        }

        static bool CheckForSymbols(string passInput)
        {
            bool isTrue;
            string forbiden = "^[a-zA-Z0-9]+$";

            if (!Regex.IsMatch(passInput, forbiden))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isTrue = false;
                return isTrue;

            }

            isTrue = true;
            return isTrue;
        }

        static bool DigitCounter(string passInput)
        {
            bool isTrue;

            int digitCounter = 0;
            for (int i = 0; i < passInput.Length; i++)
            {
                char check = passInput[i];
                if (check == '0' || check == '1' || check == '2'
                    || check == '3' || check == '4' || check == '5'
                    || check == '6' || check == '7' || check == '8'
                    || check == '9')
                {
                    digitCounter++;
                }
            }
            if (digitCounter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isTrue = false;
                return isTrue;
            }
            isTrue = true;
            return isTrue;
        }

    }
}

