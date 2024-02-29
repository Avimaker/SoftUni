using System;
namespace FoodShortage.Models.Interfaces
{
	public interface IBuy : IName
	{
		int Food { get; }
		void BuyFood();
	}
}

