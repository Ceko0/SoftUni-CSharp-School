using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    internal class ResourceRepository : IRepository<IResource>
    {
        private List<IResource> models;

        public ResourceRepository()
        {
            models = new();
            Models = models.AsReadOnly();
        }
        public IReadOnlyCollection<IResource> Models { get; }
        public void Add(IResource model) => models.Add(model);
        public IResource TakeOne(string modelName) => models.FirstOrDefault(m => m.Name == modelName);
    }
}
