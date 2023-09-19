using System;

namespace _03.EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            //if (number % 2 != 0) //така търсим нечетно

            if (number % 2 == 0) //така търсим четно с модулно деление, което връща като остатък само дробната част
            {
                Console.WriteLine("even"); //ако е четно е тру
            }
            else
            {
                Console.WriteLine("odd");
            }

            //Math.Floor - закръгля винаги надолу
            //Math.Ceiling - закръгля винаги нагоре
            //Math.Round - закръгля от .5 нагоре
            //Math.Round(promenliva, 2) закръгля до 2 знака след запетаята
            //Console.WriteLine($"{promenliva:F2}"); F(1...)до кой символ да показва

        }
    }
}

