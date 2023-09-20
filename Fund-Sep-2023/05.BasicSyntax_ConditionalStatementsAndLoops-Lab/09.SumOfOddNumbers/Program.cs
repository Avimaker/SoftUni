int n = int.Parse(Console.ReadLine());
int sum = 0;
int digit = 0;

for (int i = 1; i <= n; i++)
{
    digit = i * 2 - 1;
    Console.WriteLine(digit);
    sum += digit;
}

Console.WriteLine($"Sum: {sum}");