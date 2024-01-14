/*
3, 6
7, 1, 3, 3, 2, 1
1, 3, 9, 8, 5, 6
4, 6, 7, 9, 1, 0
*/

namespace _5.SquareWithMaximumSum;

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

        int maxSquareSum = matrix[0, 0];
        int maxSquareRow = 0;
        int maxSquareCol = 0;

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                int squareSum = matrix[row, col] + matrix[row, col + 1]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1];

                if (squareSum > maxSquareSum)
                {
                    maxSquareRow = row;
                    maxSquareCol = col;
                    maxSquareSum = squareSum;
                }
            }
        }
         

        Console.WriteLine($"{matrix[maxSquareRow, maxSquareCol]} {matrix[maxSquareRow, maxSquareCol + 1]}");
        Console.WriteLine($"{matrix[maxSquareRow + 1, maxSquareCol]} {matrix[maxSquareRow + 1, maxSquareCol + 1]}");
        Console.WriteLine(maxSquareSum);



        //Print Matrix
        //for (int row = 0; row < matrix.GetLength(0); row++)
        //{
        //    for (int col = 0; col < matrix.GetLength(1); col++)
        //    {
        //        Console.Write($"{matrix[row, col]} ");
        //    }
        //    Console.WriteLine();
        //}

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

