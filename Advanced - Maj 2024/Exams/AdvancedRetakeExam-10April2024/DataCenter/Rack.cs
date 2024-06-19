using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server> ();
        }

        public int Slots { get; set; }

        public List<Server> Servers { get; set; }

        public int GetCount => Servers.Count();

        public void AddServer(Server server)
        {
            if(GetCount < Slots && !Servers.Any(s => s.SerialNumber == server.SerialNumber))
            {
                Servers.Add(server);
            }
        }

        public bool RemoveServer(string serialNumber)
        {
            Server serverToRemove = Servers.FirstOrDefault(s => s.SerialNumber == serialNumber);

            if(serverToRemove != null)
            {
                Servers.Remove(serverToRemove);
                return true;
            }

            return false;
        }

        public string GetHighestPowerUsage()
        {
            return Servers.OrderByDescending(s => s.PowerUsage).FirstOrDefault().ToString();
        }

        public int GetTotalCapacity()
        {
            return Servers.Sum(s => s.Capacity);
        }

        public string DeviceManager()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetCount} servers operating:");

            foreach(Server server in Servers)
            {
                sb.AppendLine(server.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
