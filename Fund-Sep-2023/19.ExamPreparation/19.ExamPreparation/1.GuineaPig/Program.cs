/*
9
5
5.2
1

10
5
5.2
1

*/

namespace _1.GuineaPig;

class Program
{
    static void Main(string[] args)
    {
        double food = double.Parse(Console.ReadLine()) * 1000;
        double hay = double.Parse(Console.ReadLine()) * 1000;
        double cover = double.Parse(Console.ReadLine()) * 1000;
        double weight = double.Parse(Console.ReadLine()) * 1000;

        for (int day = 1; day <= 30; day++)
        {
            food -= 300;

            // every second day
            if (day % 2 == 0)
            {
                double hayAmmount = food * 0.05;
                hay -= hayAmmount;
            }
            // every third day
            if (day % 3 == 0)
            {
                double coverAmmount = weight / 3;
                cover -= coverAmmount;
            }

            if (food <= 0 || hay <= 0 || cover <= 0)
            {
                Console.WriteLine("Merry must go to the pet store!");
                return;
            }

        }

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {(food/1000):f2}, Hay: {(hay / 1000):f2}, Cover: {(cover / 1000):f2}.");

    }
}

