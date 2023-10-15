/*
1 2 3 4 5 5 5 6
Delete 5
Insert 10 1
Delete 5
end
*/

namespace _02.ChangeList;

class Program
{
    static void Main(string[] args)
    {

        List <int> list = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

        string commands = default;
        while ((commands = Console.ReadLine()) != "end")
{
            string[] arguments = commands.Split();

            if (arguments[0] == "Delete")
            {
                int elelment = int.Parse(arguments[1]);
                //list.Remove(elelment);

                // предикат
                //list.RemoveAll(x => x == elelment);//предикат, за всеки х в листа който е равен на елемента който сме подали

                //обяснение как работи предикат
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == elelment)
                    {
                        list.Remove(elelment);
                        i--; //това се прави защото листа се скасява с едно
                    }
                }

            }
            else if (arguments[0] == "Insert")
            {
                int elelment = int.Parse(arguments[1]);
                int position = int.Parse(arguments[2]);

                list.Insert(position, elelment);

            }

        }

        Console.WriteLine(string.Join(" ", list));
    }
}

