﻿namespace CarManufacturer
{
	public class Engine
	{
		
        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }

        private int horsePower;
		private double cubicCapacity;

		public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

    }
}

