int lostGamesCount = int.Parse(Console.ReadLine());
double headsetPrice = double.Parse(Console.ReadLine());
double mousePrice = double.Parse(Console.ReadLine());
double keyboardPrice = double.Parse(Console.ReadLine());
double displayPrice = double.Parse(Console.ReadLine());

double totalExpenses = 0;

for (int game = 1; game <= lostGamesCount; game++)
{
	if (game % 2 == 0)
	{
		totalExpenses += headsetPrice;
	}

	if (game % 3 == 0)
	{
		totalExpenses += mousePrice;
	}

	if (game % 6 == 0)
	{
		totalExpenses += keyboardPrice;
		if (game % 12 == 0)
		{
			totalExpenses += displayPrice;
		}
	}
}

Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");