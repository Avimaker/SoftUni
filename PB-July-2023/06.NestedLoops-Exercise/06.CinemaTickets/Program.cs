using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalTicketsCoun = 0;
            int studentTicketsCoun = 0;
            int standardTicketsCoun = 0;
            int kidsTicketsCoun = 0;

            string movieName = Console.ReadLine();
            while (movieName != "Finish")
            {
                int capacity = int.Parse(Console.ReadLine());
                int soldTickets = 0;

                string ticketType = Console.ReadLine();
                while (ticketType != "End")
                {
                    if (ticketType == "student") {studentTicketsCoun++; }
                    if (ticketType == "standard") {standardTicketsCoun++; }
                    if (ticketType == "kid") {kidsTicketsCoun++; }


                    soldTickets++;
                    if (soldTickets == capacity)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();
                }

                totalTicketsCoun += soldTickets;

                double fillPercent = 100.0 * soldTickets / capacity;
                Console.WriteLine($"{movieName} - {fillPercent:f2}% full.");
                movieName = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalTicketsCoun}");
            Console.WriteLine($"{100.0 * studentTicketsCoun / totalTicketsCoun:f2}% student tickets.");
            Console.WriteLine($"{100.0 * standardTicketsCoun / totalTicketsCoun:f2}% standard tickets.");
            Console.WriteLine($"{100.0 * kidsTicketsCoun / totalTicketsCoun:f2}% kids tickets.");


        }
    }
}

