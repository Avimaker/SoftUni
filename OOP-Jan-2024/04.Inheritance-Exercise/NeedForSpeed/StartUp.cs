namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar vehicle = new(200, 100);

            vehicle.Drive(10);

            System.Console.WriteLine(vehicle.Fuel);
        }
    }
}
