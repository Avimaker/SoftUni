﻿using System;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
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

            result.Append($"Make: {this.Make}\n");
            result.Append($"Model: {this.Model}\n");
            result.Append($"Year: {this.Year}\n");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");

            return result.ToString().Trim();
        }



    }
}