using P02_FootballBetting.Data;

namespace P02_FootballBetting;
class StartUp
{
    public static void Main(string[] args)
    {
        //Main application 
        Console.WriteLine("Db Creation Started...");


        try
        {
            using FootballBettingContext dbContext = new FootballBettingContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            Console.WriteLine("Db Creation was succesful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Db Creation failed!");
            Console.WriteLine(ex.Message);
        }

    }
}

