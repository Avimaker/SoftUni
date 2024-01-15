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
        int[] sizes = ReadIntArray();

        int rows = sizes[0];
        int cols = sizes[1];
        int[][] matrix = new int[rows][];

        for (int row = 0; row < rows; row++)
        {
            matrix[row] = ReadIntArray();
        }

        int maxSquareSum = 0;
        int maxSquareRow = 0;
        int maxSquareCol = 0;

        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                int currentSum = 0;

                for (int srow = 0; srow < 3; srow++)
                {
                    for (int scol = 0; scol < 3; scol++)
                    {
                        currentSum += matrix[row + srow][col + scol];
                    }
                }

                if (currentSum > maxSquareSum)
                {
                    maxSquareSum = currentSum;
                    maxSquareRow = row;
                    maxSquareCol = col;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSquareSum}");

        for (int r = maxSquareRow; r < maxSquareRow + 3; r++)
        {
            for (int c = maxSquareCol; c < maxSquareCol + 3; c++)
            {
                Console.Write($"{matrix[r][c]} ");
            }
            Console.WriteLine();
        }


    }

    private static int[] ReadIntArray()
    {
        return Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }

   
}

