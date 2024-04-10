using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server>();
        }

        public int Slots { get; set; } //max number of devices
        public List<Server> Servers { get; set; }
        public int GetCount => Servers.Count;

        public void AddServer(Server server)
        {
            if (Slots == Servers.Count)
            {
                return;
            }
            if (Servers.Contains(server))
            {
                return;
            }
            Servers.Add(server);
        }

        public bool RemoveServer(string serialNumber)
        {
            Server foundedServer = Servers.FirstOrDefault(n => n.SerialNumber == serialNumber);

            if (foundedServer == null)
            {
                return false;
            }
            else
            {
                Servers.Remove(foundedServer);
                return true;
            }
        }

        public Server GetHighestPowerUsage()
        {
            Server foundedServer = Servers.OrderByDescending(w => w.PowerUsage).FirstOrDefault();

            return foundedServer;
        }

        public int GetTotalCapacity()
        {
            var foundedServer = Servers.Sum(c => c.Capacity);

            return foundedServer;
        }

        public string DeviceManager()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Servers.Count} servers operating:");

            foreach (var server in Servers)
            {
                sb.AppendLine(server.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
