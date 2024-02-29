/*
0882134215 0882134333 0899213421 0558123 3333123
http://softuni.bg http://youtube.com http://www.g00gle.com

08a2134215 0882134333 0899213421 0558123 3333123

*/
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony;
public class StartUp
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string[] urls = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        ICallable callable;

        foreach (var number in numbers)
        {
            if (number.Length == 10)
            {
                callable = new Smartphone();
            }
            else
            {
                callable = new StationaryPhone();
            }
            try
            {
                Console.WriteLine(callable.Call(number));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        IBrowsable browsable = new Smartphone();

        foreach (var url in urls)
        {
            try
            {
                Console.WriteLine(browsable.Browse(url));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

