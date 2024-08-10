using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository :IRepository<ITeam>
    {
        private readonly List<ITeam> models = new();
        public IReadOnlyCollection<ITeam> Models => models.AsReadOnly();
        public void AddModel(ITeam model) => models.Add(model);
        public bool RemoveModel(string name)
        {
            ITeam team = models.FirstOrDefault(x => x.Name == name);
            return team == null ? false : models.Remove(team);
        }

        public bool ExistsModel(string name) => models.FirstOrDefault(x => x.Name == name) != null;

        public ITeam GetModel(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
