using System;

namespace _03.WorldSnookerChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            //“Quarter final ”, “Semi final” или “Final”
            //“Standard”, “Premium” или “VIP”
            // символ – 'Y' (да) или 'N' (не)

            //              Четвъртфинал    Полуфинал       Финал
            //Стандартен    55.50 £/ бр.    75.88 £/ бр.    110.10 £/ бр.
            //Премиум      105.20 £/ бр.    125.22 £/ бр.   160.66 £/ бр.
            //ВИП          118.90 £/ бр.    300.40 £/ бр.   400 £/ бр.



            string stageInTournament = Console.ReadLine();
            string typeOfTickets = Console.ReadLine();
            int countOfTickets = int.Parse(Console.ReadLine());
            string photoWithTrophy = Console.ReadLine();

            double priceForTicket = 0;

            if (typeOfTickets == "Standard")
            {
                if (stageInTournament == "Quarter final")
                {
                    priceForTicket = 55.50;
                }
                else if (stageInTournament == "Semi final")
                {
                    priceForTicket = 75.88;
                }
                else if (stageInTournament == "Final")
                {
                    priceForTicket = 110.10;
                }

            }
            else if (typeOfTickets == "Premium")
            {
                if (stageInTournament == "Quarter final")
                {
                    priceForTicket = 105.20;
                }
                else if (stageInTournament == "Semi final")
                {
                    priceForTicket = 125.22;
                }
                else if (stageInTournament == "Final")
                {
                    priceForTicket = 160.66;
                }
            }
            else if (typeOfTickets == "VIP")
            {
                if (stageInTournament == "Quarter final")
                {
                    priceForTicket = 118.90;
                }
                else if (stageInTournament == "Semi final")
                {
                    priceForTicket = 300.40;
                }
                else if (stageInTournament == "Final")
                {
                    priceForTicket = 400.00;
                }

            }


                double priceForAllTickets = countOfTickets * priceForTicket;
                bool freePhoto = false;

                if (priceForAllTickets > 4000)
                {
                    priceForAllTickets *= 0.75;
                    freePhoto = true;
                }
                else if (priceForAllTickets > 2500)
                {
                    priceForAllTickets *= 0.90;

                }

                if (photoWithTrophy == "Y" && !freePhoto)
                {
                    priceForAllTickets += countOfTickets * 40;
                }
       

            

            Console.WriteLine($"{priceForAllTickets:f2}");
        }
    }
}

