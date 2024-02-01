using System;
namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tyre[] tyres;

        public Car(string model, int speed, int power,
        int weight, string type,
        double tyre1pressure, int tyre1age,
        double tyre2pressure, int tyre2age,
        double tyre3pressure, int tyre3age,
        double tyre4pressure, int tyre4age)
        {
            Model = model;
            Engine = new(speed, power);
            Cargo = new(weight, type);
            Tyres = new Tyre[4];
            Tyres[0] = new(tyre1pressure, tyre1age);
            Tyres[1] = new(tyre2pressure, tyre2age);
            Tyres[2] = new(tyre3pressure, tyre3age);
            Tyres[3] = new(tyre4pressure, tyre4age);
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public Tyre[] Tyres
        {
            get { return this.tyres; }
            set { this.tyres = value; }
        }




    }
}

