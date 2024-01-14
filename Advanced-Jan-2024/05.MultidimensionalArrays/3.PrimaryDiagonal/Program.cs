/*
3
11 2 4
4 5 6
10 8 -12
*/

namespace _3.PrimaryDiagonal;

class Program
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());

        int rows = input;
        int cols = input;

        int[,] matrix = ReadMatrix(rows, cols, " ");

        int diagonalSum = 0;

        //Print
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            diagonalSum += matrix[row, row];
        }
        Console.WriteLine(diagonalSum);

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


