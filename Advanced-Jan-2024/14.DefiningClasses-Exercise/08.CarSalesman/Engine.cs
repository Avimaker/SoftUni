/*
"{model} {power} {displacement} {efficiency}" 
 V8-101		220		50             n/a
*/

using System;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {

        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        //ctor
        public string Model { get; set; }
        public int Power { get; set; }

        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }

        //public string Efficiency // не сработи така
        //{
        //    get { return this.efficiency; }
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            this.efficiency = "n/a";
        //            return;
        //        }
        //        this.efficiency = value;
        //    }
        //}

        public string Efficiency
        {
            get { return this.efficiency; }
            set {this.efficiency = value; }
        }


        public override string ToString()
        {
            // short
            //string displacement = Displacement == 0 ? "n/a" : Displacement.ToString();

            //long
            string displacement;
            if (Displacement == 0)
            {
                displacement = "n/a";
            }
            else
            {
                displacement = Displacement.ToString();
            }

            string efficiency = Efficiency ?? "n/a"; //направих тази проверка в сетъра, ама не мина в джъдж със 100 :(


            StringBuilder sb = new();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine($"    Displacement: {displacement}");
            sb.AppendLine($"    Efficiency: {efficiency}");


            return sb.ToString().TrimEnd();
        }

    }
}

