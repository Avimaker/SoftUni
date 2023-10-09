using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {

            char letterOne = char.Parse(Console.ReadLine());
            char letterTwo = char.Parse(Console.ReadLine());

            int letterOneValue = (int)letterOne;
            int letterTwoValue = (int)letterTwo;

            int letterOneCounter = 0;
            int letterTwoCounter = 0;

            letterOneCounter = NormalPrint(letterOneValue, letterTwoValue, letterOneCounter);

            letterTwoCounter = SwappedPrint(letterOneValue, letterTwoValue, letterTwoCounter);

        }

        private static int NormalPrint(int letterOneValue, int letterTwoValue, int letterOneCounter)
        {
            if (letterOneValue < letterTwoValue)
            {
                letterOneCounter = letterOneValue;
                for (int i = letterOneValue + 1; i < letterTwoValue; i++)
                {
                    char currentChar = (char)(letterOneCounter + 1);
                    Console.Write($"{currentChar} ");
                    letterOneCounter++;
                }
            }

            return letterOneCounter;
        }

        private static int SwappedPrint(int letterOneValue, int letterTwoValue, int letterTwoCounter)
        {
            if (letterOneValue > letterTwoValue)
            {
                // This is for print in reverse order
                //letterTwoCounter = letterOneValue;
                //for (int i = letterOneValue - 1; i > letterTwoValue; i--)
                //{
                //    char currentChar = (char)(letterTwoCounter - 1);
                //    Console.Write($"{currentChar} ");
                //    letterTwoCounter--;
                //}

                int reverseNum = (letterOneValue - letterTwoValue);
                string[] reverse = new string[reverseNum - 1];
                int arrCounter = 0;

                letterTwoCounter = letterOneValue;
                for (int i = letterOneValue - 1; i > letterTwoValue; i--)
                {
                    char currentChar = (char)(letterTwoCounter - 1);
                    reverse[arrCounter] = currentChar.ToString();
                    letterTwoCounter--;
                    arrCounter++;
                }

                for (int i = arrCounter - 1; i >= 0; i--)
                {
                    Console.Write($"{reverse[i]} ");
                }
            }

            return letterTwoCounter;
        }
    }
}






//using System;

//namespace _03.CharactersInRange
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            char letterOne = char.Parse(Console.ReadLine());
//            char letterTwo = char.Parse(Console.ReadLine());

//            int letterOneValue = (int)letterOne;
//            int letterTwoValue = (int)letterTwo;

//            int letterOneCounter = 0;
//            int letterTwoCounter = 0;


//            if (letterOneValue < letterTwoValue)
//            {
//                letterOneCounter = letterOneValue;
//                for (int i = letterOneValue + 1; i < letterTwoValue; i++)
//                {
//                    char currentChar = (char)(letterOneCounter + 1);
//                    Console.Write($"{currentChar} ");
//                    letterOneCounter++;
//                }
//            }
//            else if (letterOneValue > letterTwoValue)
//            {
//                // This is for print in reverse order
//                //letterTwoCounter = letterOneValue;
//                //for (int i = letterOneValue - 1; i > letterTwoValue; i--)
//                //{
//                //    char currentChar = (char)(letterTwoCounter - 1);
//                //    Console.Write($"{currentChar} ");
//                //    letterTwoCounter--;
//                //}

//                int reverseNum = (letterOneValue - letterTwoValue);
//                string[] reverse = new string[reverseNum - 1];
//                int arrCounter = 0;

//                letterTwoCounter = letterOneValue;
//                for (int i = letterOneValue - 1; i > letterTwoValue; i--)
//                {
//                    char currentChar = (char)(letterTwoCounter - 1);
//                    reverse[arrCounter] = currentChar.ToString();
//                    letterTwoCounter--;
//                    arrCounter++;
//                }

//                for (int i = arrCounter - 1; i >= 0; i--)
//                {
//                    Console.Write($"{reverse[i]} ");
//                }
//            }

//        }
//    }
//}