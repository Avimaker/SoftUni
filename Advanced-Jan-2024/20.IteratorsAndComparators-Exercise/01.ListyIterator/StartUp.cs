/*
Create
Print
END

Create Steve George
HasNext
Print
Move
Print
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

        }

    }
}

