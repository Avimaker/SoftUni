using System;
using System.Drawing;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail

    {
        private string name;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        //prop
        public string Name
        {
            get { return this.name; }
            //get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                this.name = value;
            }
        }

        //prop
        public string Size { get; private set; }

        //prop
        public double Price
        {
            get { return this.price; }
            //get => price;
            private set
            {
                if (Size == "Large")
                {
                    price = value;
                }
                else if (Size == "Middle")
                {
                    price = 2.0 / 3 * value;
                }
                else if (Size == "Small")
                {
                    price = 1.0 / 3 * value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }

    }
}

