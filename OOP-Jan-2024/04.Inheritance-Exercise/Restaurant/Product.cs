using System;
namespace Restaurant
{
	public abstract class Product
	{
        private string name;
        private decimal price;

        protected Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
		public decimal Price { get; set; }

	}
}

