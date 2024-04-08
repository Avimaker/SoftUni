using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        //private List<Vehicle> vehicles;//todo instance

        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle foundVehicle = Vehicles.FirstOrDefault(v => v.VIN == vin);
            if (foundVehicle == null)
            {
                return false;
            }
            Vehicles.Remove(foundVehicle);
            return true;
        }

        public int GetCount()
        {
            return Vehicles.Count();
        }

        public Vehicle GetLowestMileage()
        {
            Vehicle result = Vehicles.OrderBy(v => v.Mileage).FirstOrDefault();

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var car in Vehicles)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
