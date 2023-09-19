using System;

namespace _05.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int fine = 0;

            for (int i = 0; i < tabs && fine < salary; i++)
            {
                string website = Console.ReadLine();

                switch (website)
                {
                    case "Facebook":
                        fine += 150;
                        break;
                    case "Instagram":
                        fine += 100;
                        break;
                    case "Reddit":
                        fine += 50;
                        break;
                }

                //if (website == "Facebook") { fine += 150; }
                //if (website == "Instagram") { fine += 100; }
                //if (website == "Reddit") { fine += 50; }
            }

            if (fine >= salary)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary - fine);
            }

        }
    }
}

