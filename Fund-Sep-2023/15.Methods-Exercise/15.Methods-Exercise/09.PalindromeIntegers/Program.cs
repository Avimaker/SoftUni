/*
123
323
421
121
END
*/


//using System;

//namespace _09.PalindromeIntegers
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string input = "";

//            while ((input = Console.ReadLine()) != "END")
//            {
//                bool isNumberPalindrome = IsPalindrome(input);
//                Console.WriteLine(isNumberPalindrome);
//            }

//            static bool IsPalindrome(string symbols)
//            {
//                int left = 0;
//                int right = symbols.Length - 1;

//                while (left < right)
//                {
//                    if (symbols[left] != symbols[right])
//                    {
//                        return false;
//                    }

//                    left++;
//                    right--;

//                }

//                return true;
//            }
//        }
//    }
//}



using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                bool isNumberPalindrome = IsPalindrome(input);
                Console.WriteLine(isNumberPalindrome);
            }

            static bool IsPalindrome(string symbols)
            {
                string first = symbols.Substring(0, symbols.Length / 2);
                char[] arr = symbols.ToCharArray();

                Array.Reverse(arr);

                string temp = new string(arr);
                string second = temp.Substring(0, symbols.Length / 2);

                return first.Equals(second);

            }
        }
    }
}