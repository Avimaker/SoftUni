using System;
using EDriveRent.Models.Contracts;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;
        private int batteryLevel = 100;//ctor? работи и така
        private bool isDamaged = false;//ctror? работи и така

        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or whitespace!");
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or whitespace!");
                }
                model = value;
            }
        }

        //not to forget
        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("License plate number is required!");
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel
        {
            get { return this.batteryLevel; }
            private set { this.batteryLevel = value; }
        }

        public bool IsDamaged
        {
            get { return this.isDamaged; }
            private set { this.isDamaged = value; }
        }

        public void Drive(double mileage)
        {
            double percentage = Math.Round((mileage / MaxMileage) * 100);
            batteryLevel -= (int)percentage;

            if (GetType().Name == "CargoVan") // to check?
            //if (this.GetType().Name == nameof(CargoVan))
            {
                batteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public void ChangeStatus()
        {
            if (!isDamaged)
            {
                IsDamaged = true;
            }
            else
            {
                IsDamaged = false;
            }
        }

        public override string ToString()
        {
            string vehicleCondition;

            if (isDamaged)
            {
                vehicleCondition = "damaged";
            }
            else
            {
                vehicleCondition = "OK";
            }

            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {vehicleCondition}";
        }

    }
}

