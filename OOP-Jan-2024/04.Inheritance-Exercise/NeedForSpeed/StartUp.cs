namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportcar = new(500, 200);

            sportcar.Drive(10);

            System.Console.WriteLine(sportcar.Fuel);

        }
    }
}
