//using System;
//namespace _02.FishingCompetition
//{
//	public class UsefullThings
//	{
//		public UsefullThings()
//		{
//		}
//	}
//}

//class Program6
//{
//    static void Main(string[] args)
//    {
//        int n = int.Parse(Console.ReadLine());

//        //char[,] matrix = new char[n, n];

//        char[,] matrix = ReadCharMatrix(n, n);

//        PrintMatrixAbs(matrix, Console.Write);



//    }

//    // със сепаратор
//    // използва се с
//    //char[,] matrix = ReadCharMatrix(n, n, " ");
//    public static char[,] ReadCharMatrixSeparator(int rows, int cols, string separator)
//    {
//        char[,] matrix = new char[rows, cols];

//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            //string rowArray = Console.ReadLine(); //без сепаратор
//            char[] rowArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                matrix[row, col] = rowArray[col];
//            }
//        }
//        return matrix;
//    }

//    // без сепаратор
//    // използва се с
//    //char[,] matrix = ReadCharMatrix(n, n);
//    public static char[,] ReadCharMatrix(int rows, int cols)
//    {
//        char[,] matrix = new char[rows, cols];

//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            string rowArray = Console.ReadLine(); //без сепаратор

//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                matrix[row, col] = rowArray[col];
//            }
//        }
//        return matrix;
//    }


//    //int[,] matrix = ReadIntMatrix(n, n, " ");
//    private static int[,] ReadIntMatrix(int rows, int cols, string separator)
//    {
//        int[,] matrix = new int[rows, cols];

//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            int[] rowArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                matrix[row, col] = rowArray[col];
//            }
//        }
//        return matrix;
//    }

//    //PrintMatrix(matrix); //така извикваме принт метода
//    static void PrintMatrix<T>(T[,] matrix)
//    {
//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                Console.Write(matrix[row, col]);
//            }

//            Console.WriteLine();
//        }
//    }

//    //PrintMatrixAbs(matrix, Console.Write); //така извикваме принт метода
//    //PrintMatrixAbs(matrix, symbol =>
//    //    {
//    //       Console.Write(symbol);
//    //    });

//    static void PrintMatrixAbs<T>(T[,] matrix, Action<T> print)
//    {
//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                print(matrix[row, col]);
//            }

//            Console.WriteLine();
//        }
//    }

//    enum Direction
//    {
//        down,
//        up,
//        left,
//        right
//    }

//}