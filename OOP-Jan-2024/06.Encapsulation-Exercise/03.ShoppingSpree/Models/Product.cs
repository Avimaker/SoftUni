﻿namespace ShoppingSpree.Models
{
	public class Product
	{
		private string name;
		private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
		{
			get => this.name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");	
				}
				this.name = value;
			}
		}

		public decimal Cost
		{
			get => this.cost;
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
				this.cost = value;
			}
		}


	}
}

