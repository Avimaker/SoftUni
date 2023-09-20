int n = int.Parse(Console.ReadLine());

int digi = 1;

for (int i = 1; i <= n; i++)
{

	// Print numbers in ascending order
	for (int k = 1; k <= i; k++)
	{
		Console.Write(digi);
		Console.Write(" ");
	}

	Console.WriteLine();
	digi++;
}