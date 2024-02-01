using System;
namespace RawData
{
    public class Tyre
    {
        private int age;
        private double pressure;

        public Tyre(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }

        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

    }
}

