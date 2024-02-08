/*
3
aa
aaa
bb
aa

 
*/

namespace GenericCountMethodString;
class StartUp
{
    static void Main()
    {

        List<string> elements = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string element = Console.ReadLine();
            elements.Add(element);
        }

        string compare = Console.ReadLine();

        Count(compare, elements);
    }

    public static void Count<T>(T compare, List<T> elements) where T : IComparable<T>
    {
        int count = 0;
        foreach (var element in elements)
        {
            if (element.CompareTo(compare) > 0)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
   
}

