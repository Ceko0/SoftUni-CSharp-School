using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private readonly List<ICampaign> model = new();
        public IReadOnlyCollection<ICampaign> Models => model.AsReadOnly();
        public void AddModel(ICampaign model) => this.model.Add(model);

        public bool RemoveModel(ICampaign model) => this.model.Remove(model);

        public ICampaign FindByName(string name) => this.model.FirstOrDefault(x => x.Brand == name);
    }
}
