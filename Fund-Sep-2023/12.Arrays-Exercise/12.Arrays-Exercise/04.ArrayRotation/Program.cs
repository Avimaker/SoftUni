/* 
51 47 32 61 21
2 
 */


string[] array = Console.ReadLine().Split().ToArray();
int rotations = int.Parse(Console.ReadLine());

int arrayLenght = array.Length;

for (int i = 0; i < rotations; i++)
{
    string firstDigit = array[0];

    for (int k = 0;  k < arrayLenght - 1;  k++)
    {
        array[k] = array[k + 1];
    }

    array[arrayLenght - 1] = firstDigit;
}

Console.WriteLine(String.Join(" ", array));
