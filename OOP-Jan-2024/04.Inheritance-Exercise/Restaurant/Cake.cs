﻿using System;
namespace Restaurant
{
	public class Cake : Dessert
	{
		private const decimal CakePrice = 5M;
		private const double Calories = 1000;
		private const double Grams = 250;

		public Cake(string name) : base(name, CakePrice, Grams, Calories)
        {
		}
	}
}

