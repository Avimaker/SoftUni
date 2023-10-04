using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {

            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            CalculateArea(w, h);

        }

        private static double CalculateArea(double w, double h)
        {
            double area = w * h;
            return area;

            //return w * h;
        }
    }
}

