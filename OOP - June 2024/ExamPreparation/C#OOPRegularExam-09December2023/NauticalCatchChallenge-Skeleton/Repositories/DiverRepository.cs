using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private readonly List<IDiver> models = new();
        public IReadOnlyCollection<IDiver> Models => models.AsReadOnly();
        public void AddModel(IDiver model) => models.Add(model);
        public IDiver GetModel(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
