using P01_StudentSystem.Data;

namespace P01_StudentSystem;
public class StartUp
{
    static void Main(string[] args)
    {
        //Main application 
        Console.WriteLine("Db Creation Started...");


        try
        {
            using StudentSystemContext dbContext = new StudentSystemContext();

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

