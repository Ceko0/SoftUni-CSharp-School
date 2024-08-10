using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private readonly List<IInfluencer> model = new();
        public IReadOnlyCollection<IInfluencer> Models => model.AsReadOnly();
        public void AddModel(IInfluencer model) => this.model.Add(model);
        public bool RemoveModel(IInfluencer model) =>  this.model.Remove(model);
        public IInfluencer FindByName(string name) => this.model.FirstOrDefault(x => x.Username == name);
    }
}
