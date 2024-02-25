using System;
namespace Restaurant
{
	public abstract class Dessert : Food
	{
		private double calories;

		public Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
        {
			Calories = Calories;
		}

		public double Calories { get; set; }

	}
}

