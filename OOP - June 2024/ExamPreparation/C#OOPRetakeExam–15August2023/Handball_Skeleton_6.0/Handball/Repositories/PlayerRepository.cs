using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> models = new();
        public IReadOnlyCollection<IPlayer> Models => models.AsReadOnly();
        public void AddModel(IPlayer model) => models.Add(model);
        public bool RemoveModel(string name)
        {
            IPlayer player = models.FirstOrDefault(x => x.Name == name);
            if (player == null) return false;
            models.Remove(player);
            return true;
        }
        public bool ExistsModel(string name) => models.FirstOrDefault(x => x.Name == name) != null ?  true: false;

        public IPlayer GetModel(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}
