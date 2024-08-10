using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private readonly List<IPeak> all = new();
        public IReadOnlyCollection<IPeak> All => all.AsReadOnly();
        public void Add(IPeak model) => all.Add(model);
        public IPeak Get(string name) => all.FirstOrDefault(x => x.Name == name);
    }
}