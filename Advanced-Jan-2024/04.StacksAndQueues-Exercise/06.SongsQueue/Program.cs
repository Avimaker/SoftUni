/*
All Over Again, Watch Me
Play
Add Watch Me
Add Love Me Harder
Add Promises
Show
Play
Play
Play
Play
*/

namespace _06.SongsQueue;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> songs = new Queue<string>(Console.ReadLine()
            .Split(", ")
            .ToArray());

        while (songs.Any())
        {
            string[] command = Console.ReadLine().Split().ToArray();

            switch (command[0])
            {
                case "Play":
                    songs.Dequeue();
                    break;

                case "Add":

                    string songName = string.Join(" ", command.Skip(1));

                    if (songs.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songName);
                    }
                    break;

                case "Show":
                    Console.Write(string.Join(", ", songs));
                    Console.WriteLine();
                    break;
            }
        }
        Console.WriteLine("No more songs!");
    }
}