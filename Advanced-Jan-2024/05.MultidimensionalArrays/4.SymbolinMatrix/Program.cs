/*
3
ABC
DEF
X!@
!

4
asdd
xczc
qwee
qefw
4

*/

namespace _4.SymbolinMatrix;

class Program
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());

        int rows = input;
        int cols = input;

        string[,] matrix = ReadMatrix(rows, cols, "");

        string searchChar = Console.ReadLine();
        bool found = false;

        //Print Matrix
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                //Console.Write($"{matrix[row, col]}");
                if (matrix[row, col] == searchChar)
                {
                    found = true;
                    Console.WriteLine($"({row}, {col})");
                    break;
                }
            }
        }

        if (!found)
        {
            if (searchChar == "")
            {
                return;
            }

            Console.WriteLine($"{searchChar} does not occur in the matrix");
        }

    }

    //Read Matrix Method
    private static string[,] ReadMatrix(int rows, int cols, string separator)
    {
        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] rowArray = Console.ReadLine().ToCharArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = (rowArray[col]).ToString();
            }
        }
        return matrix;


    }
}

