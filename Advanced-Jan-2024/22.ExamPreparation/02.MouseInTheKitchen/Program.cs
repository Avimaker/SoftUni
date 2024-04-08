
/*
5,5
**M**
T@@**
CC@**
**@@*
**CC*
left
down
left
down
down
down
right
danger

4,8
CC@**C*M
T*@**CT*
**@@@@**
T***C***
down
right
left
down
left
danger

6,3
@CC
@TC
@C*
@M*
@**
@**
left
up
left
right
up
up
left
left
danger


*/


namespace _02.MouseInTheKitchen;
class Program
{
    static void Main(string[] args)
    {

        //задаваме големината на матрицата
        int[] input = Console.ReadLine()
            .Split(",")
            .Select(int.Parse)
            .ToArray();

        int rows = input[0];
        int cols = input[1];

        //четем матрицата с метод за char матрица
        char[,] matrix = ReadCharMatrix(rows, cols);

        //така намираме къде е старта. Задаваме нулеви параметри и започваме да търсим M, когато го намерим сетваме координатите за начални

        int currentRow = 0;
        int currentCol = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'M')
                {
                    currentRow = row;
                    currentCol = col;
                    break;
                }
            }
        }

        //намирам колко са сиренцата
        int counterCheese = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'C')
                {
                    counterCheese++;
                }
            }
        }


        //стартираме четенето на командите
        string command = Console.ReadLine();

        while (command != "danger")
        {
            //понеже сме на тази позиция, слагаме -
            matrix[currentRow, currentCol] = '*';

            // тук вместо if ползваме енумерация като кастваме с долната команда енумерацията към променливата direction
            Direction direction = (Direction)Enum.Parse(typeof(Direction), command);
            switch (direction)
            {
                case Direction.down:
                    currentRow++; //увеличаваме надолу 
                    if (currentRow >= matrix.GetLength(0)) 
                    {
                        currentRow = matrix.GetLength(0) - 1; //за да остана в матрицата
                        // слагаме на координатите "M" където сме
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("No more cheese for tonight!");
                        PrintMatrix(matrix);//print
                        return;//todo print
                    }
                    if (matrix[currentRow, currentCol] == '@')
                    {
                        currentRow--;//ако има символ @ отменяме
                    }
                    break;
                case Direction.up:// увеличаваме нагоре
                    currentRow--;
                    if (currentRow < 0) //ако излезем от матрицта
                    {
                        currentRow = 0;//за да остана в матрицата
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("No more cheese for tonight!");
                        PrintMatrix(matrix);//todo print
                        return;
                    }
                    if (matrix[currentRow, currentCol] == '@')
                    {
                        currentRow++;//ако има символ @ отменяме
                    }
                    break;
                case Direction.left: //ако излезем от матрицта
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol = 0;//за да остана в матрицата
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("No more cheese for tonight!");
                        PrintMatrix(matrix);//todo print
                        return;
                    }
                    if (matrix[currentRow, currentCol] == '@')
                    {
                        currentCol++;//ако има символ @ отменяме
                    }
                    break;
                case Direction.right: //ако излезем от матрицта
                    currentCol++;
                    if (currentCol >= matrix.GetLength(1))
                    {
                        currentCol = matrix.GetLength(1)-1;//за да остана в матрицата
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("No more cheese for tonight!");
                        PrintMatrix(matrix);//todo print
                        return;
                    }
                    else if (matrix[currentRow, currentCol] == '@')
                    {
                        currentCol--;//ако има символ @ отменяме
                    }

                    break;
                default: break;
            }

            // тук правим проверки на какво сме попаднали
            if (matrix[currentRow, currentCol] != '*') // при * прескачаме
            {

                if (matrix[currentRow, currentCol] == 'C')
                {
                    counterCheese--;

                    if (counterCheese == 0)
                    {
                        matrix[currentRow, currentCol] = 'M';
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        PrintMatrix(matrix);
                        return; //todo print
                    }
                }

                else if (matrix[currentRow, currentCol] == 'T')
                {
                    matrix[currentRow, currentCol] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    PrintMatrix(matrix);
                    return; //todo print
                }
                // слагаме маркер на координатите в които сме в момента "M"
                matrix[currentRow, currentCol] = 'M';
            }

            //четем и продължаваме напред
            command = Console.ReadLine();// слагаме задължително в края
        }
        // тук свуршва while цикъла


        if (counterCheese > 0)
        {
            Console.WriteLine("Mouse will come back later!");
        }

        PrintMatrix(matrix);


    }

    enum Direction
    {
        down,
        up,
        left,
        right
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