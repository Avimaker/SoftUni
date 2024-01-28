using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires; 
        }



        //private fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;


        //properties - short way
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        //properties - full sintaxis
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        //properties - new way of sintaxis
        public double FuelConsumption
        {
            get => this.fuelConsumption;
            set => fuelConsumption = value;
        }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }




        //method
        public void Drive(double distance)
        {
            if (distance * fuelConsumption > fuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                fuelQuantity -= distance * fuelConsumption;
            }
        }

        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"Make: {this.Make}\n");
            result.Append($"Model: {this.Model}\n");
            result.Append($"Year: {this.Year}\n");
            result.Append($"Fuel: {this.FuelQuantity:F2}");

            return result.ToString().Trim();
        }



    }
}
