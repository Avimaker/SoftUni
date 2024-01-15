/*
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
*/

namespace _3.MaximalSum;

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

        int[,] matrix = ReadMatrix(rows, cols, ", ");

        //Print Matrix
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }

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

