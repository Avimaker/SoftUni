/*
Like-Krisi-shrimps
Like-Krisi-soup
Like-Penelope-dessert
Like-Misho-salad
Stop

Like-Krisi-shrimps
Dislike-Vili-carp
Dislike-Krisi-salad
Stop

Like-Katy-fish
Dislike-Katy-fish
Stop

 
*/

using System.Numerics;

namespace _23.Zadacha03;

class Menu
{
    public Menu(string name)
    {
        Name = name;
        MealList = new List<string>();  //mealList
    }

    public string Name { get; set; }
    public List<string> MealList { get; set; } //MealList
    public int UnlikedCount { get; set; }

    public void AddMeal(string meal)
    {
        if (!MealList.Contains(meal))
        {
            MealList.Add(meal);
        }
    }

    public void RemoveMeal(string meal)
    {
        if (MealList.Contains(meal))
        {
            MealList.Remove(meal);
        }
    }

}

class Program
{
    static void Main(string[] args)
    {

        Dictionary<string, Menu> guestList = new Dictionary<string, Menu>();

        int unlikedMeals = 0;

        string command = default;
        while ((command = Console.ReadLine()) != "Stop")
        {
            string[] arguments = command.Split("-");

            if (arguments[0] == "Like")
            {
                string guestName = arguments[1];
                string meal = arguments[2];

                if (!guestList.ContainsKey(guestName))
                {
                    Menu guest = new Menu(guestName);
                    guestList.Add(guestName, guest);
                    guestList[guestName].AddMeal(meal);
                }

                if (!guestList.Keys.Contains(meal))
                {
                    guestList[guestName].AddMeal(meal);
                }
            }

            else if (arguments[0] == "Dislike")
            {
                string guestName = arguments[1]; // guest
                string meal = arguments[2]; // meal

                if (guestList.ContainsKey(guestName))
                {
                    if (guestList[guestName].MealList.Contains(meal))
                    {
                        guestList[guestName].RemoveMeal(meal);
                        Console.WriteLine($"{guestName} doesn't like the {meal}.");
                        //guestList[guestName].UnlikedCount++;
                        unlikedMeals++;
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                    }
                }

                else if (!guestList.ContainsKey(guestName))
                {
                    Console.WriteLine($"{guestName} is not at the party.");
                }
            }
        }

        foreach (var guest in guestList)
        {
            string meals = "";

            for (int i = 0; i < guest.Value.MealList.Count; i++)
            {
                meals += $"{guest.Value.MealList[i]}";

                if (i < guest.Value.MealList.Count - 1)
                {
                    meals += ", ";
                }
                
            }

            Console.WriteLine($"{guest.Key}: {meals}");
            //Console.Write($"{guest.Value.MealList}, ");

        }
        Console.WriteLine($"Unliked meals: {unlikedMeals}");
    }
}

