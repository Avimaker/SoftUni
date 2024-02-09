/*
Create 1 2 3 4 5
Move
PrintAll
END

Create Stefcho Goshky Peshu
PrintAll
Move
Move
Print
HasNext
END
 
*/

namespace ListyIteratorType;
class StartUp
{
    static void Main(string[] args)
    {

        List<string> items = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .ToList();

        ListyIterator<string> listyIterator = new(items);

        string command = default;
        while ((command = Console.ReadLine()) != "END")
        {
            if (command == "Move")
            {
                Console.WriteLine(listyIterator.Move());
            }

            else if (command == "HasNext")
            {
                Console.WriteLine(listyIterator.HasNext());
            }

            else if (command == "Print")
            {
                try
                {
                    listyIterator.Print();
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            else if (command == "PrintAll")
            {
                try
                {
                    foreach (var item in listyIterator)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

        }

    }
}

