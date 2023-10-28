//class Ad
//{
//    public string[] Phrases
//    {
//        get
//        {
//            return new string[] {"Excellent product.",
//                    "Such a great product.", "I always use that product.",
//                    "Best product of its category.", "Exceptional product.",
//                    "I can't live without this product."};
//        }
//    }

//    public string[] Events
//    {
//        get
//        {
//            return new string[] {"Now I feel good.",
//                    "I have succeeded with this product.",
//                    "Makes miracles. I am happy of the results!",
//                    "I cannot believe but now I feel awesome.",
//                    "Try it yourself, I am very satisfied.",
//                    "I feel great!"};

//        }

//    }

//    public string[] Autors
//    {
//        get
//        {
//            return new string[] {"Diana", "Petya", "Stella",
//                        "Elena", "Katya", "Iva", "Annie", "Eva"};
//        }
//    }

//    public string[] Cities
//    {
//        get
//        {
//            return new string[] {"Burgas", "Sofia", "Plovdiv",
//                    "Varna", "Ruse"};
//        }
//    }
//}

namespace _01.AdvertisementMessage;

class Advertisements
{
    public string[] Phrases { get; set; }
    public string[] Events { get; set; }
    public string[] Autors { get; set; }
    public string[] Cities { get; set; }
}

class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        Advertisements ad = new Advertisements();

        ad.Phrases = new[]
        {
        "Excellent product.",
        "Such a great product.",
        "I always use that product.",
        "Best product of its category.",
        "Exceptional product.",
        "I can't live without this product."
        };

        ad.Events = new[]
        {
        "Now I feel good.",
        "I have succeeded with this product.",
        "Makes miracles. I am happy of the results!",
        "I cannot believe but now I feel awesome.",
        "Try it yourself, I am very satisfied.",
        "I feel great!"
        };

        ad.Autors = new[]
        {
        "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
        };

        ad.Cities = new[]
        {
        "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
        };

        Random rnd = new Random();

        for (int i = 0; i < count; i++)
        {
        int randomIndex = rnd.Next(0, ad.Phrases.Length); //ако не напишем 0 е по подразбиране
        string rndPhrase = ad.Phrases[randomIndex];

        randomIndex = rnd.Next(ad.Events.Length); // ето тук е без 0
        string rndEvent = ad.Events[randomIndex];

        randomIndex = rnd.Next(ad.Autors.Length);
        string rndAutor = ad.Autors[randomIndex];

        randomIndex = rnd.Next(ad.Cities.Length);
        string rndCities = ad.Cities[randomIndex];

        Console.WriteLine($"{rndPhrase} {rndEvent} {rndAutor} - {rndCities}");
        }

    }
}

