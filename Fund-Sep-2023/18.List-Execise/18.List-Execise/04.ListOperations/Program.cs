/*
5 12 42 95 32 1
Insert 3 0
Remove 10
Insert 8 6
Shift right 1
Shift left 2
End
*/

namespace _04.ListOperations;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        string input = default;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] arguments = input.Split();

            if (arguments[0] == "Add")
            {
                //int element = int.Parse(arguments[1]);
                //numbers.Add(element);
                list.Add(int.Parse(arguments[1]));
            }

            else if (arguments[0] == "Insert")
            {
                int element = int.Parse(arguments[1]);
                int index = int.Parse(arguments[2]);

                if (index < 0 || index >= list.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    list.Insert(index, element);
                }
            }

            else if (arguments[0] == "Remove")
            {
                int index = int.Parse(arguments[1]);

                if (index < 0 || index >= list.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    list.RemoveAt(index);
                }
            }

            else if (arguments[0] == "Shift")
            {
                int shiftCount = int.Parse(arguments[2]);
                shiftCount %= list.Count;

                if (arguments[1] == "left")
                {
                    // list = [ 1 2 3 4 5 ]
                    List<int> shiftedPart = list.GetRange(0, shiftCount);
                    // shiftedPart = [ 1 2 ]
                    list.RemoveRange(0, shiftCount);
                    // list = [ 3 4 5 ]
                    list.InsertRange(list.Count, shiftedPart);
                    // list = [ 3 4 5 1 2 ]
                }
                if (arguments[1] == "right")
                {
                    // list = [ 1 2 3 4 5 ]
                    List<int> shiftedPart = list.GetRange(list.Count - shiftCount, shiftCount);
                    //                       | | изтрива се е и се запазва
                    // shiftedPart = [ 1 2 3 4 5 ] т.е. става [ 1 2 3 ] ]
                    list.RemoveRange(list.Count - shiftCount, shiftCount);
                    // list = [ 1 2 3]
                    list.InsertRange(0, shiftedPart);
                    // list = [ 4 5 1 2 3 ]


                }

            }
        }
        Console.WriteLine(string.Join(" ", list));
    }
}

