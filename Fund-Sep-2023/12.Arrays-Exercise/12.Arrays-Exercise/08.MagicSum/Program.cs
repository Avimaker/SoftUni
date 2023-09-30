/*
1 7 6 2 19 23
8

14 20 60 13 7 19 8
27
 
*/

//Input

int[] arrayNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
int searchedSum = int.Parse(Console.ReadLine());
int currentSym = 0;

for (int i = 0; i < arrayNums.Length; i++) //първа цифра от масива
{
    for (int j = i + 1; j < arrayNums.Length; j++) //втора цифра от масива
    {
        currentSym = arrayNums[i] + arrayNums[j]; //събираме двете цифри

        if (currentSym == searchedSum) //сравняваме с търсената сума
        {
            Console.WriteLine($"{arrayNums[i]} {arrayNums[j]}");
        }
    }
}

