/*
4
1 5
9 10
31 81
41 20
*/

int n = int.Parse(Console.ReadLine());
bool isFirstArrSelected = true; 
string[] firstArr = new string[n];
string[] secondArr = new string[n];

for (int i = 0; i < n; i++)
{
    //int[] numbersArray = Console.ReadLine()
    //    .Split()
    //    .Select(int.Parse)
    //    .ToArray();
    string number = Console.ReadLine();
    // "1 5"
    string[] numbersArray = number.Split();
    //    0    1       1     0
    // [ "1", "5" ] [ "9", "10" ]

    //if (i % 2 != 0) това в с четно и нечетно
    if (isFirstArrSelected)
    {
    // is true isFirstArrSelected
    firstArr[i] = numbersArray[0];
    secondArr[i] = numbersArray[1];
    }
    else
    {
    // els isFirstArrSelected = false
    firstArr[i] = numbersArray[1];
    secondArr[i] = numbersArray[0]; 
    }

    // това върти тру и фалс на всяка интерация
    isFirstArrSelected = !isFirstArrSelected;
}

Console.WriteLine(string.Join(" ", firstArr));
Console.WriteLine(string.Join(" ", secondArr));



int n = int.Parse(Console.ReadLine());

string[] arr = new string[n*2];

for (int i = 0; i < n; i += 2)
{
    string[] number = Console.ReadLine().Split();

    if (i % 2 == 0) 
    {
        arr[i] = number[0];
        arr[i+1] = number[1];
    }
    else
    {
        arr[i] = number[1];
        arr[i + 1] = number[0];
    }
}

for (int i = 0; i < arr; i+= 2)
{
    Console.WriteLine(arr[i]);
}


