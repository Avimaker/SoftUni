/*
3
11 2 4
4 5 6
10 8 -12

*/

namespace _1.DiagonalDifference_FastWay;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        int diagonalSumOne = 0;
        int diagonalSumTwo = 0;

        for (int i = 0; i < size; i++)
        {
            int[] row = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            diagonalSumOne += row[i];
            diagonalSumTwo += row[size - 1 - i];
        }

        Console.WriteLine(Math.Abs(diagonalSumOne - diagonalSumTwo));
    }
}

