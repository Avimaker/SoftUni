using System;
namespace Restaurant
{
	public abstract class ColdBeverages : Beverage
	{
		public ColdBeverages(string name, decimal price, double milliliters)
        : base(name, price, milliliters)
        {
		}
	}
}

