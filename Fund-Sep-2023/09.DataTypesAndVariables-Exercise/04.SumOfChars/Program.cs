/*
5
A
b
C
d
E
*/

//Input
int numOfInputLines = int.Parse(Console.ReadLine());
int totalSum = 0;

//Operations
for (int i = 1; i <= numOfInputLines; i++)
{
    char letter = char.Parse(Console.ReadLine());

    totalSum += letter;
}


//Output
Console.WriteLine($"The sum equals: {totalSum}");        