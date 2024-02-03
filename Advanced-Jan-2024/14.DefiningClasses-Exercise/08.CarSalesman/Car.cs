/*
FordFocus V4-33 1300 Silver
 
*/

using System;
using System.Text;

namespace CarSalesman
{
	public class Car
	{
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get; set; }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public override string ToString()
        {
            string weight = Weight == 0 ? "n/a" : Weight.ToString(); // if Weight equals 0 - default value, then string takes value "n/a" else takes string value of Weight for example "1300"
            string color = Color ?? "n/a"; // if Color is null then string takes value "n/a" else it takes Color value for example "Silver"

            StringBuilder sb = new();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.ToString()}");
            sb.AppendLine($"  Weight: {weight}");
            sb.AppendLine($"  Color: {color}");

            return sb.ToString().TrimEnd();


        }


    }
}

