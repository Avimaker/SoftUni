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

        public int GetCount => this.Drinks.Count();

        public void AddDrink(Drink drink)
        {
            if (ButtonCapacity > Drinks.Count)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name) => this.Drinks.Remove(this.Drinks.FirstOrDefault(d => d.Name == name));

        public Drink GetLongest()
        {
            Drink drink = this.Drinks.OrderByDescending(d => d.Volume).FirstOrDefault();
            return drink;
        }

        public Drink GetCheapest()
        {
            Drink drink = this.Drinks.OrderBy(d => d.Price).FirstOrDefault();
            return drink;
        }

        public string BuyDrink(string name)
        {
            Drink drink = this.Drinks.FirstOrDefault(d => d.Name == name);
            return drink.ToString().TrimEnd();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drinks available:");

            foreach (Drink drink in Drinks) { sb.AppendLine(drink.ToString()); }
            return sb.ToString().TrimEnd();
        }
    }
}
