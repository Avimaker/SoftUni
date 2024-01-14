/*
3, 6
2, 2
7, 1, 3, 3, 2, 1
1, 3, 9, 8, 5, 6
4, 6, 7, 9, 1, 0

9 8
7 9
33

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

        //Console.WriteLine("Please input col and row for squear separated by comma and space");
        int[] squareInput = Console.ReadLine()
        .Split(", ")
        .Select(int.Parse)
        .ToArray();

        int sqRows = squareInput[0];
        int sqCols = squareInput[1];

        if (sqRows >= rows || sqCols >= cols)
        {
            Console.WriteLine("Invalid square input!");
            return;
        }

        int[,] matrix = ReadMatrix(rows, cols, ", ");

        int maxSquareSum = matrix[0, 0];
        int maxSquareRow = 0;
        int maxSquareCol = 0;

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - sqCols; col++)
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

        for (int r = 0 ; r < sqRows; r++)
        {
            for (int c = 0; c < sqCols; c++)
            {
                Console.Write($"{matrix[maxSquareRow + r, maxSquareCol + c]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine(maxSquareSum);

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

