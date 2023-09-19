using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            //string bookName = Console.ReadLine();
            //int booksQuantity = 0;

            //while (true)
            //{
            //    string searchBook = Console.ReadLine();

            //    if (searchBook == "No More Books")
            //    {
            //        Console.WriteLine($"The book you search is not here!");
            //        Console.WriteLine($"You checked {booksQuantity} books.");
            //        break;
            //    }
            //    else if (searchBook == bookName)
            //    {
            //        Console.WriteLine($"You checked {booksQuantity} books and found it.");
            //        break;
            //    }
            //    booksQuantity++;
            //}


            string bookName = Console.ReadLine();
            string searchBook = "";
            int booksQuantity = 0;
            bool isBookFound = false;

            while ((searchBook = Console.ReadLine()) != "No More Books")
            {
                if (searchBook == bookName)
                {
                    isBookFound = true;
                    break;
                }
                                
                booksQuantity++;
                
            }

            if (isBookFound)
            {
                Console.WriteLine($"You checked {booksQuantity} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {booksQuantity} books.");

            }



        }
    }
}

