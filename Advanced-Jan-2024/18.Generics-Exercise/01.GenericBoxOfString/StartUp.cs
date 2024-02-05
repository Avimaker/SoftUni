/*
2
life in a box
box in a life
 
3
Peter
Simon
Griffin
 
*/

namespace GenericBoxOfString;
class StartUp
{
    static void Main(string[] args)
    {

        Box<string> box = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string item = Console.ReadLine();
            box.Add(item);
        }

        Console.WriteLine(box.ToString());
    }
}

