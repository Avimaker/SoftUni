/*
5 6
*----A
*B***-
*-***-
*----P
******
down
down
right
right
right
right
up
up
up
 
 */


namespace _02.DeliveryBoy;
class Program
{
    static void Main(string[] args)
    {

        //задаваме големината на матрицата
        int[] input = Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();

        int rows = input[0];
        int cols = input[1];

        //четем матрицата с метод за char матрица
        char[,] matrix = ReadCharMatrix(rows, cols);

        //така намираме къде е старта. Задаваме нулеви параметри и започваме да търсим B, когато го намерим сетваме координатите за начални

        int currentRow = -1;
        int currentCol = -1;
        // запазваме за финала
        int startRow = -1;
        int startCol = -1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'B')
                {
                    currentRow = row;
                    currentCol = col;
                    startRow = row;
                    startCol = col;
                }
            }
        }

        bool hasLeft = false;

        while (true)
        {
            //стартираме четенето на командите
            string command = Console.ReadLine();

            if (command == "left")
            {
                if (currentCol > 0)
                {
                    if (matrix[currentRow, currentCol - 1] == '*')
                    {
                        continue;//ако има символ * отменяме
                    }
                    if (matrix[currentRow, currentCol] != 'R')
                    {
                        //понеже сме на тази позиция, слагаме -
                        matrix[currentRow, currentCol] = '.';
                    }
                    currentCol--; //увеличаваме надолу 
                }
                else
                {
                    if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[currentRow, currentCol] = '.';
                    }
                    hasLeft = true;
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    break;
                }
            }

            if (command == "right")
            {
                if (currentCol < matrix.GetLength(1) - 1)
                {
                    if (matrix[currentRow, currentCol + 1] == '*')
                    {
                        continue;//ако има символ * отменяме
                    }
                    if (matrix[currentRow, currentCol] != 'R')
                    {
                        //понеже сме на тази позиция, слагаме -
                        matrix[currentRow, currentCol] = '.';
                    }
                    currentCol++; //увеличаваме надолу 
                }
                else
                {
                    if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[currentRow, currentCol] = '.';
                    }
                    hasLeft = true;
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    break;
                }
            }

            if (command == "up")
            {
                if (currentRow > 0)
                {
                    if (matrix[currentRow - 1, currentCol] == '*')
                    {
                        continue;//ако има символ * отменяме
                    }
                    if (matrix[currentRow, currentCol] != 'R')
                    {
                        //понеже сме на тази позиция, слагаме -
                        matrix[currentRow, currentCol] = '.';
                    }
                    currentRow--; //увеличаваме надолу 
                }
                else
                {
                    if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[currentRow, currentCol] = '.';
                    }
                    hasLeft = true;
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    break;
                }
            }

            if (command == "down")
            {
                if (currentRow < matrix.GetLength(0) - 1)
                {
                    if (matrix[currentRow + 1, currentCol] == '*')
                    {
                        continue;//ако има символ * отменяме
                    }
                    if (matrix[currentRow, currentCol] != 'R')
                    {
                        //понеже сме на тази позиция, слагаме -
                        matrix[currentRow, currentCol] = '.';
                    }
                    currentRow++; //увеличаваме надолу 
                }
                else
                {
                    if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[currentRow, currentCol] = '.';
                    }
                    hasLeft = true;
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    break;
                }
            }


            // тук правим проверки дали сме на Pizza take
            if (matrix[currentRow, currentCol] == 'P')
            {
                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                matrix[currentRow, currentCol] = 'R';
                continue;
            }
            //тук ако сме доставили пизата маркираме Р вместо А
            if (matrix[currentRow, currentCol] == 'A')
            {
                matrix[currentRow, currentCol] = 'P';
                Console.WriteLine("Pizza is delivered on time! Next order...");
                break;
            }
        }
        // тук свуршва while цикъла

        //тук правим проверка дали сме напуснали матрицата, и какъв символ да сложим на старта
        if (hasLeft)
        {
            matrix[startRow, startCol] = ' ';
        }
        else
        {
            matrix[startRow, startCol] = 'B';
        }


        PrintMatrix(matrix);


    }

   
    //char[,] matrix = ReadCharMatrix(rows, cols);
    public static char[,] ReadCharMatrix(int rows, int cols)
    {
        char[,] matrix = new char[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string rowArray = Console.ReadLine(); //без сепаратор

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowArray[col];
            }
        }
        return matrix;
    }

    //PrintMatrix(matrix); //така извикваме принт метода
    static void PrintMatrix<T>(T[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }



}


