using System;

namespace _03.TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int hourToMinutes = hour * 60;

            int totalTime = hourToMinutes + minutes + 15;

            int displayHour = totalTime / 60;
            int displayMinutes = totalTime % 60;

            if (displayMinutes < 10)
            {
                if (displayHour == 24)
                {
                    Console.WriteLine($"0:0{displayMinutes}");
                }
                else
                {
                    Console.WriteLine($"{displayHour}:0{displayMinutes}");
                }
            }

            else
            {
                if (displayHour == 24)
                {
                    Console.WriteLine($"0:{displayMinutes}");
                }
                else
                { 
                    Console.WriteLine($"{displayHour}:{displayMinutes}");
                }

            }

            
            
        }
    }
}

