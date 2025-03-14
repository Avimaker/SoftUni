﻿using static System.Net.Mime.MediaTypeNames;

namespace AutomotiveRepairShop
{
    public class Vehicle
    {
        public Vehicle(string vIN, int mileage, string damage)
        {
            VIN = vIN;
            Mileage = mileage;
            Damage = damage;
        }

        public string VIN { get; set; }
        public int Mileage { get; set; }
        public string Damage { get; set; }

        public override string ToString()
        {
            return $"Damage: {Damage}, Vehicle: {VIN} ({Mileage} km)";
        }

    }
}
