
int n = int.Parse(Console.ReadLine());

int[] masiv = new int[n];

for (int i = 0; i < n; i++)
{
int currentNumber = int.Parse(Console.ReadLine());
    masiv[i] = currentNumber;
}

for (int i = masiv.Length - 1; i >= 0; i--)
{
    Console.Write(masiv[i] + " ");
}

