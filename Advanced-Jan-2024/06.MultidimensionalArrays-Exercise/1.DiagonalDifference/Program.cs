/*
3
11 2 4
4 5 6
10 8 -12

*/

namespace _1.DiagonalDifference;

class Program
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());

        int rows = input;
        int cols = input;

        int[,] matrix = ReadMatrix(rows, cols, " ");

        int diagonalSumOne = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            diagonalSumOne += matrix[row, row];
        }

        int diagonalSumTwo = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            diagonalSumTwo += matrix[row, input - 1 - row];
        }
        Console.WriteLine(Math.Abs(diagonalSumOne - diagonalSumTwo));
    }

    //Read Matrix Method
    private static int[,] ReadMatrix(int rows, int cols, string separator)
    {
        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] rowArray = Console.ReadLine().Split(separator).Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowArray[col];
            }
        }
        return matrix;
    }
}

