/*
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
*/

namespace _3.MaximalSum_ET;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();



        int rows = input[0];
        int cols = input[1];

        //Console.WriteLine("Please input col and row for squear separated by comma and space");
        //int[] squareInput = Console.ReadLine()
        //.Split(", ")
        //.Select(int.Parse)
        //.ToArray();

        int sqRows = 3;
        int sqCols = 3;

        //if (sqRows > rows || sqCols > cols)
        //{
        //    Console.WriteLine("Invalid square input!");
        //    return;
        //}

        int[,] matrix = ReadMatrix(rows, cols, " ");

        int maxSquareSum = matrix[0, 0];
        int maxSquareRow = 0;
        int maxSquareCol = 0;

        for (int row = 0; row < rows - (sqRows - 1); row++)
        {
            for (int col = 0; col < cols - (sqCols - 1); col++)
            {
                int squareSum = 0;

                for (int srow = 0; srow < sqRows; srow++)
                {
                    for (int scol = 0; scol < sqCols; scol++)
                    {
                        squareSum += matrix[row + srow, col + scol];
                    }
                }

                if (squareSum > maxSquareSum)
                {
                    maxSquareRow = row;
                    maxSquareCol = col;
                    maxSquareSum = squareSum;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSquareSum}");

        for (int r = 0; r < sqRows; r++)
        {
            for (int c = 0; c < sqCols; c++)
            {
                Console.Write($"{matrix[maxSquareRow + r, maxSquareCol + c]} ");
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
            int[] rowArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowArray[col];
            }
        }
        return matrix;


    }
}

