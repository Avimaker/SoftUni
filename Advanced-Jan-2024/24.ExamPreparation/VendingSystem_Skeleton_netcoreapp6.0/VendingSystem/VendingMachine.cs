using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount => Drinks.Count;


        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity == Drinks.Count)
            {
                return;
            }
            Drinks.Add(drink);
        }

        public bool RemoveDrink(string name)
        {
            Drink foundedDrinks = Drinks.FirstOrDefault(n => n.Name == name);

            if (foundedDrinks == null)
            {
                return false;
            }
            else
            {
                Drinks.Remove(foundedDrinks);
                return true;
            }
        }

        public Drink GetLongest()
        {
            Drink drink = Drinks.OrderByDescending(l => l.Volume).First();

            //return shark.Length.ToString();
            return drink;
        }

        public Drink GetCheapest()
        {
            Drink drink = Drinks.OrderBy(l => l.Price).First();

            //return shark.Length.ToString();
            return drink;
        }

        public string BuyDrink(string name)
        {
            Drink drink = Drinks.FirstOrDefault(d => d.Name == name);

            return drink.ToString();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drinks available:");

            foreach (var drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
