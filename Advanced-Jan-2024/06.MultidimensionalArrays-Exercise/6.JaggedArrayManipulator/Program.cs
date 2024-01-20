/*
5
10 20 30
1 2 3
2
2
10 10
End

5
10 20 30
1 2 3
2
2
10 10
Add 0 10 10
Add 0 0 10
Subtract -3 0 10
Subtract 3 0 10
End

*/

namespace _6.JaggedArrayManipulator;

class Program
{
    static void Main(string[] args)
    {
        int rowsCount = int.Parse(Console.ReadLine());
        int[][] jagged = ReadJagMatrix(rowsCount, " ");
        int[][] jaggedChecked = new int[jagged.Length][];

        for (int row = 0; row < jagged.Length - 1; row++)
        {
            if (jagged[row].Length == jagged[row + 1].Length)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] *= 2;
                    jagged[row + 1][col] *= 2;
                }
            }
            else
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] /= 2;
                }
                for (int col = 0; col < jagged[row + 1].Length; col++)
                {
                    jagged[row + 1][col] /= 2;
                }

            }
        }


        string command = default;
        while ((command = Console.ReadLine().ToLower()) != "end")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);

            if (ValidateCell(row, col, jagged))
            {
                if (action == "add")
                {
                    jagged[row][col] += value;
                }
                else
                {
                    jagged[row][col] -= value;
                }
            }
        }


        //Print Matrix
        for (int row = 0; row < jagged.Length; row++)
        {
            for (int col = 0; col < jagged[row].Length; col++)
            {
                Console.Write($"{jagged[row][col]} ");
            }
            Console.WriteLine();
        }

    }

    //Read Jagged Matrix Method
    private static int[][] ReadJagMatrix(int rowsCount, string separator)
    {
        int[][] jagged = new int[rowsCount][];

        for (int row = 0; row < jagged.Length; row++)
        {
            string[] nums = Console.ReadLine().Split(separator);
            jagged[row] = new int[nums.Length];

            for (int col = 0; col < jagged[row].Length; col++)
            {
                jagged[row][col] = int.Parse(nums[col]);
            }
        }
        return jagged;


    }

    //check isValid
    static bool ValidateCell(int row, int col, int[][] jaggedArray)
    {
        return
            row >= 0
            && row < jaggedArray.Length
            && col >= 0
            && col < jaggedArray[row].Length;
    }

    //check isValid matrix
    //static bool ValidateCell(int row, int col, int size)
    //{
    //    return
    //        row >= 0
    //        && row < size
    //        && col >= 0
    //        && col < size;
    //}

    
}

