using System;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        //private fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

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

            result.Append($"Make: {this.Make}");
            result.Append($"Model: {this.Model}");
            result.Append($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}");

            return result.ToString().Trim();
        }



    }
}
