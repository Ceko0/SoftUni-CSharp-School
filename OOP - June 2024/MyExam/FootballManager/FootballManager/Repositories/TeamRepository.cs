using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models = new();
        private const int capacity = 10;
        public IReadOnlyCollection<ITeam> Models => models.AsReadOnly();
        public int Capacity => capacity;
        public void Add(ITeam model)
        {
            //TO DO (check Team Exist)
           if(models.Count < 10) models.Add(model);
        }

        public bool Remove(string name)
        {
            ITeam team = models.FirstOrDefault(x => x.Name == name);
            return models.Remove(team);
        }

        public bool Exists(string name) => models.FirstOrDefault(x => x.Name == name) != null;

        public ITeam Get(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
