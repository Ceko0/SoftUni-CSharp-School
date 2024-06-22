using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        public List<RealEstate> RealEstates { get; set; }
        public int Capacity { get; set; }        
        public int Count => RealEstates.Count;
        public EstateAgency(int capacity)
        {
            Capacity = capacity;
            RealEstates = new();
        }
        public void AddRealEstate(RealEstate realEstate)
        {
            if (!RealEstates.Contains(realEstate) && RealEstates.Count < Capacity)
            {
                RealEstates.Add(realEstate);
            }
        }
        public bool RemoveRealEstate(string address)
        {
            RealEstate current = RealEstates.FirstOrDefault(x => x.Address == address);
            return RealEstates.Remove(current);
        }
        public List<RealEstate> GetRealEstates(string postalCode)
        {
            List<RealEstate> current = RealEstates.Where(x => x.PostalCode == postalCode).ToList();
            return current;
        }
        public RealEstate GetCheapest()
        {
            return RealEstates.OrderBy(x => x.Price).FirstOrDefault();
        }
        public double GetLargest()
        {
            var largestRealEstate = RealEstates.OrderByDescending(x => x.Size).FirstOrDefault();
            return largestRealEstate?.Size ?? 0;
        }
        public string EstateReport()
        {
            StringBuilder sb = new();
            sb.AppendLine("Real estates available:");
            foreach (var realEstate in RealEstates)
            {
                sb.AppendLine(realEstate.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
