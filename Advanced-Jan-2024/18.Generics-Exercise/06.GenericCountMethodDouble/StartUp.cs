/*
3
7.13
123.22
42.78
7.55

3
1.1
2.3
3.2
1.5

*/

namespace GenericCountMethodDouble;
class StartUp
{
    static void Main()
    {

        List<double> elements = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            double element = double.Parse(Console.ReadLine());
            elements.Add(element);
        }

        double compare = double.Parse(Console.ReadLine());

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

