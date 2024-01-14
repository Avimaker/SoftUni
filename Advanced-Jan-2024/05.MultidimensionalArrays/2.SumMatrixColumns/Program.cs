/*
3, 6
7 1 3 3 2 1
1 3 9 8 5 6
4 6 7 9 1 0
*/

namespace _2.SumMatrixColumns;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        int rows = input[0];
        int cols = input[1];

        int colSum = 0;

        int[,] matrix = ReadMatrix(rows, cols, " ");

        //sum
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                colSum += matrix[row, col];
            }
            Console.WriteLine(colSum);
            colSum = 0;
        }

    }

    
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


