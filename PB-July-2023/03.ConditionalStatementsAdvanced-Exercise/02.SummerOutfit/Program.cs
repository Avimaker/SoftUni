﻿using System;

namespace _02.SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degree = int.Parse(Console.ReadLine());
            string partOfTheDay = Console.ReadLine();

            string outfit = "";
            string shoes = "";

            if (degree >= 10 && degree <= 18)
            {
                if (partOfTheDay == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (partOfTheDay == "Afternoon" || partOfTheDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";

                }
            }

            else if (degree > 18 && degree <= 24)
            {
                if (partOfTheDay == "Morning" || partOfTheDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (partOfTheDay == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";

                }
            }

            else if (degree >= 25)
            {
                if (partOfTheDay == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (partOfTheDay == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";

                }
                else if (partOfTheDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";

                }
                               
            }

            Console.WriteLine($"It's {degree} degrees, get your {outfit} and {shoes}.");


        }
    }
}

