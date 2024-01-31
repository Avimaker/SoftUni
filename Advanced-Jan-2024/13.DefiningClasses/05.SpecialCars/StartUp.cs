/*
2 2.6 3 1.6 2 3.6 3 1.6
1 3.3 2 1.6 5 2.4 1 3.2
No more tires
331 2.2
145 2.0
Engines done
Audi A5 2017 200 12 0 0
BMW X5 2007 175 18 1 1
Show special
 
*/

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {

            List<Tire> tires = new List<Tire>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
          

            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = input.Split();
                for (int i = 0; i < tireInfo.Length; i += 2)
                {
                    int year = int.Parse(tireInfo[i]);
                    double pressure = double.Parse(tireInfo[i + 1]);
                    tires.Add(new Tire(year, pressure));
                }
            }

            List<Tire> tiresN0 = new();
            List<Tire> tiresN1 = new();

            for (int i = 0; i < tires.Count; i++)
            {
                if (i < tires.Count/2)
                {
                    tiresN0.Add(tires[i]);
                }
                else
                {
                    tiresN1.Add(tires[i]);
                }
            }



            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split();
                for (int i = 0; i < engineInfo.Length; i += 2)
                {
                    int horsePower = int.Parse(engineInfo[i]);
                    double cubicCapacity = double.Parse(engineInfo[i + 1]);
                    engines.Add(new Engine(horsePower, cubicCapacity));

                }

            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);
                string tireIndexConcat = "tiresN" + tiresIndex;

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], new List<Tire>(tiresN0));
                cars.Add(car);
            }

            var specialCars = cars
                .Where(car => car.Year >= 2017 && car.Engine.HorsePower > 330 && car.CalculateTotalPressure() >= 9 && car.CalculateTotalPressure() <= 10)
                .ToList();

            foreach (var specialCar in specialCars)
            {
                specialCar.Drive(20);
                Console.WriteLine(specialCar.WhoAmI());
            }

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            ////Console.WriteLine($"Default golf: " + firstCar.WhoAmI());
            //Console.WriteLine(firstCar.WhoAmI());
            //Console.WriteLine(secondCar.WhoAmI());
            //Console.WriteLine(thirdCar.WhoAmI());

            //var tires = new Tire[4]
            //    {
            //        new Tire(1, 2.5),
            //        new Tire(1, 2.1),
            //        new Tire(2, 0.5),
            //        new Tire(2, 2.3),
            //    };

            //var engine = new Engine(560, 6300);

            //var car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);


            //Console.WriteLine("Horse power: " + car.Engine.HorsePower);

            //foreach (var tire in car.Tires)
            //{
            //    Console.WriteLine($"{tire.Year} - {tire.Pressure}");
            //}


        }

    }
}

