/*
2 3
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END
*/

namespace _4.MatrixShuffling;

class Program
{
    static void Main(string[] args)
    {

        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int rows = size[0];
        int cols = size[1];

        string[,] matrix = ReadMatrix(rows, cols, " ");

        string command = default;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] arguments = command.Split();

            if (arguments[0] == "swap" && arguments.Length == 5)
            {
                int row1 = int.Parse(arguments[1]);
                int col1 = int.Parse(arguments[2]);
                int row2 = int.Parse(arguments[3]);
                int col2 = int.Parse(arguments[4]);

                if (IsValidSwap(matrix, row1, col1, row2, col2))
                {
                    string valueTemp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = valueTemp;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row,col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

        }

    }

    private static bool IsValidSwap(string[,] matrix, int row1, int col1, int row2, int col2)
    {
        return row1 >= 0 && row1 < matrix.GetLength(0)
            && col1 >= 0 && col1 < matrix.GetLength(1)
            && row2 >= 0 && row2 < matrix.GetLength(0)
            && col2 >= 0 && col2 < matrix.GetLength(1);
    }

    //Read Matrix Method
    private static string[,] ReadMatrix(int rows, int cols, string separator)
    {
        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] rowArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowArray[col];
            }
        }
        return matrix;



    }
}

